using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Dialogue")]
public class DialogueObject : GenericObject
{
    public int id;
    public string nameDialogue;
    public string nameNPC;
    public Sprite faceNPC;
    public AvatarPosition position;
    [TextArea(3, 10)]
    public string[] sentences;
    List<AudioClip> audios;
    //List<Cutscene> Cutscenes;

    public bool ItWasRead; 
    public Dialogue CreateDialogue()
    {
        Dialogue d = new Dialogue();
        d.id = id;
        d.nameDialogue = nameDialogue;
        d.nameNPC = nameNPC;        
        d.sentences = sentences;
        d.ItWasRead = ItWasRead;
        return d;
    }
}
public enum AvatarPosition { Left = 0, Center = 1, Right = 2 }