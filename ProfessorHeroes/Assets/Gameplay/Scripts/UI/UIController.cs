using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : TTMenuController
{
    public GameObject panelError;
    public GameObject winPanel;
    public float delay = 1;
    public float timer;
    public TMP_Text txtCorrectas;
    public TMP_Text txtIncorrectas;
    public TMP_Text txtTimer;
    public TMP_Text txtWinTimer;
    public TMP_Text txtWinErrors;
    public KeyCode PauseKey;
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
        txtWinErrors.text = txtIncorrectas.text;
        winPanel.SetActive(true);
        Time.timeScale = 0f;
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
        if(Input.GetKeyDown(PauseKey))
        {
            ShowPause();
        }
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        txtTimer.text = timer.ToString("0.000");
    }
    public override void Menu()
    {
        Time.timeScale = 1f;
        base.Menu();
    }
    public override void Play()
    {
        Time.timeScale = 1f;
        base.Play();
    }
    public override void Close()
    {
        Time.timeScale = 1f;
        base.Close();
    }
    public override void HighScore()
    {
        Time.timeScale = 1f;
        base.HighScore();
    }
}
