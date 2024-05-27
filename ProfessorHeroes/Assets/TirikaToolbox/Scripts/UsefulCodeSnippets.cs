using System.Collections;
using System.Collections.Generic;
using TIRIKA;
using UnityEngine;

public class UsefulCodeSnippets : MonoBehaviour
{
    void Metodo()
    {
        StartCoroutine(Corrutina());
    }
    IEnumerator Corrutina()
    {

        for (float scale = 1f; scale >= 0; scale -= 0.1f)
        {
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }
    }

    public void BoxCast2d()
    { 
        float distance = 1f;
        Vector2 direction = Vector2.zero;
        Vector2 boxZise = new Vector2(1, 1);
        Vector2 origen = transform.position;
        float angle = 0f;
        //retorna todos los contactos
        RaycastHit2D[] tocados = Physics2D.BoxCastAll(origen, boxZise, angle, direction, distance);
        foreach (RaycastHit2D tocado in tocados)
        {
            print(tocado.collider.name);
        }
        //retorna el primero contacto
        RaycastHit2D golpeado = Physics2D.BoxCast(origen, boxZise, angle, direction, distance);
    }
}
