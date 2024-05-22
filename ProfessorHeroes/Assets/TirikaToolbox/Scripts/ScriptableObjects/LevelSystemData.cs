using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
[CreateAssetMenu(fileName = "New LevelData", menuName = "TIRIKA/LevelData")]
public class LevelSystemData : ScriptableObject
{
    public float factor = 2f;
    public int baseExperience = 100;
    public int totalAccumulatedExp = 100;//el total de la experiencia acumulada
    public int currentExp;//experiencia acumulada en el nivel actual
    public int requiredExpToNextLevel;//experiencia Requerida para el siguiente nivel
    public int currentlevel;//nivel actual
    public int maxLevel;//maximo nivel alcanzable
    public DataBaseObject attributes;
    public int AvialablePoints = 4;
}
