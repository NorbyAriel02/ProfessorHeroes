using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject panelError;
    public GameObject winPanel;
    public TMP_Text txtLevel;
    public Image imgExp;
    public Image imgSprint;
    public Image imgHealth;    
    public List<ButtonGoals> buttons;
    public DBGoalObject dbGoalObject;
    public KeyCode PauseKey;    
    private void Awake()
    {
        
    }
    private void OnEnable()
    {        
        LevelSystem.ByAddingExperience += SetExpAndLevel;
        LevelSystem.StartLevelSystem += SetExpAndLevel;
        PickupGoal.OnGetGoal += EnableWaepon;
    }
    private void OnDisable()
    {
        LevelSystem.ByAddingExperience -= SetExpAndLevel;
        LevelSystem.StartLevelSystem -= SetExpAndLevel;
        PickupGoal.OnGetGoal -= EnableWaepon;
    }
    void EnableWaepon(GoalObject goal)
    {        
        foreach(ButtonGoals bg in buttons)
        {
            if(bg.goal == goal)
            {
                bg.button.SetActive(true);
            }
        }
    }
    private void Start()
    {
        foreach (var obj in dbGoalObject.objs)
        {
            GoalObject goal = (GoalObject)obj;
            if (goal.isFinished)
            {
                EnableWaepon(goal);
            }
        }            
    }    
    public void ShowPause()
    {
        ChangeOfScene.Instance.OpenPausePanel();
        Time.timeScale = 0f;
    }
    public void HiddeWin()
    {
        winPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    
    private void Update()
    {
        //if(Input.GetKeyDown(PauseKey))
        //{
        //    ShowPause();
        //}
        UpdateSliderSprint();
    }
        
    public void SetExpAndLevel(LevelSystemData data)
    {
        txtLevel.text = "Level " + data.currentlevel;
        float value = (float)data.currentExp / (float)data.requiredExpToNextLevel;
        imgExp.fillAmount = value;
    }
    private void UpdateSliderSprint()
    {        
        imgSprint.fillAmount = PlayerStats.Instance.GetSpritDurationNormalize();
    }    
}
[System.Serializable]
public class ButtonGoals
{
    public string name;
    public GoalObject goal;
    public GameObject button;
    
}
