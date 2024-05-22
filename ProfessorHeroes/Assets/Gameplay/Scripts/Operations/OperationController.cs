using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class OperationController : MonoBehaviour
{
    public string level;
    public bool op = false;
    public bool re = false;
    public int Correctas = 0;
    public int Incorrectas = 0;
    public OperationSpawner operationSpawner;
    public Result result;
    public Operation operation;
    public UIController UI;
    public GameConfig gameConfig;    
    public AudioClip sfxOperacionIncorrecta;
    public AudioClip sfxOperacionCorrecta;    
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
        AudioManager.Instance.PlayOnShot(sfxOperacionCorrecta);
        result.SetMark();
        operation.SetMark();
        op = false;
        re = false;
        result.gameObject.SetActive(false);
        operation.gameObject.SetActive(false);
        Correctas++;
                  
    }    
    void Incorrecto()
    {
        AudioManager.Instance.PlayOnShot(sfxOperacionIncorrecta);
        Incorrectas++;
        //UI.txtIncorrectas.text = Incorrectas.ToString();
        result.SetMark();
        operation.SetMark();
        op = false;
        re = false;        
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
    
}
