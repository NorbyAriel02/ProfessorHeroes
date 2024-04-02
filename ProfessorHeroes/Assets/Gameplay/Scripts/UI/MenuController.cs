using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : TTMenuController
{
    public Transform panelMenu;    
    public TMP_InputField InputPlayerName;    
    protected override void Start()
    {
        base.Start();
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetString("PlayerName", InputPlayerName.text);
    }
    protected override void Play()
    {
        if(string.IsNullOrEmpty(InputPlayerName.text))
        {
            InputPlayerName.text = "Fulano";
            return;
        }        
        base.Play();
    }    
    //Canvas GetCanvas()
    //{        
    //    return HelperComponet.GetComponentInHierarchy<Canvas>(panelMenu);
    //}
}
