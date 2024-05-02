using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float force = 10;
    public GameObject prefabArrow;
    public GameObject spawnPointArrow;
    public Transform AttackSword;
    public Vector2 boxSize;
    private bool IsArcher = true;
    private Animator animator;
    private void OnEnable()
    {
        BowAttack.OnShoot += ShootArrow;
    }
    private void OnDisable()
    {
        BowAttack.OnShoot -= ShootArrow;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }
    public void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("Shoot", true);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if(IsArcher)
                Attack1(1f);
            else
                Attack2(1f);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Defend(1f);            
        }
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
    public void Attack3(float force)
    {
        print("fire 3 " + force);
    }
    public void Defend(float force)
    {
        print("Defend 1 " + force);
        animator.SetTrigger("Defend");
    }
    public void AttackWithSword()
    {
        AttackSword.gameObject.SetActive(true);
        RaycastHit2D[] golpeados = Physics2D.BoxCastAll(AttackSword.position, boxSize, 0, Vector2.zero, 1);
        foreach(RaycastHit2D coll in golpeados)
        {
            Health health = coll.collider.GetComponent<Health>();
            if (health != null)
                health.TakeDamage(2, gameObject);
        }        
    }
    public void ShootArrow(Vector3 dir)
    {
        GameObject arrow = Instantiate(prefabArrow, spawnPointArrow.transform.position, spawnPointArrow.transform.rotation);
        arrow.GetComponent<ArrowProjectile>().SetInit(force, dir);
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
}
