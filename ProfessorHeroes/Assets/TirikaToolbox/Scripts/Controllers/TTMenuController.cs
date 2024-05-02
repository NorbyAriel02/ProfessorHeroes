using UnityEngine;

public class TTMenuController : MonoBehaviour
{    
    public GameConfig Setting;
    
    protected virtual void Start()
    {
        //Indica al game manager que se cargo una nueva escena
        GameManager.Instance.OnLoadScene?.Invoke();
    }
    public virtual void Play()
    {
        ChangeOfScene.Instance.Play();
    }
    //Reproduce la musica asignada al AudioManager
    public void NextTrack()
    {
        AudioManager.Instance.PlayNextClip();
    }
    public void Options()
    {
        ChangeOfScene.Instance.OpenSettingsPanel();
    }
    public virtual void HighScore()
    {
        ChangeOfScene.Instance.Table();
    }
    public virtual void Menu()
    {
        ChangeOfScene.Instance.Menu();
    }
    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
