using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Mirar : MonoBehaviour
{
    public Transform target;
    private Transform father;
    void Start()
    {
        father = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 result = ((Vector2)target.position - (Vector2)transform.position).normalized;
        float z = 0;
        if (father.eulerAngles.y == 0)
            z = Vector2.Angle(result, Vector2.right);
        else
            z = Vector2.Angle(result, Vector2.left);        
        
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, z);
        //Test();
    }

    void Test()
    {
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 result = (mouseScreenPosition - (Vector2)transform.position).normalized;

        Debug.Log("result " + Vector2.Angle(result, Vector2.right));
    }
}
