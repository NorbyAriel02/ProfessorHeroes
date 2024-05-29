using UnityEngine;

[CreateAssetMenu(fileName = "New DB Goal Object", menuName = "TIRIKA/P1/DBGoalObject")]
public class DBGoalObject : DataBaseObject
{
    [ContextMenu("Reset Item value xx")]
    public void ResetItemValues()
    {
        for (int i = 0; i < objs.Count; i++)
        {
            GoalObject o = (GoalObject)objs[i];
            o.ResetValues();
        }
    }
}
