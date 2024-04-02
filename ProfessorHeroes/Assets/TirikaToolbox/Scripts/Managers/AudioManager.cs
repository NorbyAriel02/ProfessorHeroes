using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public GameConfig gameConfig;
    public AudioClip[] musicClips;
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioSource audioSourceFX;
    [SerializeField] private AudioSource audioSourceMusic;
    TirikaSettings settings;
    void Awake()
    {
        if(AudioManager.Instance == null)
        {
            AudioManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);

    }
        
    public void PlayOnShot(AudioClip clip)
    {
        audioSourceFX.PlayOneShot(clip);
    }   
    public void PlayMusic(AudioClip clip)
    {
        audioSourceMusic.clip = clip;
        audioSourceMusic.Play();
    }
    public void SetSFXVolumen(float value)
    {
        if(settings == null)
            settings = DataManager.Instance.GetSettings(gameConfig);
        //SFXMixerParameter es el parametro de volumen creado para este mixer                 
        gameConfig.AudioMixer.SetFloat(settings.SFXMixerParameter, GetValueVolumen(value));
    }
    public void SetMusicVolumen(float value)
    {
        if (settings == null)
            settings = DataManager.Instance.GetSettings(gameConfig);
        //con un check puedo elegir entre el mixer de 8 bits o el dance
        //MusicMixerParameter es el parametro de volumen creado para este mixer                
        gameConfig.AudioMixer.SetFloat(settings.MusicMixerParameter, GetValueVolumen(value));        
    }
    static float GetValueVolumen(float value)
    {
        if (value <= 0)
            value = 0.0001f;

        return Mathf.Log10(value / 10) * 20;
    }
    public void NextTrack()
    {
        if (settings == null)
            settings = DataManager.Instance.GetSettings(gameConfig);

        settings.musicClipIndex = settings.musicClipIndex + 1;
        if (settings.musicClipIndex >= musicClips.Length)
            settings.musicClipIndex = 0;
        
        PlayMusic(musicClips[settings.musicClipIndex]); 
        DataManager.Instance.SaveSettings(settings);
    }
    public void PlayNextClip()
    {
        // Comprobar si hay clips de audio disponibles
        if (musicClips.Length > 0)
        {
            //reproduce el clic
            PlayMusic(musicClips[settings.musicClipIndex]);
            
            //Asigna el siguiente index
            settings.musicClipIndex = (settings.musicClipIndex + 1) % musicClips.Length;
            
            //Borra los llamados pendientes para evitar llamados no deseados
            CancelInvoke("PlayNextClip");
                        
            //prepara el proximo llamando para cuando termine la pista actual
            Invoke("PlayNextClip", audioSourceMusic.clip.length);
            
            DataManager.Instance.SaveSettings(settings);
        }        
    }
}
