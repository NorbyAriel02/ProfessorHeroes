using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Apuntar : MonoBehaviour
{
    public float minimumX;
    public float minimumY;
    public float maximumX;
    public float maximumY;
    private Transform father;
    // Start is called before the first frame update
    void Start()
    {
        father = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = MoveGameObject.LookAtCursor(transform.position);
        ClampAngle();
    }    

    void ClampAngle()
    {
        float min = 0;
        float max = 65;
        float rz = transform.eulerAngles.z;
        if (father.eulerAngles.y == 0)
        {
            if (rz >= max && rz <= 270)
                rz = max;

            if (rz >= 270 && rz <= 365)
                rz = min;
        }

        if (father.eulerAngles.y == 180)
        {
            min = 115;
            max = 180;

            if (rz <= min && rz >= 270)
                rz = min;

            if (rz >= max && rz <= 365)
                rz = max;            
        }

        transform.eulerAngles = new Vector3(0, 0, Mathf.Clamp(rz, min, max));
    }
}
