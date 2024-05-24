using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }
    [Header("Estadisticas")]
    public AttributeObject fuerza;
    public AttributeObject forma;
    public AttributeObject dexBow;
    public AttributeObject dexSword;
    [SerializeField] private LinealFunction lfSprint;
    [SerializeField] private LinealFunction lfSword;
    [SerializeField] private LinealFunction lfBow;
    [SerializeField] private LinealFunction lfJump;
    public UnityAction OnPressSprint;
    public UnityAction OnHoldSprint;
    public UnityAction OnCancelSprint;

    private bool isRunning;
    private float timer;
    private float sprintDuration;
    void OnEnable()
    {
        if (PlayerStats.Instance == null)
        {
            PlayerStats.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);
        InputManager.Instance.controles.Enable();
        InputManager.Instance.controles.Base.Sprint.started += OnAtiveSprint;
        InputManager.Instance.controles.Base.Sprint.performed += OnAtiveSprint;
        InputManager.Instance.controles.Base.Sprint.canceled += OnAtiveSprint;
    }
    void OnDisable()
    {
        InputManager.Instance.controles.Base.Sprint.started -= OnAtiveSprint;
        InputManager.Instance.controles.Base.Sprint.performed -= OnAtiveSprint;
        InputManager.Instance.controles.Base.Sprint.canceled -= OnAtiveSprint;
    }
    public LinealFunction Sprint
    { 
        get 
        {
            lfSprint.X = forma.value;
            return lfSprint; 
        } 
    }
    public LinealFunction Jump
    {
        get
        {
            lfJump.X = fuerza.value + forma.value;
            return lfJump;
        }
    }
    public LinealFunction Sword
    {
        get
        {
            lfSword.X = dexSword.value;
            return lfSword;
        }
    }
    public LinealFunction Bow
    {
        get
        {
            lfBow.X = dexBow.value;
            return lfBow;
        }
    }
    public float SprintDuration
    {
        get
        {
            //la formula para calcular la duracion del sprint
            //no la velocidad del sprint Ariel
            return 2 + lfSprint.M * forma.value;
        }
    }   
    
    private void Start()
    {
        timer = SprintDuration;
    }
    private void FixedUpdate()
    {
        UpdateSprintDuration();
    }
    //actualizamo la cantidad de tiempo que puede sprintear
    //valores entre 0 y la max duracion que depende del valor
    //del per forma del personaje
    private void UpdateSprintDuration()
    {
        if (isRunning)
            timer -= Time.fixedDeltaTime;
        else
            timer += Time.fixedDeltaTime / 10;

        sprintDuration = Mathf.Clamp(timer, 0, SprintDuration);
    }
    public float GetSpritDurationNormalize()
    {
        return sprintDuration / SprintDuration;
    }
    private void OnAtiveSprint(InputAction.CallbackContext context)
    {
        var holdInteraction = context.interaction as HoldInteraction;
        if (context.started)
        {
            print("Sprint " + sprintDuration);
            holdInteraction.duration = sprintDuration;
            timer = sprintDuration;
            isRunning = true;
            OnPressSprint?.Invoke();
        }
        if (context.performed)
        {
            isRunning = false;
            OnHoldSprint?.Invoke();
        }
        if (context.canceled)
        {
            isRunning = false;
            OnCancelSprint?.Invoke();
        }
    }
}
