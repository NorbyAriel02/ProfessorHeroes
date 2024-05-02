using Unity.FPS.Game;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    public float initialSpeed = 10f; // Velocidad inicial de la flecha
    public float angle = 45f; // Ángulo de lanzamiento de la flecha
    public float damage = 2;
    private Rigidbody2D rb; // Referencia al Rigidbody2D

    bool colision = false;
    Collider2D col;

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        
    }
    public void SetInit(float force, Vector3 dir)
    {
        col = GetComponent<Collider2D>();
        // Obtener o añadir el componente Rigidbody2D al objeto
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        // Calcular la velocidad inicial en base al ángulo de lanzamiento y la velocidad inicial
        float angleRad = Mathf.Deg2Rad * angle;        
        Vector2 launchVelocity = dir * force;// new Vector2(-initialSpeed * Mathf.Cos(angleRad), initialSpeed * Mathf.Sin(angleRad));
        
        // Aplicar la fuerza inicial al Rigidbody2D
        rb.velocity = launchVelocity;
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
    }
}
