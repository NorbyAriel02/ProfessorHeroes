using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Events;

public class BowAttack : StateMachineBehaviour
{
    public string GameTagName;    
    public Texture2D cursorBow;    
    public static UnityAction<Vector3> OnShoot;
    private GameObject bow;
    private GameObject bowView;
    GameObject bowChild;
    private void Awake()
    {
        
        
    }
    void AssigGO(GameObject go)
    {
        List<GameObject> list = ChildrenController.GetListChildren(go);
        foreach (GameObject child in list)
        {
            if (child.name.Equals("ViewBowAttack"))
                bowView = child;

            if (child.name.Equals("PivotBowPosAttack"))
                bow = child;
        }        

        bowChild = ChildrenController.GetChild(bow);
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetLayerWeight(1) != 1)
            return;

        AssigGO(animator.gameObject);
        animator.SetBool("InCombat", true);
        bow.SetActive(true);
        bowView.SetActive(true);

        Cursor.SetCursor(cursorBow, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetLayerWeight(1) != 1)
            return;

        AssigGO(animator.gameObject);
        animator.SetBool("InCombat", false);
        //se calcula la direccion de la flecha
        Vector3 dir = (bowChild.transform.position - bow.transform.position).normalized;
        bow.SetActive(false);
        bowView.SetActive(false);
        Cursor.visible = false;
        if (!animator.GetBool("CanceledAttack"))
            OnShoot?.Invoke(dir);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
