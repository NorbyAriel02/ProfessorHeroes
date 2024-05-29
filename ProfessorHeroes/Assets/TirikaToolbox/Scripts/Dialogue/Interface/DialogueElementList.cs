using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueElementList : MonoBehaviour
{
    public DialogueObject dialogue;
    public NPCDialogueInterface dialogueInterface;
    private GameObject father;
    private void Start()
    {
        father = transform.parent.gameObject;
    }
    public void Play()
    {
        dialogueInterface.StartDialogue(dialogue);
        father.SetActive(false);
    }
}
