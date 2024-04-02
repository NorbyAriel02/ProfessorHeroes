using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class OperationController : MonoBehaviour
{
    public string level;
    public bool op = false;
    public bool re = false;
    public OperationSpawner operationSpawner;
    public Result result;
    public Operation operation;
    public UIController UI;
    public GameConfig gameConfig;
    private GoogleSheetsAPIForUnity Sheet;

    private void OnEnable()
    {
        Time.timeScale = 1;        
    }
    private void Start()
    {
        Sheet = new GoogleSheetsAPIForUnity(gameConfig);
    }
    private void LateUpdate()
    {
        if (operationSpawner == null || operationSpawner.OperationVsResult == null)
            return;

        if (op && re)
        {
            if (operationSpawner.OperationVsResult[result] == operation)
                Correcto();
            else
                Incorrecto();
        }
    }
    void Correcto()
    {
        result.SetMark();
        operation.SetMark();
        op = false;
        re = false;
        result.gameObject.SetActive(false);
        operation.gameObject.SetActive(false);
        
        if(IsWin())
        {            
            UI.ShowWin();
            UpdateScoreTable();
        }            
    }    
    void Incorrecto()
    {
        result.SetMark();
        operation.SetMark();
        op = false;
        re = false;
        UI.ShowError();
    }
    bool IsWin()
    {
        foreach(Result result in operationSpawner.OperationVsResult.Keys)
        {
            if(result.isActiveAndEnabled)
            {
                return false;
            }
        }
        return true;
    }
    void UpdateScoreTable()
    {
        List<Record> records = Sheet.ReadDataRecords(gameConfig.readRange);
        Record record = new Record();
        Row updateRow = new Row();
        record.level = level;
        record.usename = PlayerPrefs.GetString("PlayerName");
        float.TryParse(UI.txtTimer.text, out record.timer);
        records.Add(record);

        records.Sort((x, y) => x.timer.CompareTo(y.timer));

        if (records.Count > 10)
        {
            records.RemoveAt(10);
        }

        Sheet.UpdateDataRecords(gameConfig.readRange, records);
    }
}
