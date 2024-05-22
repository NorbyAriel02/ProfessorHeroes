using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHelper 
{
    /* Retorna un modificador que disminuye con el nivel 
     * si m es negativa y aumenta si m es positiva, b es el maximo*/
    public static float GetError(LinealFunction lf)
    {        
        //obtenemos el maximo error para este nivel
        float error = -lf.M * lf.X  + lf.B;

        //con el clamp hacemos que la mejora de nivel tenga un maximo
        //y el maximo error sea b
        error = Mathf.Clamp(error, 0.0f, lf.B);

        //agregamos una variacion al maximo
        //con la funcion senoidal siempre obtendremos
        //valores entre el maximo error positivo y el 
        //minimo valor negativo
        error = error * Mathf.Sin(Time.time);

        //el signo nos pemite obtener de forma aleatoria 
        //un +error o -error
        int signo = 1;
        if (Random.Range(0, 2) > 0)
            signo = -1;

        return signo*error;
    }

    public static float GetY(LinealFunction lf)
    {        
        return lf.M * lf.X + lf.B; 
    }
}
[System.Serializable]
public class LinealFunction
{
    public float B;
    public float M;
    public float X;
    public LinealFunction(float b, float m, float x)
    {
        B = b;
        M = m;
        X = x;
    }

}
