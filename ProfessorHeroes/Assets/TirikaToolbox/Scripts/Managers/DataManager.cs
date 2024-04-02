using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public GameConfig gameConfig;
    public static DataManager Instance { get; private set; }    
    void Awake()
    {
        if (DataManager.Instance == null)
        {
            DataManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);
    }
    public void SaveSettings(TirikaSettings settings)
    {
        string pathSettings = PathHelper.GetPlatformPath(gameConfig.fileSettingsData);
        DataFileController.SaveEncrypted<TirikaSettings>(settings, pathSettings);
    }
    public TirikaSettings GetSettings(GameConfig gameConfig)
    {
        string pathSettings = PathHelper.GetPlatformPath(gameConfig.fileSettingsData);

        TirikaSettings fileSettings = DataFileController.GetEncryptedData<TirikaSettings>(pathSettings);
        if (fileSettings == null)
            fileSettings = new TirikaSettings(gameConfig);

        return fileSettings;
    }
}
