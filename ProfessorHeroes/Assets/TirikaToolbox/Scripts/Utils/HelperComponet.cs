using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperComponet : MonoBehaviour
{
    public static T GetComponentInHierarchy<T>(Transform obj) where T : Component
    {     
        T comp = obj.GetComponent<T>();
        if (comp == null)
        {
            comp = GetComponentInHierarchy<T>(obj.parent);
        }
        return comp;
    }
    public static T GetComponentInChild<T>(Transform obj) where T : Component
    {
        T comp = obj.GetComponent<T>();
        if (comp == null)
        {
            GameObject[] children = ChildrenController.GetChildren(obj.gameObject);
            foreach (GameObject child in children)
            {
                comp = GetComponentInChild<T>(child.transform);
                if (comp != null)
                    break;
            }            
        }
        return comp;
    }
}
