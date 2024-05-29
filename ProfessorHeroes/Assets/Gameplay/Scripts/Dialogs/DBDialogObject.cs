using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New DB Dialog", menuName = "TIRIKA/P1/New DB Dialog")]
public class DBDialogObject : DataBaseObject
{
    
    [ContextMenu("Load Dialog")]
    public void LoadDialog()
    {
        for (int i = 0; i < objs.Count; i++)
        {            
            //DialogObject o = (DialogObject)objs[i];
            //TODO cargar los dialogos de una archivo excel 
        }
    }

}
