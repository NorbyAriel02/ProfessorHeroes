using UnityEngine;

public class TTMenuController : MonoBehaviour
{    
    public GameConfig Setting;
    
    protected virtual void Start()
    {
        GameManager.Instance.OnLoadScene?.Invoke();
    }
    protected virtual void Play()
    {
        ChangeOfScene.Instance.Play();
    }
    public void NextTrack()
    {
        AudioManager.Instance.PlayNextClip();
    }
    public void Options()
    {
        ChangeOfScene.Instance.OpenPopup();
    }
    public void HighScore()
    {
        ChangeOfScene.Instance.Table();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
