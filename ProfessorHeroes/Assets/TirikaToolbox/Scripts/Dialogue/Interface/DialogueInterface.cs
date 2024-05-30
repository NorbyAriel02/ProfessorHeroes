using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueInterface : MonoBehaviour
{
    public static DialogueInterface Instance { get; private set; }
    public delegate void DialogueCallback(DialogueObject dialogue);
    public static DialogueCallback OnDialogueCallback;
    
    public DialogueDataBaseObject dialogues;
    public float typeSpeed = 0.05f;

    protected Queue<Sentence> sentences;
    void OnEnable()
    {
        if (DialogueInterface.Instance == null)
        {
            DialogueInterface.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);

    }
    public virtual void ShowDialogue(int index)
    {

    }
    public virtual void StartVar()
    {
        sentences = new Queue<Sentence>();
    }
    public virtual void OnEventDialogue()
    {
        
    }
    
    public virtual void StartDialogue(DialogueObject dialogue)
    {
        dialogue.ItWasRead = true;
        sentences.Clear();

        foreach (Sentence sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        OnDialogueCallback?.Invoke(dialogue);
        InputManager.Instance.controles.Disable();
    }
    public virtual void DisplayNextSentence()
    {
        
    }

    public virtual void EndDialogue()
    {
        InputManager.Instance.controles.Enable();
    }    
}
