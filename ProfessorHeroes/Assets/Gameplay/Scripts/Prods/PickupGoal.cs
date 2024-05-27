using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupGoal : MonoBehaviour
{
    public GoalObject goal;
    public static UnityAction<GoalObject> OnGetGoal;
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {        
        if(!goal.isFinished)
        {
            Debug.Log(goal.name);
            OnGetGoal?.Invoke(goal);
        }        
        gameObject.SetActive(false);
    }
}
