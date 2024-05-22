using Unity.FPS.Game;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    public float baseDamage = 2;
    public float damage = 2;
    private Rigidbody2D rb; // Referencia al Rigidbody2D
    private Vector2 velStart;

    bool colision = false;
    Collider2D col;

    private void Start()
    {
        Asigned();
    }
    private void OnEnable()
    {
        Asigned();
        rb.velocity = velStart;
    }
    void Asigned()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
    }
    public void SetInit(float force, Vector3 dir, float valueDamage, Transform spawnPoint)
    {
        Asigned();
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.rotation;     
        Vector2 launchVelocity = dir * force;
        // Aplicar la fuerza inicial al Rigidbody2D
        SetStartArrow(launchVelocity);
        damage = baseDamage + valueDamage;
    }
    private void Update()
    {
        // Orientar la flecha en la dirección de su velocidad
        if (!colision && rb.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChildrenController.MakeSonOfFather(collision.gameObject, gameObject, true);

        Health health = collision.gameObject.GetComponent<Health>();
        if(health != null)
            health.TakeDamage(damage, gameObject);

        SetCollisionArrow();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //rb.simulated = true;
    }    

    void SetCollisionArrow()
    {
        colision = true;
        rb.velocity = Vector2.zero;
        rb.simulated = false;
        col.enabled = false;
        transform.parent = null;
    }
    void SetStartArrow(Vector2 vel)
    {
        colision = false;        
        rb.simulated = true;
        rb.velocity = vel;
        col.enabled = true;
        velStart = vel;
    }
}
