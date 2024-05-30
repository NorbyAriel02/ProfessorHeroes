using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogController : DialogueInterface
{
    public TMP_Text dialogueText;
    public Image[] avatares;
    public GameObject panelDialogue;
    private Sentence currentSentence = null;
    private DialogueObject currentDialogue;
    void Start()
    {
        StartVar();        
    }
    public override void StartVar()
    {
        base.StartVar();
    }
    public override void ShowDialogue(int index)
    {
        DialogueObject dialogue = null;
        
        if (dialogues.objs.Count > index)
            dialogue = (DialogueObject)dialogues.objs[index];
        
        currentDialogue = dialogue;
        
        if (dialogue != null)
        {
            panelDialogue.SetActive(true);
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
        currentSentence = new Sentence();
        dialogueText.text = currentSentence.text = "";
        base.StartDialogue(dialogue);
    }
    public override void DisplayNextSentence()
    {
        if (sentences.Count == 0 && dialogueText.text == currentSentence.text)
        {
            EndDialogue();
            return;
        }
        
        if (dialogueText.text == currentSentence.text)
        {
            SetBackgroudAvatars();
            currentSentence = sentences.Dequeue();
            AvatarPosition pos = currentDialogue.GetPerson(currentSentence.id).position;
            SetForegroundAvatars(pos);
            SettingSpeech(gameObject.GetInstanceID(), currentSentence.text.Split(' ').Length * 2);
            StopAllCoroutines();
            StartCoroutine(TypeSentence(currentSentence.text));
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = currentSentence.text;
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            Voice();
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    #region speeker
    struct SpeechSyllable
    {
        public int index;
        public float time;
    }
    Queue<SpeechSyllable> syllables = new Queue<SpeechSyllable>();
    public AudioClip[] vocals;
    void Voice()
    {
        if (syllables.Count > 0 && syllables.Peek().time < Time.time)
        {
            var s = syllables.Dequeue();
            AudioManager.Instance.PlayOnShot(vocals[s.index], Random.Range(0.8f, 1.2f));
        }
    }
    void SettingSpeech(int seed, int syllableCount)
    {
        Random.InitState(seed);
        var now = Time.time;
        for (var i = 0; i < syllableCount; i++)
        {
            now += Random.Range(0.1f, 0.3f);
            syllables.Enqueue(new SpeechSyllable() { index = Random.Range(0, vocals.Length), time = now });
        }
    }
    #endregion

    public override void EndDialogue()
    {
        panelDialogue.SetActive(false);
        currentSentence = null;
        base.EndDialogue();
    }

    void SetAvatares(DialogueObject dialogue)
    {
        for (int i = 0; i < avatares.Length; i++)
            avatares[i].gameObject.SetActive(false);

        if (dialogue.people.Length > 0)
        {
            foreach(DataPerson person in dialogue.people)
            {
                avatares[(int)person.position].sprite = person.Face;
                avatares[(int)person.position].gameObject.SetActive(true);
                GameObject chield = ChildrenController.GetChild(avatares[(int)person.position].gameObject);
                TMP_Text name = chield.GetComponent<TMP_Text>();
                name.text = person.name;
            }
        }
    }
    void SetBackgroudAvatars()
    {
        for (int i = 0; i < avatares.Length; i++)
            if(avatares[i].gameObject.activeSelf)
                avatares[i].rectTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    void SetForegroundAvatars(AvatarPosition position)
    {
        avatares[(int)position].rectTransform.localScale = new Vector3(1f, 1f, 1f);        
    }
}
