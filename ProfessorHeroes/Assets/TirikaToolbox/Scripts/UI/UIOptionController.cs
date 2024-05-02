using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UIOptionController : MonoBehaviour
{
    public GameConfig gameConfig;
    [Header("Sliders")]
    public Slider music;
    public Slider sfx;    
    
    [Header("Toggles")]
    public Toggle fullScreem;
    public Toggle muteMusic;
    public Toggle muteSFX;
    
    [Header("Drop Down List")]
    public TMP_Dropdown ddQualityTexture;
    public TMP_Dropdown ddResolution;
    public TMP_Dropdown ddLocalization;

    [Header("Image Icon")]
    public Image CheckMarkMusic;
    public Image CheckMarkSFX;
    public Image BGCheckMusic;
    public Image BGCheckSFX;
    private TirikaSettings settings;
    Resolution[] resolutions;

    void OnEnable()
    {        
        settings = DataManager.Instance.GetSettings(gameConfig);        
        LoadData();
    }
    void LoadData()
    {
        music.value = settings.MusicVolValue;
        sfx.value = settings.SFXVolValue;
        ddLocalization.value = settings.idLocalization;
        ddQualityTexture.value = settings.QualityTexture;
        CreateResolutionDropDownItems();
        //StartCoroutine(GameManager.Instance.SetLocale(index));
    }    
    public void MusicValue()
    {        
        if (music.value <= music.minValue)
            MuteMusic(true);
        else
            MuteMusic(false);

        settings.MusicVolValue = music.value;
        AudioManager.Instance.SetMusicVolumen(music.value);
    }
    public void SFXValue()
    {
        if(sfx.value <= sfx.minValue)
            MuteSFX(true);
        else
            MuteSFX(false);

        settings.SFXVolValue = sfx.value;
        AudioManager.Instance.SetSFXVolumen(sfx.value);
    }
    public void MuteSFX(bool mute)
    {
        muteSFX.isOn = mute;
        if (mute)
        {
            CheckMarkSFX.sprite = gameConfig.CheckMarkSound[0];
            BGCheckSFX.sprite = gameConfig.CheckMarkSound[2];
            AudioManager.Instance.SetSFXVolumen(0);
            sfx.interactable = false;
        }            
        else
        {
            BGCheckSFX.sprite = gameConfig.CheckMarkSound[1];
            sfx.interactable = true;
            AudioManager.Instance.SetSFXVolumen(sfx.value);
        }
            
    }
    public void MuteMusic(bool mute)
    {
        muteMusic.isOn = mute;
        if (mute)
        {
            CheckMarkMusic.sprite = gameConfig.CheckMarkSound[0];
            BGCheckMusic.sprite = gameConfig.CheckMarkSound[2];
            AudioManager.Instance.SetMusicVolumen(0);
            music.interactable = false;
        }            
        else
        {
            BGCheckMusic.sprite = gameConfig.CheckMarkSound[1];
            AudioManager.Instance.SetMusicVolumen(music.value);
            music.interactable = true;
        }            
    }
    
    public void SetFullScreem(bool fullScreem)
    {
        Screen.fullScreen = fullScreem;
    }
    public void QualityTexture()
    {
        QualitySettings.SetQualityLevel(ddQualityTexture.value);
        settings.QualityTexture = ddQualityTexture.value;
    }
    private void CreateResolutionDropDownItems()
    {
        resolutions = Screen.resolutions;
        ddResolution.ClearOptions();
        List<string> options = new List<string>();
        int currentResolution = 0;
        int count = 0;
        
        foreach(var resolution in resolutions)
        {
            string option = resolution.width + " x " + resolution.height;
            options.Add(option);
            
            if (Screen.width == resolution.width && Screen.height == resolution.height)
                currentResolution = count;

            count++;
        }
        
        ddResolution.AddOptions(options);
        
        if(settings.IndexResolution != -1)
            ddResolution.value = settings.IndexResolution;
        else
            ddResolution.value = currentResolution;

        ddResolution.RefreshShownValue();
    }
    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, fullScreem.isOn);
        settings.IndexResolution = index;
    }

    public void ChangeLocate(int index)
    {
        if (GameManager.Instance._activeLocate)
            return;
        
        StartCoroutine(GameManager.Instance.SetLocale(index));
        settings.idLocalization = index;
        DataManager.Instance.SaveSettings(settings);
    }

    
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void Save()
    {
        DataManager.Instance.SaveSettings(settings);
        gameObject.SetActive(false);
    }
}
[System.Serializable]
public class TirikaSettings
{  
    public TirikaSettings(GameConfig config)
    {
        MusicVolValue = config.DefaultDataSetting.MusicVolValue;
        MusicMixerParameter = config.DefaultDataSetting.MusicMixerParameter;
        musicClipIndex = config.DefaultDataSetting.musicClipIndex;
        SFXVolValue = config.DefaultDataSetting.SFXVolValue;
        SFXMixerParameter = config.DefaultDataSetting.SFXMixerParameter;
        ShadowValue = config.DefaultDataSetting.ShadowValue;
        QualityTexture = config.DefaultDataSetting.QualityTexture;
        IndexResolution = Screen.resolutions.Length - 1;//por default pongo la resolucion mas alta del monitor
        fullScreen = Screen.fullScreen;
        idLocalization = config.DefaultDataSetting.idLocalization;
    }
    public TirikaSettings()
    {        
    }
    public float MusicVolValue;
    public string MusicMixerParameter;
    public int musicClipIndex;
    public float SFXVolValue;
    public string SFXMixerParameter;
    public int ShadowValue;
    public int QualityTexture;
    public int IndexResolution;
    public bool fullScreen;
    public int idLocalization;
}
