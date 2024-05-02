using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Result : MonoBehaviour
{
    public KeyCode keyMark;
    public GameObject mark;
    public AudioClip OnResultadoClip;
    public AudioClip OffResultadoClip;
    int result = 0;
    OperationController controller;

    private void Update()
    {
        if (controller != null && Input.GetKeyDown(keyMark))
            SetValueOperation(controller);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (controller != null) return;

        if (collision.tag.Equals("Player"))
            controller = FindObjectOfType<OperationController>();
    }
    public void SetValue(int _result)
    {
        result = _result;
        TMP_Text text = GetComponentInChildren<TMP_Text>();
        text.text = _result.ToString();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        controller = null;
    }
    void SetValueOperation(OperationController oc)
    {        
        if (mark.activeSelf)
        {
            oc.re = false;
            mark.SetActive(false);
            AudioManager.Instance.PlayOnShot(OffResultadoClip);
        }
        else
        {
            if(oc.re)
            {
                oc.result.SetMark();
            }
            oc.re = true;
            oc.result = this;            
            mark.SetActive(true);
            AudioManager.Instance.PlayOnShot(OnResultadoClip);
        }
    }
    public void SetMark()
    {
        mark.SetActive(!mark.activeSelf);
    }
}
