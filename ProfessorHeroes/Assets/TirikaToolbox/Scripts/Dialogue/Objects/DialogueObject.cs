using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Dialogue")]
public class DialogueObject : GenericObject
{
    public int id;
    public string nameDialogue;    
    public DataPerson[] people;
    public Sentence[] sentences;
    List<AudioClip> audios;
    //List<Cutscene> Cutscenes;

    public bool ItWasRead; 
    public Dialogue CreateDialogue()
    {
        Dialogue d = new Dialogue();
        d.id = id;
        d.nameDialogue = nameDialogue;                     
        d.ItWasRead = ItWasRead;
        return d;
    }
    public DataPerson GetPerson(PersonID personID)
    {
        foreach(DataPerson person in people)
        {
            if(person.id == personID)
                return person;
        }
        return null;
    }
}
public enum AvatarPosition { Left = 0, Center = 1, Right = 2 }
public enum PersonID { person1 = 0, person2 = 1, person3 = 2 }

[System.Serializable]
public class DataPerson
{
    public PersonID id;
    public string name;
    public Sprite Face;
    public AvatarPosition position;
}
[System.Serializable]
public class Sentence
{    
    public PersonID id;
    [TextArea(3, 10)]
    public string text;
}
