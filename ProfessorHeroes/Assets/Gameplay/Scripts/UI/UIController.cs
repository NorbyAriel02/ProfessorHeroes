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
    public PlayerStats playerStats;    
    public KeyCode PauseKey;
    
    private void Awake()
    {
        
    }
    private void OnEnable()
    {        
        LevelSystem.ByAddingExperience += SetExpAndLevel;
        LevelSystem.StartLevelSystem += SetExpAndLevel;
    }
    private void OnDisable()
    {
        LevelSystem.ByAddingExperience -= SetExpAndLevel;
        LevelSystem.StartLevelSystem -= SetExpAndLevel;
    }
    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
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
        imgSprint.fillAmount = InputManager.Instance.GetSpritDurationNormalize();
    }    
}
