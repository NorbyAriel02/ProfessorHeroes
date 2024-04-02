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
    static GameObject SettingsPanel;
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
    public void OpenPopup()
    {
        if(SettingsPanel == null)
        {
            Canvas canvas = HelperComponet.GetComponentInChild<Canvas>(gameObject.transform);
            SettingsPanel = Instantiate(Setting.panelOptions, canvas.transform);
        }            

        SettingsPanel.SetActive(true);
    }

    public void ClosePopup()
    {        
        SettingsPanel.SetActive(false);
    }
}
