using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New DB Attributes", menuName = "TIRIKA/DBAttributes")]
public class DBAttributes : DataBaseObject
{
    [ContextMenu("Reset Item value")]
    public void ResetItemValue()
    {
        for (int i = 0; i < objs.Count; i++)
        {
            AttributeObject o = (AttributeObject)objs[i];
            o.ResetValue();
        }
    }
}
