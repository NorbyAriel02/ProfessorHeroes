using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject background;
    void Start()
    {
        if (background != null)
            Instantiate(background, transform);
        else
            Debug.LogWarning("No se asigno el fondo a la acamara");
    }
    
}
