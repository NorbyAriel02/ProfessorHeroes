using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.UI;

public class DialogController : DialogueInterface
{
    public TMP_Text dialogueText;
    public Image[] avatares;
    public GameObject panelDialogue;
    private string currentSentence = string.Empty;
    void Start()
    {
        StartVar();
        ShowDialogue(0);
    }
    public override void StartVar()
    {
        base.StartVar();
    }
    public void ShowDialogue(int index)
    {
        DialogueObject dialogue = null;
        
        if (dialogues.objs.Count > index)
            dialogue = (DialogueObject)dialogues.objs[index];
        
        if (dialogue != null)
        {
            StartDialogue(dialogue);
        }
        else
            Debug.LogWarning("no hay dialogo disponible");
        
    }
    //public override void OnEventDialogue()
    //{
    //    bool notDialogue = true;
    //    foreach (GenericObject generic in dialogues.objs)
    //    {
    //        DialogObject dialogue = generic as DialogObject;
    //        if (!dialogue.ItWasRead)
    //        {
    //            notDialogue = false;
    //            StartDialogue(dialogue);
    //            break;
    //        }
    //    }
    //    if (notDialogue)
    //    {
    //        panelListDialogue.SetActive(true);
    //        ChildrenController.RemoveAllChildren(panelListDialogue);
    //        foreach (DialogueObject dialogue in dialogues)
    //        {
    //            GameObject btn = Instantiate(prefabNameDialogue, panelListDialogue.transform);

    //            btn.GetComponent<DialogueElementList>().dialogue = dialogue;
    //            btn.GetComponent<DialogueElementList>().dialogueInterface = this;
    //            GameObject goText = ChildrenController.GetChild(btn);
    //            goText.GetComponent<TMP_Text>().text = dialogue.nameDialogue;
    //        }
    //    }
    //    btnDialogue.interactable = false;
    //}
    //private void SetPanelDialogue()
    //{
    //    if (panelDialogue == null)
    //    {
    //        panelDialogue = Instantiate(prefabPanelDialogue, canvas.transform);
    //    }
    //    else
    //        panelDialogue.SetActive(true);

    //    nameText = DialogueManager.GetTextName(panelDialogue);
    //    dialogueText = DialogueManager.GetTextDialogue(panelDialogue);
    //    dialogueText.text = string.Empty;
    //    FaceNPC = DialogueManager.GetImageNPC(panelDialogue);
    //    btnNext = DialogueManager.GetButtonNext(panelDialogue);
    //    btnNext.onClick.RemoveAllListeners();
    //    btnNext.onClick.AddListener(DisplayNextSentence);
    //}

    public override void StartDialogue(DialogueObject dialogue)
    {
        SetAvatares(dialogue);
        dialogueText.text = currentSentence;
        base.StartDialogue(dialogue);
    }
    public override void DisplayNextSentence()
    {
        if (sentences.Count == 0 && dialogueText.text == currentSentence)
        {
            EndDialogue();
            return;
        }

        if (dialogueText.text == currentSentence)
        {
            currentSentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(currentSentence));
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = currentSentence;
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
    public override void EndDialogue()
    {
        panelDialogue.SetActive(false);
        currentSentence = string.Empty;
    }

    void SetAvatares(DialogueObject dialogue)
    {
        for (int i = 0; i < avatares.Length; i++)
            avatares[i].gameObject.SetActive(false);

        if(dialogue.faceNPC != null)
        {
            avatares[(int)dialogue.position].sprite = dialogue.faceNPC;
            avatares[(int)dialogue.position].gameObject.SetActive(true);
        }        
    }
}
