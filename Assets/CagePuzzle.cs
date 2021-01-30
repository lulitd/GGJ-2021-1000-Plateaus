using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CagePuzzle : Puzzle
{
    public int targetInspections;
    private int currentInspections = 0;

    public Animator controller;
    public string shakeAnimation;
    public PlayableDirector Director;
    public String nextscene; 
    public void PartInspected()
    {
        currentInspections += 1;
        if (controller)
        {
            if (currentInspections <= targetInspections)
            {
                controller.SetTrigger(shakeAnimation);
            }

        }

        if (Director && currentInspections >targetInspections)
        {
            Director.Play();
        }
    }

    public void sceneCompleted()
    {
        SceneManager.LoadScene(nextscene);
    }
}
