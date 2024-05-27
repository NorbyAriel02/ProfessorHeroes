using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressSystem : MonoBehaviour
{
    public List<GoalObject> goalObjects;
    private void OnEnable()
    {
        PickupGoal.OnGetGoal += OnGetGoal;
    }
    private void OnDisable()
    {
        PickupGoal.OnGetGoal -= OnGetGoal;
    }
    private void Start()
    {
        if (!goalObjects[0].isAvailable)
        {
            goalObjects[0].isAvailable = true;            
        }
        
        foreach (var goalObject in goalObjects)
        {
            if(goalObject.isAvailable && !goalObject.isFinished)
                SpawnedObject(goalObject);
        }
    }

    public void OnGetGoal(GoalObject goal)
    {
        CompleteGoal(goal);
        if (goalObjects.Count > (goal.Index+1))
        {
            goalObjects[goal.Index + 1].isAvailable = true;
            SpawnedObject(goalObjects[goal.Index + 1]);
        }
    }
    public void CompleteGoal(GoalObject goal)
    {
        goal.isFinished = true;
    }
    public void SpawnedObject(GoalObject goal)
    {
        if (goal.PickupObject != null)
            Instantiate(goal.PickupObject.prefab, goal.PickupObject.spawnPosition, goal.PickupObject.spawnRotation);
    }
}
