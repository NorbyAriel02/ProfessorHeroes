using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueInterface : MonoBehaviour
{
    public delegate void DialogueCallback(DialogueObject dialogue);
    public static DialogueCallback OnDialogueCallback;
    
    public DialogueDataBaseObject dialogues;
    public float typeSpeed = 0.05f;

    protected Queue<string> sentences;
    
    public virtual void StartVar()
    {
        sentences = new Queue<string>();
    }
    public virtual void OnEventDialogue()
    {
        
    }
    
    public virtual void StartDialogue(DialogueObject dialogue)
    {
        dialogue.ItWasRead = true;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        OnDialogueCallback?.Invoke(dialogue);
    }
    public virtual void DisplayNextSentence()
    {
        
    }

    public virtual void EndDialogue()
    {

    }    
}
