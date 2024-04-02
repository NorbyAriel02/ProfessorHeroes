using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[CreateAssetMenu(fileName = "New GameConfig", menuName = "NAW Config/GameConfig")]
public class GameConfig : ScriptableObject
{
    [Header("Menu y Escenas")]
    public List<string> sceneName = new List<string>();
    public GameObject panelOptions;

    [Header("Data from GoogleSheets")]
    public string spreadSheetID;
    public string sheetID;
    public string serviceAccountEmail = "googlesheetsunity@unityapi-test.iam.gserviceaccount.com";
    public string certificateName = "unityapi-test-7311ad37cd10.p12";

    [Header("Data from Sheets")]
    public string readRange;

    [Header("SFX Clips")]
    public AudioClip[] clips;

    [Header("Window Settings")]    
    public string fileSettingsData;
    public Sprite[] CheckMarkSound;
    public TirikaSettings DefaultDataSetting;
    public AudioMixer AudioMixer;
}
