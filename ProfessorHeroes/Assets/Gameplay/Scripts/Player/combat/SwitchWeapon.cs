using UnityEngine.InputSystem;
using UnityEngine;
public enum AnimatorLayers
{
    Base = 0,
    Arco = 1,
    Antorcha = 2,
    Espada = 3,
    Escudo = 4
}
public class SwitchWeapon : MonoBehaviour
{
    public bool isLayerBase = true;    
    private Animator animator;
    PlayerCombat playerCombat;
    private void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
        
        animator = GetComponent<Animator>();
        if (animator == null)
            animator = GetComponentInChildren<Animator>();
        
    }
    private void OnEnable()
    {        
        InputManager.Instance.controles.Base.Weapon1.started += Weapon1;
        InputManager.Instance.controles.Base.Weapon2.started += Weapon2;
        InputManager.Instance.controles.Base.Weapon3.started += Weapon3;
        InputManager.Instance.controles.Base.Weapon4.started += Weapon4;
    }
    private void OnDisable()
    {        
        InputManager.Instance.controles.Base.Weapon1.started -= Weapon1;
        InputManager.Instance.controles.Base.Weapon2.started -= Weapon2;
        InputManager.Instance.controles.Base.Weapon3.started -= Weapon3;
        InputManager.Instance.controles.Base.Weapon4.started -= Weapon4;
    }
    public void Weapon1(InputAction.CallbackContext callbackContext)
    {
        SetLayer((int)AnimatorLayers.Arco);
        playerCombat.SetArcher();
    }
    public void Weapon2(InputAction.CallbackContext callbackContext)
    {
        SetLayer((int)AnimatorLayers.Antorcha);
    }
    public void Weapon3(InputAction.CallbackContext callbackContext)
    {
        SetLayer((int)AnimatorLayers.Espada);
        playerCombat.SetMelee();
    }
    public void Weapon4(InputAction.CallbackContext callbackContext)
    {
        SetLayer((int)AnimatorLayers.Escudo);
        playerCombat.SetMelee();
    }

    public void SetLayer(int layer)
    {
        if(layer > 0)
            isLayerBase = false;
        else
            isLayerBase = true;

        //chequeo que si tiene una carga no puede equipar un arma
        if (animator.GetBool("Pickup") || animator.GetBool("Takeit"))
            return;

        float WeightValue = animator.GetLayerWeight(layer);
        if(WeightValue == 1)
            WeightValue = 0f;
        else
            WeightValue = 1f;

        for (int i = 0; i < animator.layerCount; i++)
        {
            if (i == layer)
                animator.SetLayerWeight(layer, WeightValue);
            else
                animator.SetLayerWeight(i, 0);
        }
    }
}
