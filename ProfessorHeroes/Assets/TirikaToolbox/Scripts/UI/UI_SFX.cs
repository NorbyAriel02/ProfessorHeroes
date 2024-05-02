using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SFX : MonoBehaviour
{
    public GameConfig config;
    public void PlayAudio(AudioClip clip)
    {
        AudioManager.Instance.PlayOnShot(clip);
    }    
    public void PlayOver()
    {
        PlayAudio(config.clips[0]);
    }
    public void PlayClic()
    {
        PlayAudio(config.clips[1]);
    }    
}
