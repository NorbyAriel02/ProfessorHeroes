using UnityEngine.InputSystem;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    private Controlles controles;
    private Animator animator;
    PlayerCombat playerCombat;
    private void Awake()
    {
        playerCombat = GetComponent<PlayerCombat>();
        controles = new();
        animator = GetComponent<Animator>();
        if (animator == null)
            animator = GetComponentInChildren<Animator>();        
    }
    private void OnEnable()
    {
        controles.Enable();
        controles.Base.Weapon1.started += Weapon1;
        controles.Base.Weapon2.started += Weapon2;
        controles.Base.Weapon3.started += Weapon3;
        controles.Base.Weapon4.started += Weapon4;
    }
    private void OnDisable()
    {
        controles.Disable();
        controles.Base.Weapon1.started -= Weapon1;
        controles.Base.Weapon2.started -= Weapon2;
        controles.Base.Weapon3.started -= Weapon3;
        controles.Base.Weapon4.started -= Weapon4;
    }
    public void Weapon1(InputAction.CallbackContext callbackContext)
    {
        SetLayer(1);
        playerCombat.SetArcher();
    }
    public void Weapon2(InputAction.CallbackContext callbackContext)
    {
        SetLayer(2);
    }
    public void Weapon3(InputAction.CallbackContext callbackContext)
    {
        SetLayer(3);
        playerCombat.SetMelee();
    }
    public void Weapon4(InputAction.CallbackContext callbackContext)
    {
        SetLayer(4);
        playerCombat.SetMelee();
    }

    void SetLayer(int layer)
    {
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
