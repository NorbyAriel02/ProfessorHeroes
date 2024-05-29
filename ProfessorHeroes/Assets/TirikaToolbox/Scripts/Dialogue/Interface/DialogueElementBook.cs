using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueElementBook : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueBookInterface dialogueBookInterface;    
    private void Start()
    {
        
    }
    public void Play()
    {
        dialogueBookInterface.ShowDialogues(dialogue);        
    }
}
