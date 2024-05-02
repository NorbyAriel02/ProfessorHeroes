using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ParameterOsillate
{
    public float timer;
    public float frequency;
    public Vector3 amplitude;
    public Vector3 initialPosition;
    public Vector3 offset; 
    public Transform transform;
}

public class MoveGameObject 
{
    public static void TakeOscillate(MonoBehaviour instance, ParameterOsillate osillate)
    {
        instance.StartCoroutine(Oscillate(osillate.timer, osillate.frequency, osillate.amplitude, osillate.initialPosition, osillate.offset, osillate.transform));
    }
    static IEnumerator Oscillate(float timer, float frequency, Vector3 amplitude, Vector3 initialPosition, Vector3 offset, Transform _transform)
    {
        float delay = timer;
        while (delay > 0)
        {
            // Calcula la posición oscilada en función del tiempo
            float t = Time.time * frequency;
            float x = Mathf.Sin(t) * amplitude.x + initialPosition.x + offset.x;
            float y = Mathf.Cos(t) * amplitude.y + initialPosition.y + offset.y;

            // Aplica la posición oscilada al objeto
            _transform.position = new Vector3(x, y, initialPosition.z);
            delay -= Time.deltaTime;
            yield return null;
        }
        _transform.position = initialPosition;
    }
    public static Vector3 LookAtCursor(Vector3 origen)
    {
        // convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        return (mouseScreenPosition - (Vector2)origen).normalized;
    }
    public static Vector3 LookAtPoint(Vector3 origen, Vector3 target)
    {
        //Tengo que igualar este valor al eje que quiero que mire el punto
        // ejemplo tranform.right
        // get direction you want to point at
        return (target - origen).normalized;
    }
}
