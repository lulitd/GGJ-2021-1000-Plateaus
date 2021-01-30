
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
     public Sprite portrait;
     public bool portraitLeft;

    public Dialog(string message, float initalDelay = 0.1f, float timeBetweenCharacters = 0.05f,
        bool canFastforward = true, float disappearAfterTime = 2, Sprite portrait=null, bool portraitLeft = false)
    {
        this.initalDelay = initalDelay;
        this.message = message;
        this.timeBetweenCharacters = timeBetweenCharacters;
        this.canFastforward = canFastforward;
        this.disappearAfterTime = disappearAfterTime;
        this.portrait = portrait;
        this.portraitLeft = portraitLeft;
    }
}

