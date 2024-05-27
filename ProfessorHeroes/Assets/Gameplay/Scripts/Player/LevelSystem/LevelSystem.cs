using Google.Apis.Sheets.v4.Data;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;

public class LevelSystem : MonoBehaviour
{    
    public LevelSystemData levelData;
    public static UnityAction<LevelSystemData> WhenLevelingUp;
    public static UnityAction<LevelSystemData> ByAddingExperience;
    public static UnityAction<LevelSystemData> StartLevelSystem;
    private void OnEnable()
    {
        GivesExperience.AddExperience += AddExp;
    }
    void Start()
    {
        StartLevelSystem?.Invoke(levelData);
    }    
    public void AddExp(int value)
    {
        if (levelData.currentlevel >= levelData.maxLevel)
            return;

        levelData.totalAccumulatedExp += value;
        levelData.currentExp += value;
        UpdateLevel();
        ByAddingExperience?.Invoke(levelData);
    }
    public void UpdateLevel()
    {
        int level = CalculateLevel();
        
        if(level != levelData.currentlevel)
        {
            levelData.AvialablePoints += (level - levelData.currentlevel) * levelData.PointsPerLevel;
            levelData.currentlevel = level;            
            levelData.requiredExpToNextLevel = GetRequiredExp(level);
            WhenLevelingUp?.Invoke(levelData);
            levelData.currentExp = 0;
        }        
    }
    public int CalculateLevel()
    {
        int level = 1;
        int requiredExperience = levelData.baseExperience;
        int experience = levelData.totalAccumulatedExp;
        while (experience >= requiredExperience)
        {
            experience -= requiredExperience;
            level++;
            requiredExperience = Mathf.RoundToInt(levelData.baseExperience * Mathf.Pow(levelData.factor, level - 1));
        }
        
        return level - 1; // Restamos 1 porque el nivel se incrementa antes de verificar si se alcanza la experiencia necesaria
    }
    
    private int GetRequiredExp(int level)
    {
        return Mathf.RoundToInt(levelData.baseExperience * Mathf.Pow(levelData.factor, level));
    }
    public int GetRequiredExp(int level, int baseExp, float factor)
    {
        return Mathf.RoundToInt(baseExp * Mathf.Pow(factor, level - 1));
    }
}
