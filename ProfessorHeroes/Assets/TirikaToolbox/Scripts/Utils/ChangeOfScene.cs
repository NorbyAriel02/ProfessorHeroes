using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ChangeOfScene : MonoBehaviour
{
    public GameConfig Setting;
    public static UnityAction OnStart;
    public static UnityAction OnOut;
    //Creo estos paneles static para no crear mas de uno por session
    static GameObject SettingsPanel;
    static GameObject PausePanel;
    public static ChangeOfScene Instance { get; private set; }
    void Awake()
    {
        if (ChangeOfScene.Instance == null)
        {
            ChangeOfScene.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);

    }
    private void Start()
    {
        OnStart?.Invoke();
    }
    public void Menu()
    {
        StartCoroutine(GoScene(1, 0));
    }
    public void Play()
    {
        StartCoroutine(GoScene(1, 1));
    }
    public void Table()
    {
        StartCoroutine(GoScene(1, 2));
    }    
    public IEnumerator GoScene(float sleep, int scene)
    {        
        OnOut?.Invoke();
        yield return new WaitForSeconds(sleep);
        SceneManager.LoadScene(Setting.sceneName[scene]);
    }
    public void OpenSettingsPanel()
    {
        if(SettingsPanel == null)
        {
            Canvas canvas = HelperComponet.GetComponentInChild<Canvas>(gameObject.transform);
            SettingsPanel = Instantiate(Setting.settingsPanel, canvas.transform);
        }            

        SettingsPanel.SetActive(true);
    }

    public void OpenPausePanel()
    {
        if (PausePanel == null)
        {
            Canvas canvas = HelperComponet.GetComponentInChild<Canvas>(gameObject.transform);
            PausePanel = Instantiate(Setting.pausePanel, canvas.transform);
        }

        PausePanel.SetActive(true);
    }
}
