using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.HDROutputUtils;

public enum Operaciones { suma, resta, division, multiplicacion }
public class OperationSpawner : MonoBehaviour
{
    public int operations = 3;
    public GameObject spawn;
    public GameObject operationPrefab;
    public GameObject resultPrefab;
    public List<GameObject> spawnPositionList;
    public Dictionary<Result, Operation> OperationVsResult;
    public OperationController controller;
    private List<int> spawnPositionUsed = new List<int>();
    private List<int> resultList = new List<int>();
    private void OnEnable()
    {
        OperationVsResult = new Dictionary<Result, Operation>();
    }
    void Start()
    {
        GameObject spawnObj = Instantiate(spawn);
        spawnPositionList = ChildrenController.GetListChildren(spawnObj);
        for (int i = 0; i < operations; i++)
        {
            CreatePair();
        }
    }
    Transform GetRamdomPosition()
    {
        int index = 0;
        while (!IsAviableIndex(index))
            index = Random.Range(0, spawnPositionList.Count);

        spawnPositionUsed.Add(index);

        return spawnPositionList[index].transform;
    }

    bool IsAviableIndex(int index)
    {
        foreach (var item in spawnPositionUsed)
        {
            if (item == index) return false;
        }

        return true;
    }

    Result SetResult(int value)
    {        
        GameObject goResult = CreateObject(resultPrefab);        
        Result result = goResult.GetComponentInChildren<Result>();
        result.SetValue(value);

        return result;
    }

    Operation SetOperation(int v1, int v2, Operaciones op)
    {        
        GameObject operationObj = CreateObject(operationPrefab);
        Operation operation = operationObj.GetComponentInChildren<Operation>();
        
        if (op == Operaciones.resta)
            operation.SetText(v1 + "-" + v2, v1, v2);
        else
            operation.SetText(v1 + "+" + v2, v1, v2);

        return operation;
    }
    int[] GetRandomValues()
    {
        int valor1 = Random.Range(0, 11);
        int valor2 = Random.Range(0, 11);

        return new int[] { valor1, valor2 };
    }
    Operaciones GetOperacionRandom()
    {
        int a = Random.Range(0, 2);
        if (a == 0)
            return Operaciones.suma;
        
        if(a == 1)
            return Operaciones.resta;
                
        return Operaciones.suma;
    }
    int GetResult(int value1, int value2, Operaciones op)
    {
        if(op == Operaciones.suma)
            return value1 + value2;
        else
            return value1 - value2;
    }
    private void CreatePair()
    {
        while (true)
        {
            int[] values = GetRandomValues();
            Operaciones op = GetOperacionRandom();
            int iResult = GetResult(values[0], values[1], op);
            if (CheckResult(iResult))
            {
                Operation operation = SetOperation(values[0], values[1], op);
                Result result = SetResult(iResult);
                OperationVsResult.Add(result, operation);
                resultList.Add(iResult);
                break;
            }
        }
    }
    bool CheckResult(int result)
    {
        foreach(int r in resultList)
        {
            if(r == result)
                return false;
        }

        return true;
    }
    private GameObject CreateObject(GameObject obj)
    {
        Transform father = GetRamdomPosition();
        GameObject newObj = Instantiate(obj, father.position, obj.transform.rotation, father);
        newObj.SetActive(true);

        return newObj;
    }
}
