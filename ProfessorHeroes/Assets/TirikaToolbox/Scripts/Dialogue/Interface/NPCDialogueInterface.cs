using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogueInterface : DialogueInterface
{
    public GameObject panelListDialogue;
    public GameObject prefabNameDialogue;
    public GameObject prefabPanelDialogue;

    private GameObject canvas;
    private TMP_Text nameText;
    private TMP_Text dialogueText;
    private Image FaceNPC;
    private Button btnNext;
    private GameObject panelDialogue;
    private string currentSentence = string.Empty;
    private Button btnDialogue;
    void Start()
    {        
        StartVar();
    }
    public override void StartVar()
    {
        base.StartVar();
        canvas = FindObjectOfType<Canvas>().gameObject;
        btnDialogue = GetComponentInChildren<Button>();
    }
    //public override void OnEventDialogue()
    //{
    //    bool notDialogue = true;
    //    foreach (DialogueObject dialogue in dialogues)
    //    {
    //        if (!dialogue.ItWasRead)
    //        {
    //            notDialogue = false;
    //            StartDialogue(dialogue);
    //            break;
    //        }
    //    }
    //    if(notDialogue)
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
    private void SetPanelDialogue()
    {
        if (panelDialogue == null)
        {
            panelDialogue = Instantiate(prefabPanelDialogue, canvas.transform);
        }
        else
            panelDialogue.SetActive(true);

        nameText = DialogueManager.GetTextName(panelDialogue);
        dialogueText = DialogueManager.GetTextDialogue(panelDialogue);
        dialogueText.text = string.Empty; 
        FaceNPC = DialogueManager.GetImageNPC(panelDialogue);
        btnNext = DialogueManager.GetButtonNext(panelDialogue);
        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(DisplayNextSentence);
    }

    public override void StartDialogue(DialogueObject dialogue)
    {
        SetPanelDialogue();        
        nameText.text = dialogue.nameNPC;
        FaceNPC.sprite = dialogue.faceNPC;

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
        btnDialogue.interactable = true;
        currentSentence = string.Empty;
    }
}
