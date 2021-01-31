using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzle : Puzzle
{

    [SerializeField]private Item solution;
    [SerializeField]private int quanity = 3;
    
    [SerializeField] private LockPuzzle.CardSuit suit;
    private int value; 

    private void OnEnable()
    {
        var lockPuzzle = FindObjectOfType<LockPuzzle>();
        value=lockPuzzle.GetSuitAnswer(suit);
    }

    public override void onItemInteract(Item item, int amount = 1)
    {
        
        if (solution != item)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog("That doesn't work."),true);
        }
        else if (solution == item && amount<quanity)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog("Looks like im still missing something"),true);
        }
        else
        {
            isSolvedLine = $"All good. Better hurry. Show starts at {value} O'Clock.";
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(isSolvedLine),true);
            PlayerInventory.Instance.RemoveItem(item,amount);
            isSolved = true; 
        }
    }

    public override void onClick()
    {
        DialogSystem.Instance.PlayDialogImmediately.Invoke(
            new Dialog(isSolved ? isSolvedLine : unSolvedLine),true);
    }

    public override void OnInspect()
    {
        DialogSystem.Instance.PlayDialogImmediately.Invoke(
            new Dialog(isSolved ? isSolvedLine : unSolvedLine),true);
    }
}
