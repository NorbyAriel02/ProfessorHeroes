using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Operation : MonoBehaviour
{
    public KeyCode keyMark;
    public GameObject mark;
    public AudioClip OnOperacionClip;
    public AudioClip OffOperacionClip;
    int value1 = 0;
    int value2 = 0;
    private TMP_Text txtOperation;
    OperationController controller;

    private void OnEnable()
    {
        txtOperation = GetComponentInChildren<TMP_Text>();
    }

    public void SetText(string text, int _value1, int _value2)
    {
        value1 = _value1;
        value2 = _value2;
        txtOperation.text = text;
    }
    private void Update()
    {
        if (controller != null && Input.GetKeyDown(keyMark))
            SetValueOperation(controller);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(controller != null) return;

        if (collision.tag.Equals("Player"))
            controller = FindObjectOfType<OperationController>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        controller = null;
    }
    void SetValueOperation(OperationController oc)
    {
        if (mark.activeSelf)
        {
            oc.op = false;
            mark.SetActive(false);
            AudioManager.Instance.PlayOnShot(OffOperacionClip);
        }
        else
        {
            if(oc.op)
            {
                oc.operation.SetMark();
            }
            oc.op = true;
            oc.operation = this;
            mark.SetActive(true);
            AudioManager.Instance.PlayOnShot(OnOperacionClip);
        }
    }
    public void SetMark()
    {
        mark.SetActive(!mark.activeSelf);
    }
    public bool IsMarked()
    {
        return mark.activeSelf;
    }
}
