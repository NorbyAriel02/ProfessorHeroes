using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.Events;

public class GivesExperience : MonoBehaviour
{
    public int Experience;
    public static UnityAction<int> AddExperience;
    Health health;
    private void OnEnable()
    {
        health = GetComponent<Health>();
        if (health != null)
            health.OnDie += AddExp;
    }
    public void AddExp()
    {
        //TODO hacer que aparesca un texto en pantalla con la cantidad de exp ganada
        AddExperience?.Invoke(Experience);
    }
}
