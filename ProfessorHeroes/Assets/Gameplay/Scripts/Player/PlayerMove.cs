using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

//Wave Function Collapse
public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float moveSpeedSprint = 2.0f;
    public float SprintDuration = 2.0f;
    public float moveSmooth = 0.1f;
    private float moveHorizontal = 0;
    private Rigidbody2D rb;
    private Vector3 speed = Vector3.zero;
    private bool seeRight = true;
    //private float coyoteTime = 0;

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
    private Controlles controles;
    private float currectSpeed = 0f;
    private void Awake()
    {
        controles = new();
    }
    private void OnEnable()
    {
        controles.Enable();
        controles.Base.Jump.started += Jump;
        controles.Base.Sprint.started += Sprint;
        controles.Base.Sprint.performed += Sprint;
        controles.Base.Sprint.canceled += Sprint;
    }
    private void OnDisable()
    {
        controles.Disable();
        controles.Base.Jump.started -= Jump;
        controles.Base.Sprint.started -= Sprint;
        controles.Base.Sprint.performed -= Sprint;
        controles.Base.Sprint.canceled -= Sprint;
        
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        if(animator == null)
            animator = GetComponentInChildren<Animator>();
        
        currectSpeed = moveSpeed;
    }

    private void Update()
    {
        direccion = controles.Base.Move.ReadValue<Vector2>();
        moveHorizontal = direccion.x * currectSpeed;

        animator.SetFloat("SpeedX", Mathf.Abs(moveHorizontal));        
        animator.SetFloat("SpeedY", rb.velocity.y);
        
        if(Input.GetButtonDown("Jump"))
        {
            inputJump = true;            
        }
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
        if (isGround && !animator.GetBool("InCombat"))
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
    void Sprint(InputAction.CallbackContext context)
    {
        var holdInteraction = context.interaction as HoldInteraction;
        holdInteraction.duration = SprintDuration;
        if (context.started)
        {
            currectSpeed = moveSpeedSprint;
            animator.SetBool("Sprint", true);
        }
        
        if(context.performed || context.canceled)
        {
            currectSpeed = moveSpeed;
            animator.SetBool("Sprint", false);
        }
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

    void SoftFall()
    {
        particleRun.Play();
        AudioManager.Instance.PlayOnShot(sfxSoftFall);
    }
    void HardFall()
    {
        particleRun.Play();
        AudioManager.Instance.PlayOnShot(sfxHardFall);
    }
}
