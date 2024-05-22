using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public InputAction sprintAction;
    public Controlles controles;
    public UnityAction OnPressSprint;
    public UnityAction OnHoldSprint;
    public UnityAction OnCancelSprint;

    private bool isRunning;
    private float timer;
    private float sprintDuration;

    private void Awake()
    {
        if (InputManager.Instance == null)
        {
            InputManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        controles = new();
    }

    private void OnEnable()
    {
        controles.Enable();
        controles.Base.Sprint.started += OnAtiveSprint;
        controles.Base.Sprint.performed += OnAtiveSprint;
        controles.Base.Sprint.canceled += OnAtiveSprint;        
    }
    void OnDisable()
    {
        controles.Base.Sprint.started -= OnAtiveSprint;
        controles.Base.Sprint.performed -= OnAtiveSprint;
        controles.Base.Sprint.canceled -= OnAtiveSprint;
        controles.Disable();
    }
    private void Start()
    {
        timer = PlayerStats.Instance.SprintDuration;
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

        sprintDuration = Mathf.Clamp(timer, 0, PlayerStats.Instance.SprintDuration);        
    }
    public float GetSpritDurationNormalize()
    {
        return sprintDuration / PlayerStats.Instance.SprintDuration;
    }
    private void OnAtiveSprint(InputAction.CallbackContext context)
    {
        var holdInteraction = context.interaction as HoldInteraction;
        if (context.started)
        {            
            holdInteraction.duration = sprintDuration;
            timer = sprintDuration;
            isRunning = true;            
            OnPressSprint?.Invoke();
        }
        if(context.performed)
        {
            isRunning = false;
            OnHoldSprint?.Invoke();
        }
        if(context.canceled)
        {            
            isRunning = false;
            OnCancelSprint?.Invoke();
        }
    }
    
}
