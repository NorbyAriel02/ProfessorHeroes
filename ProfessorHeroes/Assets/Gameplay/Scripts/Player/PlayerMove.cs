using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;
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
    public bool jump = false;
    
    [Header("Particles")]
    public ParticleSystem particleRun;
    public ParticleSystem particleJump;

    [Header("SFX")]
    public AudioClip sfxJump;
    public AudioClip sfxFall;
    public AudioMixerGroup mixerGroup;
    private AudioSource sfxSoundJump;
    private AudioSource sfxSoundFall;
    [Header("Animation")]
    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sfxSoundJump = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
        sfxSoundJump.clip = sfxJump;
        sfxSoundJump.outputAudioMixerGroup = mixerGroup;
        sfxSoundFall = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
        sfxSoundFall.clip = sfxFall;
        sfxSoundFall.outputAudioMixerGroup = mixerGroup;
    }

    private void Update()
    {        
        moveHorizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        animator.SetFloat("SpeedX", Mathf.Abs(moveHorizontal));
        animator.SetFloat("SpeedY", rb.velocity.y);
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;            
        }
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapBox(boxController.position, boxSize, 0, WahtIsGroundMask);
        animator.SetBool("inGround", isGround);
        Move(moveHorizontal * Time.fixedDeltaTime, jump);
        jump = false;
        if(rb.velocity.y < 0)
        { 
            particleJump.Stop();
        }
    }

    private void Move(float move, bool jumping)
    {
        Vector3 vel = new Vector2(move, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, vel, ref speed, moveSmooth);
        
        //if(!particleRun.isPlaying && isGround && Mathf.Abs(rb.velocity.x) > 7 && Mathf.Abs(rb.velocity.y) <= 0.5)
        //{
        //    particleRun.Play();
        //}            
        
        if (move > 0 && !seeRight)
        {
            Turn();
        }
        else if (move < 0 && seeRight)
        {
            Turn();
        }

        if (isGround && jumping)
        {
            isGround = false;
            rb.AddForce(new Vector2(0, jumpForze));
            sfxSoundJump.Play();
            //if (!sfxSound.isPlaying)
            //{
            //    sfxSound.PlayOneShot(sfxJump);
            //}
        }        
    }

    private void Turn()
    {
        seeRight = !seeRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;        
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
        if (!particleRun.isPlaying && collision.gameObject.layer == 6 && rb.velocity.y <= 0)
        {
            particleRun.Play();            
            //sfxSound.PlayOneShot(sfxFall);
            sfxSoundFall.Play();
        }            
    }
}
