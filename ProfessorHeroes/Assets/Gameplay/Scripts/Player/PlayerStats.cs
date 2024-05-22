using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }
    [Header("Estadisticas")]
    public AttributeObject fuerza;
    public AttributeObject forma;
    public AttributeObject desArco;
    public AttributeObject desEspada;
    public LinealFunction lfSprint;
    void OnEnable()
    {
        if (PlayerStats.Instance == null)
        {
            PlayerStats.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);

        lfSprint.X = forma.value;
    }
    public LinealFunction Sprint
    { 
        get 
        {
            lfSprint.X = forma.value;
            return lfSprint; 
        } 
    }
    public float SprintDuration
    {
        get
        {
            return 2 + lfSprint.M * forma.value;
        }
    }
}
