using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public DialogueDataBaseObject dialogues;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Llego " + collision.gameObject.name);
        int index = Random.Range(0, dialogues.objs.Count);
        DialogController.Instance.ShowDialogue(index);
    }
}
