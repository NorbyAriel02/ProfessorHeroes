using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressSystem : MonoBehaviour
{
    public DBGoalObject goals;
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
        GoalObject firstGoal = (GoalObject)goals.objs[0];
        if (!firstGoal.isAvailable)
        {
            firstGoal.isAvailable = true;            
        }
        
        foreach (var genericObject in goals.objs)
        {
            GoalObject goalObject = genericObject as GoalObject;
            if(goalObject.isAvailable && !goalObject.isFinished)
                SpawnedObject(goalObject);
        }
    }

    public void OnGetGoal(GoalObject goal)
    {
        CompleteGoal(goal);
        if (goals.objs.Count > (goal.Index + 1))
        {
            GoalObject nextGoal = goals.objs[goal.Index + 1] as GoalObject;
            nextGoal.isAvailable = true;
            SpawnedObject(nextGoal);
        }
    }
    public void CompleteGoal(GoalObject goal)
    {
        goal.isFinished = true;
    }
    public void SpawnedObject(GoalObject goal)
    {
        Debug.Log("spawned " + goal.name);
        if (goal.PickupObject != null)
            Instantiate(goal.PickupObject.prefab, goal.PickupObject.spawnPosition, goal.PickupObject.spawnRotation);
    }
}
