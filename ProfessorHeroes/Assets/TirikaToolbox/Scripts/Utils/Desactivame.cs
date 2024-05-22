using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivame : MonoBehaviour
{
    public float delay = 1;
    private void OnEnable()
    {
        Invoke("Off", delay);
    }
    void Off()
    {
        gameObject.transform.parent = null;
        gameObject.SetActive(false);
    }
}
