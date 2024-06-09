//using System.Diagnostics;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

//Wave Function Collapse
public class PlayerMove : MonoBehaviour
{        
    public float moveSmooth = 0.1f;    
    public float aceleration = 0.5f;
    public float InitialVelx = 3;
    public float maxSpeedX = 4;    
    private float moveHorizontal = 0;
    private Rigidbody2D rb;
    private Vector3 speed = Vector3.zero;
    private bool seeRight = true;

    [Header("Jump")]    
    public LayerMask WhatIsGroundMask;
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

    private float maxVel;
    private float timer;
    private void Awake()
    {
        
    }
    private void OnEnable()
    {        
        InputManager.Instance.controles.Base.Jump.started += Jump;
        PlayerStats.Instance.OnPressSprint += StartSprint;
        PlayerStats.Instance.OnHoldSprint += EndSprint;
        PlayerStats.Instance.OnCancelSprint += EndSprint;
    }
    private void OnDisable()
    {        
        InputManager.Instance.controles.Base.Jump.started -= Jump;
        PlayerStats.Instance.OnPressSprint -= StartSprint;
        PlayerStats.Instance.OnHoldSprint -= EndSprint;
        PlayerStats.Instance.OnCancelSprint -= EndSprint;
    }   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        if(animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        direccion = InputManager.Instance.controles.Base.Move.ReadValue<Vector2>();
        //moveHorizontal = direccion.x * currectSpeed;
        
        
    }
    void CaluleAnimationSpeed()
    {
        float porcentajeVel = (rb.velocity.x * 100) / maxVel;
        float xx = (porcentajeVel * maxSpeedX) / 100;
        #region coment
        //Comvierto el valor a entero
        //para evitar las pequeñas variaciones
        //que pueden activar la animacion
        //tambien mantendo el valor en un
        //numero maximo para que al multiplicarlo
        //por la vel de la animacion esta no sea muy alta
        #endregion
        float x = Mathf.Clamp(Mathf.Abs(Convert.ToInt32(xx)), 0, maxSpeedX);
        animator.SetFloat("SpeedX", x);
        animator.SetFloat("SpeedY", rb.velocity.y);
    }
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapBox(boxController.position, boxSize, 0, WhatIsGroundMask);
        if (!animator.GetBool("InCombat"))//si no esta en combate
        {            
            animator.SetBool("InGround", isGround);
            Move(direccion.x);
        }
        else
            Move(0);

        CaluleAnimationSpeed();
    }
    float t = 0;
    private void Move(float dir)
    {        
        Vector3 vel = new Vector2(CalculeSpeed(dir), rb.velocity.y);

        rb.velocity = Vector3.SmoothDamp(rb.velocity, vel, ref speed, moveSmooth);
        if (dir > 0 && !seeRight)
        {
            Turn();
        }
        else if (dir < 0 && seeRight)
        {
            Turn();
        }                
    }
    public void Jump(InputAction.CallbackContext callbackContext)
    {
        float jumpForze = MathHelper.GetY(PlayerStats.Instance.Jump);         
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
    }
    public void EndSprint()
    {
        animator.SetBool("Sprint", false);        
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
    private float CalculeSpeed(float dir)
    {        
        if (animator.GetBool("Sprint"))
            maxVel = PlayerStats.Instance.Sprint.B + MathHelper.GetY(PlayerStats.Instance.Sprint);
        else
            maxVel = PlayerStats.Instance.Sprint.B;
        
        float velx = 0;
        if (dir != 0)
        {
            t += Time.fixedDeltaTime;
            velx = Mathf.Clamp((InitialVelx) + 0.5f * (aceleration) * (t * t), 0, maxVel);
            velx = velx * dir;
        }
        else
        {
            velx = 0;
            t = 0;
        }

        return velx;
    }
}
