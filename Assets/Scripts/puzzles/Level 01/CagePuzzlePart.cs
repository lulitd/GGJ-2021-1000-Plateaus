using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CagePuzzlePart : MonoBehaviour , IClickable
{
    [SerializeField] private string observation;

    private CagePuzzle puzzle;
    private void OnEnable()
    {
        puzzle = GetComponentInParent<CagePuzzle>();
        
    }

    public void onClick()
    {
        DialogSystem.Instance.PlayDialogImmediately.Invoke(
            new Dialog(observation), true);

        if (puzzle)
        {
            puzzle.PartInspected();
        }
    }
}
