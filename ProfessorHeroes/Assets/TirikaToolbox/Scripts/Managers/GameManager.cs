using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameConfig gameConfig;
    public static GameManager Instance { get; private set; }
    public UnityAction OnLoadScene;
    TirikaSettings settings;
    string pathSettings;
    void OnEnable()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);
             
    }
    private void Start()
    {
        LoadSettings();
    }

    void LoadSettings()
    {
        settings = DataManager.Instance.GetSettings(gameConfig);
        SetAudio();
        SetQualityTexture();
        SetQualityShadows(settings.ShadowValue);
    }
    void SetQualityTexture()
    {
        QualitySettings.SetQualityLevel(settings.QualityTexture);
    }
    public void SetQualityShadows(int value)
    {
        switch (value)
        {
            case 0:
                QualitySettings.shadows = ShadowQuality.Disable;
                break;
            case 1:
                QualitySettings.shadows = ShadowQuality.HardOnly;
                break;
            case 2:
                QualitySettings.shadows = ShadowQuality.All;
                break;
        };
    }
    void SetAudio()
    {
        AudioManager.Instance.SetSFXVolumen(settings.SFXVolValue);
        AudioManager.Instance.SetMusicVolumen(settings.MusicVolValue);
        AudioManager.Instance.PlayNextClip();
    }
}
