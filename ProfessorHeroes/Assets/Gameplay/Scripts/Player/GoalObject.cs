using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new GoalObject", menuName = "TIRIKA/P1/GoalObject", order = 2)]
public class GoalObject : GenericObject
{
    public bool isAvailable;
    public bool inProgress;
    public bool isFinished;    
    public SpawnableObjeto PickupObject;
    [ContextMenu("Reset value")]
    public void ResetValues()
    {
        isAvailable = false;
        inProgress = false;
        isFinished = false;
    }
}

