using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : Singleton<GameSettings>
{
    // Start is called before the first frame update
    private KeyCode escape = KeyCode.Escape;
    void Start()
    {
        Application.targetFrameRate = 24;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
