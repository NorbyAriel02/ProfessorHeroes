using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

//Wave Function Collapse
public class PlayerMove : MonoBehaviour
{        
    public float moveSmooth = 0.1f;    
    
    private float moveHorizontal = 0;
    private Rigidbody2D rb;
    private Vector3 speed = Vector3.zero;
    private bool seeRight = true;

    [Header("Jump")]
    public float jumpForze = 100.0f;
    public LayerMask WahtIsGroundMask;
    public Transform boxController;
    public Vector3 boxSize;
    public bool isGround;
    public bool inputJump = false;
    public float[] IntencityFall;
    
    [Header("Particles")]
    public ParticleSystem particleRun;
    public ParticleSystem particleJump;

    [Header("SFX")]
    public AudioClip sfxJump;
    public AudioClip sfxSoftFall;
    public AudioClip sfxHardFall;
    public UnityAction<Vector3> OnMove;

    [Header("Animation")]
    private Animator animator;
    public Vector2 direccion;
        
    private float currectSpeed = 0f;    
    private float timer;
    private void Awake()
    {
        
    }
    private void OnEnable()
    {        
        InputManager.Instance.controles.Base.Jump.started += Jump;
        InputManager.Instance.OnPressSprint += StartSprint;
        InputManager.Instance.OnHoldSprint += EndSprint;
        InputManager.Instance.OnCancelSprint += EndSprint;
    }
    private void OnDisable()
    {        
        InputManager.Instance.controles.Base.Jump.started -= Jump;
        InputManager.Instance.OnPressSprint -= StartSprint;
        InputManager.Instance.OnHoldSprint -= EndSprint;
        InputManager.Instance.OnCancelSprint -= EndSprint;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        if(animator == null)
            animator = GetComponentInChildren<Animator>();
                
        currectSpeed = CalculeSpeed();
    }

    private void Update()
    {
        direccion = InputManager.Instance.controles.Base.Move.ReadValue<Vector2>();
        moveHorizontal = direccion.x * currectSpeed;

        animator.SetFloat("SpeedX", Mathf.Abs(moveHorizontal));        
        animator.SetFloat("SpeedY", rb.velocity.y);        
    }

    private void FixedUpdate()
    {
        if(!animator.GetBool("InCombat"))//si no esta en combate
        {
            isGround = Physics2D.OverlapBox(boxController.position, boxSize, 0, WahtIsGroundMask);
            animator.SetBool("InGround", isGround);
            Move(moveHorizontal * Time.fixedDeltaTime);            
        }
        else
            Move(0);
    }    
    private void Move(float move)
    {
        Vector3 vel = new Vector2(move, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, vel, ref speed, moveSmooth);
        
        if (move > 0 && !seeRight)
        {
            Turn();
        }
        else if (move < 0 && seeRight)
        {
            Turn();
        }                
    }
    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (isGround && !animator.GetBool("InCombat") && !animator.GetBool("Pickup") && !animator.GetBool("Takeit"))
        {
            isGround = false;
            rb.AddForce(new Vector2(0, jumpForze));
            AudioManager.Instance.PlayOnShot(sfxJump);            
        }
        
        if (rb.velocity.y < 0)
        {
            particleJump.Stop();
        }
    }
    private void Turn()
    {
        seeRight = !seeRight;
        if(seeRight)
            transform.eulerAngles = Vector3.zero;
        else
            transform.eulerAngles = new Vector3(0,180,0);
    }
    private void StartSprint()
    {   
        //Si lleva carga no puede correr
        if (animator.GetBool("Pickup") || animator.GetBool("Takeit"))
            return;

        //Si esta en el aire no puede correr
        if (!animator.GetBool("InGround"))
            return;

        animator.SetBool("Sprint", true);
        currectSpeed = CalculeSpeed();
    }
    public void EndSprint()
    {
        animator.SetBool("Sprint", false);
        currectSpeed = CalculeSpeed();
    }
    public void ParticleJumpStart()
    {
        if(!particleJump.isPlaying && Mathf.Abs(rb.velocity.x) > 1 && rb.velocity.y > 1)
            particleJump.Play();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxController.position, boxSize);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LayerMask mask = LayerMask.GetMask("ground");        
        if (!particleRun.isPlaying && collision.gameObject.layer == 6)
        {
            Vector3 impactVelocity = collision.relativeVelocity;
            float magnitude = Mathf.Max(0f, impactVelocity.magnitude);            
            
            if (magnitude > IntencityFall[0] && magnitude < IntencityFall[1])
                SoftFall();
            
            if (magnitude > IntencityFall[1])
                HardFall();
        }            
    }
    private void SoftFall()
    {
        particleRun.Play();
        AudioManager.Instance.PlayOnShot(sfxSoftFall);
    }
    private void HardFall()
    {
        particleRun.Play();
        AudioManager.Instance.PlayOnShot(sfxHardFall);
    }
    private float CalculeSpeed()
    {

        if (animator.GetBool("Sprint"))
            currectSpeed = PlayerStats.Instance.Sprint.B + MathHelper.GetY(PlayerStats.Instance.Sprint);
        else
            currectSpeed = PlayerStats.Instance.Sprint.B;

        return currectSpeed;
    }
}
