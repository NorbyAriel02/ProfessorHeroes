using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ScriptTest : MonoBehaviour
{
    public AnimationCurve curve;
    public Transform obj;
    public Transform[] points; // Puntos a través de los cuales el objeto debe moverse    
    

    private void Start()
    {
    
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            //StartCoroutine(LerpPosition(points[0].position, points[1].position, obj));
            StartCoroutine(LerpBetweenPositions(points, obj, 0.1f));
        }
        
    }
    //IEnumerator MoveObj()
    //{
    //    currentPointIndex = 0;        
    //    while (currentPointIndex <= points.Length-1) {
    //        float progress = 0;
    //        timer = 0f;            
    //        startPos = obj.position;
    //        endPos = points[currentPointIndex].position;
    //        while (progress < 0.9f)
    //        {                
    //            // Incrementar el temporizador
    //            timer += Time.deltaTime;
    //            // Calcular el progreso del movimiento (entre 0 y 1)
    //            progress = Mathf.Clamp01(timer / totalTime);                
    //            // Mover el objeto hacia el siguiente punto interpolando entre la posición inicial y final
    //            obj.position = Vector3.Lerp(startPos, endPos, progress);
    //            yield return null;
    //        }            
    //        // Pasar al siguiente punto
    //        currentPointIndex++;
    //        yield return null;
    //    }
    //    yield return null;
    //}
    //IEnumerator LerpValue(float start, float end)
    //{        
    //    float timeElapsed = 0;
    //    float reducedRange = Mathf.Abs(start - end);
    //    float reducedDuration = duration * (reducedRange / totalScale);
    //    while (timeElapsed < reducedDuration)
    //    {
    //        float t = timeElapsed/reducedDuration;
    //        lerpValue =  Mathf.Lerp(start, end, t);
    //        timeElapsed += Time.deltaTime;
    //        yield return null;
    //    }
    //    lerpValue = end;
    //}
    IEnumerator LerpBetweenPositions(Transform[] points, Transform obj, float duration = 1)
    {
        int currentPointIndex = 0;
        while (currentPointIndex <= points.Length - 1)
        {   
            Vector3 startPos = obj.position;
            Vector3 endPos = points[currentPointIndex].position;
            float timeElapsed = 0;
            while (timeElapsed < duration)
            {
                float t = timeElapsed / duration;
                obj.position = Vector3.Lerp(startPos, endPos, t);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            obj.position = endPos;
            currentPointIndex++;            
            yield return null;
        }
    }
    //IEnumerator LerpPosition(Vector2 start, Vector2 end, Transform gObj)
    //{
    //    float timeElapsed = 0;
    //    //float reducedRange = Vector2.Distance(start, end);
    //    //float reducedDuration = duration * (reducedRange / totalScale);
    //    while (timeElapsed < duration)
    //    {
    //        float t = timeElapsed / duration;
    //        gObj.position = Vector2.Lerp(start, end, t);
    //        timeElapsed += Time.deltaTime;
    //        yield return null;
    //    }
    //    gObj.position = end;
    //}
    //IEnumerator LerpValueCurve(float start, float end)
    //{
    //    float timeElapsed = 0;
    //    float reducedRange = Mathf.Abs(start - end);
    //    float reducedDuration = duration * (reducedRange / totalScale);
    //    while (timeElapsed < reducedDuration)
    //    {
    //        float t = timeElapsed / reducedDuration;
    //        lerpValue = curve.Evaluate(t);            
    //        timeElapsed += Time.deltaTime;
    //        yield return null;
    //    }
    //    lerpValue = end;
    //}
}
