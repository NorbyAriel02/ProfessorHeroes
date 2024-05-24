using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

[System.Serializable]
public class  PanelStat
{
    public AttributeObject attribute;
    public Button button;
    public TMP_Text text;
    public PanelStat()
    {

    }
}
public class StatController : MonoBehaviour
{
    public LevelSystemData levelData;
    public GameObject panel;
    public TMP_Text txtDisponibles;
    public List<PanelStat> stats;
    private Controlles controles;
    private void Awake()
    {
        controles = new();
    }
    private void OnEnable()
    {
        controles.Enable();
        LevelSystem.WhenLevelingUp += AddAvailablePoints;
        controles.Base.Stats.started += ShowPanelStats;
    }
    private void OnDisable()
    {
        controles.Disable();
        LevelSystem.WhenLevelingUp -= AddAvailablePoints;
        controles.Base.Stats.started -= ShowPanelStats;
    }
    void Start()
    {
        CheckButtonStatus();
        SetTextStats();
        txtDisponibles.text = "Disponibles: " + levelData.AvialablePoints;
    }
    void SetTextStats()
    {
        foreach (var item in stats)
        {
            item.text.text = item.attribute.value.ToString();
        }
    }
    void AddAvailablePoints(LevelSystemData data)
    {
        SetPointsAvailable(4);
    }
    public void AddStat(AttributeObject stat)
    {
        foreach (PanelStat panel in stats)
        {
            if(panel.attribute.Index == stat.Index)
            {
                panel.attribute.value += 1;
                panel.text.text = panel.attribute.value.ToString();
            }
        }        
        SubtractOnePoint();
        CheckButtonStatus();
    }
    void SubtractOnePoint()
    {
        levelData.AvialablePoints--;
        SetTextDisponibles();
    }
    void SetTextDisponibles()
    {
        txtDisponibles.text = "Disponibles: " + levelData.AvialablePoints;
    }
    void CheckButtonStatus()
    {
        if (levelData.AvialablePoints <= 0)
        {
            foreach (PanelStat panel in stats)
            {
                panel.button.interactable = false;
            }
            levelData.AvialablePoints = 0;
        }
    }        
    public void ShowHiddenPanel()
    {
        panel.SetActive(!panel.activeSelf);
        if(panel.activeSelf)
            Cursor.visible = true;
        else
            Cursor.visible = false;
    }
    public void SetPointsAvailable(int _pointsAvailable)
    {
        levelData.AvialablePoints += _pointsAvailable;
        ActiveButtons();
    }
    void ActiveButtons()
    {
        foreach (PanelStat panel in stats)
        {
            panel.button.interactable = true;
        }
    }
    public void ShowPanelStats(InputAction.CallbackContext callbackContext)
    {
        SetTextDisponibles();
        ShowHiddenPanel();
    }
}
