
using System;
using UnityEngine;

[Serializable]
public struct Dialog
{
     public string message;
     public float initalDelay;
     public float timeBetweenCharacters;
     public bool canFastforward;
     public float disappearAfterTime;
     public Character speaker; 
    public Dialog(string message, float initalDelay = 0.1f, float timeBetweenCharacters = 0.03f,
        bool canFastforward = true, float disappearAfterTime = 2, Character character =null)
    {
        this.initalDelay = initalDelay;
        this.message = message;
        this.timeBetweenCharacters = timeBetweenCharacters;
        this.canFastforward = canFastforward;
        this.disappearAfterTime = disappearAfterTime;
        this.speaker = null; 
    }
}

