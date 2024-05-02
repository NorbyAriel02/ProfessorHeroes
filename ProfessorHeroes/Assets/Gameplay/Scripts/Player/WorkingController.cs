using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.InputSystem;

public class WorkingController : MonoBehaviour
{
    public Transform pickup;
    public Transform carryIt;
    public Vector2 boxSize;
    private Controlles controles;
    private Animator animator;
    PlayerCombat playerCombat;
    private bool isPickup;
    private bool isTakeit;
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
        controles.Base.Pickup.started += Pickup;
        controles.Base.Takeit.started += Takeit;        
    }
    private void OnDisable()
    {
        controles.Disable();
        controles.Base.Pickup.started -= Pickup;
        controles.Base.Takeit.started -= Takeit;
    }

    public void Pickup(InputAction.CallbackContext callbackContext)
    {
        if (animator.GetFloat("SpeedX") > 0)
            return;

        if (!isPickup)
            ActionPickup(pickup, ref isPickup);
        else
            Release(pickup, ref isPickup);

        animator.SetBool("Pickup", isPickup);
    }
    public void Takeit(InputAction.CallbackContext callbackContext)
    {
        if (animator.GetFloat("SpeedX") > 0)
            return;

        if (!isTakeit)
            ActionPickup(carryIt, ref isTakeit);
        else
            Release(carryIt, ref isTakeit);

        animator.SetBool("Takeit", isTakeit);
    }

    void ActionPickup(Transform father, ref bool action)
    {
        RaycastHit2D[] golpeados = Physics2D.BoxCastAll(pickup.position, boxSize, 0, Vector2.zero, 1);
        foreach (RaycastHit2D coll in golpeados)
        {            
            Pickable pickable = coll.collider.GetComponent<Pickable>();
            if (pickable != null)
            {
                pickable.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                ChildrenController.MakeSonOfFather(father.gameObject, pickable.gameObject, Vector3.zero);
                action = true;
            }                
        }                
    }
    void Release(Transform father, ref bool action)
    {
        action = false;
        GameObject child = ChildrenController.GetChild(father.gameObject);
        if(child != null)
        {
            child.GetComponent<Rigidbody2D>().simulated = true;
            child.transform.parent = null;
        }            
    }
}
