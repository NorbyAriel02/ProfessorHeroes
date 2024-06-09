using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Dialog", menuName = "TIRIKA/P1/New Dialog")]
public class DialogObject : GenericObject
{    
    public AvatarPosition position;
    public Sprite avatar;
    
    [TextArea(2, 5)]
    public List<string> dialogueText;
    public bool ItWasRead;
}
