using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [Header("Arco")]
    public LinealFunction linealFunction;
    public float baseSpeed = 10f; // Velocidad base de la flecha    
    public GameObject spawnPointArrow;
    private ObjectPoolBehaviour arrowPool;
    [Header("Espada")]
    public Transform AttackSword;
    public Vector2 boxSize;    
    private bool IsArcher = true;
    private Animator animator;    
    private PlayerStats playerStats;
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

        arrowPool = GetComponent<ObjectPoolBehaviour>();
        playerStats = GetComponent<PlayerStats>();
    }    
    public void Attack2(float force)
    {
        animator.SetBool("Shoot", false);
        animator.SetTrigger("Attack2");
    }
    public void Attack1(float force)
    {
        animator.SetBool("Shoot", false);
        animator.SetTrigger("Attack1");
    }    
    public void StartAttack(InputAction.CallbackContext callbackContext)
    {
        animator.SetBool("CanceledAttack", false);        
        if (IsArcher)
            Attack1(1f);
        else
            Attack2(1f);
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
        int damage = Mathf.RoundToInt(playerStats.fuerza.value * Mathf.Pow(2, playerStats.desEspada.value));        
        
        AttackSword.gameObject.SetActive(true);
        RaycastHit2D[] golpeados = Physics2D.BoxCastAll(AttackSword.position, boxSize, 0, Vector2.zero, 1);
        foreach(RaycastHit2D coll in golpeados)
        {
            Health health = coll.collider.GetComponent<Health>();
            if (health != null)
                health.TakeDamage(damage, gameObject);
        }        
    }
    public void ShootArrow(Vector3 dir)
    {
        float arrowSpeed = CalculateInitialSpeed();
        float damage = playerStats.fuerza.value;        
        GameObject arrow = arrowPool.GetPooledObject();        
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
    public float CalculateInitialSpeed()
    {
        linealFunction.X = playerStats.desArco.value;
        return (baseSpeed + playerStats.fuerza.value) + MathHelper.GetError(linealFunction);
    }
}
