using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSubmit : MonoBehaviour,IClickable
{
    private LockPuzzle _puzzle;
    
    private void OnEnable()
    {
        _puzzle = FindObjectOfType<LockPuzzle>();
        
    }
    
    public void onClick()
    {
        _puzzle.SubmitAnswer();
    }
}
