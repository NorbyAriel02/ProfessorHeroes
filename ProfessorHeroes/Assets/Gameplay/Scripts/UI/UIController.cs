using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : TTMenuController
{
    public GameObject panelError;
    public GameObject panelWin;
    public float delay = 1;
    public float timer;
    public TMP_Text txtTimer;
    public TMP_Text txtWinTimer;    
    public KeyCode keyExit;
    private void OnEnable()
    {
        timer = 0;
    }
    public void ShowError()
    {
        panelError.SetActive(true);
        StartCoroutine(DelayErrorMensaje());
    }
    public void ShowWin()
    {
        txtWinTimer.text = txtTimer.text;
        panelWin.SetActive(true);
        Time.timeScale = 0f;
    }
    public void HiddeWin()
    {
        panelWin.SetActive(false);
        Time.timeScale = 1f;
    }
    private IEnumerator DelayErrorMensaje()
    {
        yield return new WaitForSeconds(delay);
        panelError.SetActive(false);
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    
    private void Update()
    {
        if(Input.GetKeyDown(keyExit))
        {
            if(panelWin.activeSelf)
            {
                HiddeWin();
            }
            else
            {
                ShowWin();
            }
        }
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        txtTimer.text = timer.ToString("0.000");
    }
}
