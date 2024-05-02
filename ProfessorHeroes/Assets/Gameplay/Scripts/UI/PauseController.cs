using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : TTMenuController
{
    public override void Menu()
    {
        Close();
        base.Menu();
    }
    public override void Play()
    {
        Close();
        base.Play();
    }
    public override void Close()
    {
        Time.timeScale = 1f;
        base.Close();
    }
}
