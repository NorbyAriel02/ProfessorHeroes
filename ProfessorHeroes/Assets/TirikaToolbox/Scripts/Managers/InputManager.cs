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
    }
    void OnDisable()
    {
        controles.Disable();
    }        
}
