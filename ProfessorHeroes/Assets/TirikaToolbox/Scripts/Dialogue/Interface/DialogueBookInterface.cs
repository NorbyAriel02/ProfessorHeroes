using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogueBookInterface : MonoBehaviour
{
    public List<Dialogue> dialogues;    
    public TMP_Text textTittle;
    public TMP_Text textDialogue;
    public DialogueBookObject dialogueBookObject;
    public GameObject prefabBtnDialogue;
    public GameObject panelListButton;

    private void OnEnable()
    {
        dialogueBookObject.Load();
        dialogues = dialogueBookObject.book.dialogues;
        DialogueInterface.OnDialogueCallback += AddDialogueToBook;
        LoadDialogueButtons();
        textDialogue.text = "";
        textTittle.text = "";
    }
    private void OnDisable()
    {
        DialogueInterface.OnDialogueCallback -= AddDialogueToBook;
    }
    private void OnDestroy()
    {
        dialogueBookObject.book.dialogues = dialogues;
        dialogueBookObject.Save();
    }
    public void AddDialogueToBook(DialogueObject dialogue)
    {
        Dialogue d = dialogue.CreateDialogue();
        foreach(var item in dialogues)
        {
            if(item.id == d.id)
            {
                return;
            }
        }
        dialogues.Add(d);
        LoadDialogueButtons();
    }
    List<Dialogue> GetTheDialoguesToShow()
    {
        return dialogues;
    }
    public void ShowDialogues(Dialogue dialogue)
    {
        textDialogue.text = "";
        textTittle.text = dialogue.nameDialogue + " - " + dialogue.nameNPC;
        foreach(string sentece in dialogue.sentences)
        {
            textDialogue.text += sentece + Environment.NewLine;
        }
    }
    public void LoadDialogueButtons()
    {
        ChildrenController.RemoveAllChildren(panelListButton);
        foreach(var dialogue in dialogues)
        {
            GameObject btn = Instantiate(prefabBtnDialogue, panelListButton.transform);
            DialogueElementBook deb = btn.GetComponent<DialogueElementBook>();
            deb.dialogue = dialogue;
            deb.dialogueBookInterface = this;
            btn.GetComponentInChildren<TMP_Text>().text = dialogue.nameDialogue;
        }
    }
}
