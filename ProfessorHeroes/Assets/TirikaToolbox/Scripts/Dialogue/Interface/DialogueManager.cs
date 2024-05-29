using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class DialogueManager 
{
	public static TMP_Text GetTextName(GameObject panelDialogue)
	{
        GameObject[] goTextName = ChildrenController.GetChildren(panelDialogue);
        GameObject[] goComponetUI = ChildrenController.GetChildren(goTextName[0]);
        TMP_Text text = goComponetUI[0].GetComponent<TMP_Text>();
        return text;
	}
    public static TMP_Text GetTextDialogue(GameObject panelDialogue)
    {
        GameObject[] goTextName = ChildrenController.GetChildren(panelDialogue);
        GameObject[] goComponetUI = ChildrenController.GetChildren(goTextName[0]);
        TMP_Text text = goComponetUI[1].GetComponent<TMP_Text>();
        return text;
    }
    public static Button GetButtonNext(GameObject panelDialogue)
    {
        GameObject[] goTextName = ChildrenController.GetChildren(panelDialogue);
        GameObject[] goComponetUI = ChildrenController.GetChildren(goTextName[0]);
        Button button = goComponetUI[2].GetComponent<Button>();
        return button;
    }
    public static Image GetImageNPC(GameObject panelDialogue)
    {
        GameObject[] goChildren = ChildrenController.GetChildren(panelDialogue);        
        Image npc = goChildren[1].GetComponent<Image>();
        return npc;
    }
}
