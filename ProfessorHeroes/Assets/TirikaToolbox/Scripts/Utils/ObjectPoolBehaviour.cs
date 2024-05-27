using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolBehaviour : MonoBehaviour
{
    public ObjectPoolData[] data;
    private List<List<GameObject>> pooledObjects;
    void Awake()
    {
        CreatePool();
    }
    public void CreatePool()
    {
        pooledObjects = new List<List<GameObject>>();
        foreach (var goType in data)
        {
            List<GameObject> subList = new List<GameObject>();
            for (int i = 0; i < goType.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(goType.objectToPool);
                obj.SetActive(false);
                subList.Add(obj);
            }
            goType.Index = pooledObjects.Count;
            pooledObjects.Add(subList);
        }
    }

    public GameObject GetPooledObject(int index)
    {
        List<GameObject> subList = pooledObjects[index];
        for (int i = 0; i < subList.Count; i++)
        {            
            if (!subList[i].activeInHierarchy)
            {
                return subList[i];
            }
        }

        if (data[index].shouldExpand)
        {
            GameObject obj = (GameObject)Instantiate(data[index].objectToPool);
            obj.SetActive(false);
            subList.Add(obj);
            return obj;
        }
       
        return null;        
    }

}