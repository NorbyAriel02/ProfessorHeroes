using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialogue
{
    public int id;
    public string nameDialogue;
    public string nameNPC;
    
    [TextArea(3, 10)]
    public string[] sentences;
    
    public bool ItWasRead;
}
