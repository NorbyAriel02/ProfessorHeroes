using TIRIKA;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [Header("Arco")]    
    public float baseSpeed = 10f; // Velocidad base de la flecha    
    public GameObject spawnPointArrow;
    public ObjectPoolData arrowData;    

    [Header("Espada")]    
    public Transform AttackSword;
    public ObjectPoolData particlePolvo;
    public Vector2 boxSize;    
    private bool IsArcher = true;
    private Animator animator;    
    private PlayerStats playerStats;
    private ObjectPoolBehaviour PoolingController;
    private void Awake()
    {
    
    }
    private void OnEnable()
    {    
        BowAttack.OnShoot += ShootArrow;
        InputManager.Instance.controles.Base.Attack1.started += StartAttack;
        InputManager.Instance.controles.Base.Attack1.canceled += Shoot;
        InputManager.Instance.controles.Base.CancelAttack.started += CancelAttack;
    }
    private void OnDisable()
    {     
        BowAttack.OnShoot -= ShootArrow;
        InputManager.Instance.controles.Base.Attack1.started -= StartAttack;
        InputManager.Instance.controles.Base.Attack1.canceled -= Shoot;
        InputManager.Instance.controles.Base.CancelAttack.started -= CancelAttack;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        PoolingController = GetComponent<ObjectPoolBehaviour>();
        playerStats = GetComponent<PlayerStats>();
    }        
    public void StartAttack(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("Shoot", false);
        animator.SetBool("CanceledAttack", false);        
        if (IsArcher)
            animator.SetTrigger("Attack1");
        else
            animator.SetTrigger("Attack2");
    }
    public void Shoot(InputAction.CallbackContext callbackContext)
    {        
        animator.SetBool("Shoot", true);
    }
    public void CancelAttack(InputAction.CallbackContext callbackContext)
    {
        if(InputManager.Instance.controles.Base.Attack1.phase == InputActionPhase.Performed)
        {     
            animator.SetBool("CanceledAttack", true);            
        }        
    }
    public void Defend(float force)
    {        
        animator.SetTrigger("Defend");
    }
    public void AttackWithSword()
    {
        //int damage = Mathf.RoundToInt(playerStats.fuerza.value * Mathf.Pow(2, playerStats.desEspada.value));        
        float damage = MathHelper.GetY(playerStats.Sword);
        print("Damage sword " + damage);
        AttackSword.gameObject.SetActive(true);
        RaycastHit2D[] golpeados = Physics2D.BoxCastAll(AttackSword.position, boxSize, 0, Vector2.zero, 1);
        foreach(RaycastHit2D coll in golpeados)
        {
            Health health = coll.collider.GetComponent<Health>();
            if (health != null)
                health.TakeDamage(damage, gameObject);
            else
            {
                //TODO partidulas de polvo
                GameObject particle = PoolingController.GetPooledObject(particlePolvo.Index);
                particle.transform.position = AttackSword.position;
                particle.transform.rotation = AttackSword.rotation;
                particle.SetActive(true);
                //Instantiate(particlePolvo, AttackSword.position, AttackSword.rotation);
            }                
        }        
    }
    public void ShootArrow(Vector3 dir)
    {
        float arrowSpeed = CalculateInitialSpeed();
        float damage = playerStats.fuerza.value;
        print("Damage bow " + damage);
        GameObject arrow = PoolingController.GetPooledObject(arrowData.Index);
        arrow.GetComponent<ArrowProjectile>()
                .SetInit(
                    arrowSpeed, 
                    dir, 
                    damage, 
                    spawnPointArrow.transform);

        arrow.SetActive(true);
    }
    public void SetMelee()
    {
        IsArcher = false;
    }
    public void SetArcher()
    {
        IsArcher = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(AttackSword.position, boxSize);
    }
    // Método para calcular la velocidad inicial de la flecha
    //con un error variable entre un -max y max
    //este error disminuye entre mayor sea la habilidad del personaje con el arco
    public float CalculateInitialSpeed()
    {        
        return (baseSpeed + playerStats.fuerza.value) + MathHelper.GetError(playerStats.Bow);
    }
}
