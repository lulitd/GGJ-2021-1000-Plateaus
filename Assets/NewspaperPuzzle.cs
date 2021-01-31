using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperPuzzle : Puzzle
{

    [SerializeField]private Item rope;
    [SerializeField]private Item hankie;
    [SerializeField]private Item parachute;
    private string noItem = "If I had a parachute, I could land safely from the window. Hmm, maybe I could make one?";
    private string noRope = "I can make a parachute using this hanky, but it wouldn't be complete.";
    private string noHankie = "I can make a parachute using this string, but it wouldn't be complete.";
    
    public override void onItemInteract(Item item, int amount = 1)
    {
        
        var hasrope = PlayerInventory.Instance.CheckInventory(rope);
        var hashankie = PlayerInventory.Instance.CheckInventory(hankie);

        if (rope != item && hankie !=item)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog("That doesn't work."),true);
            return; 
        }
        
        
        if (!hashankie && !hasrope)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(isSolved?isSolvedLine:unSolvedLine),true);
            return; 
        }
        else if (hashankie && !hasrope)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(noRope),true);
            return; 
        }else if(!hashankie && hasrope)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(noHankie),true);
        } else if (hashankie && hasrope)
        {
            PlayerInventory.Instance.RemoveItem(rope);
            PlayerInventory.Instance.RemoveItem(hankie);
            PlayerInventory.Instance.AddItem(parachute);
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog("If I take this hanky and string... voila! A parachute"),true);
            isSolved = true; 
        }
       
    }

    public override void onClick()
    {
        var hasrope = PlayerInventory.Instance.CheckInventory(rope);
        var hashankie = PlayerInventory.Instance.CheckInventory(hankie);
        
        if (!hashankie && !hasrope)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(isSolved?isSolvedLine:unSolvedLine),true);
            return; 
        }
        else if (hashankie && !hasrope)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(noRope),true);
            return; 
        }else if(!hashankie && hasrope)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(noHankie),true);
        } else if (hashankie && hasrope)
        {
            PlayerInventory.Instance.RemoveItem(rope);
            PlayerInventory.Instance.RemoveItem(hankie);
            PlayerInventory.Instance.AddItem(parachute);
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog("If I take this hanky and string... voila! A parachute"),true);
            isSolved = true; 
        }
    }
    
    public override void OnInspect()
    {
        var hasrope = PlayerInventory.Instance.CheckInventory(rope);
        var hashankie = PlayerInventory.Instance.CheckInventory(hankie);

        if (!hashankie && !hasrope)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(isSolved?isSolvedLine:unSolvedLine),true);
            return; 
        }
        else if (hashankie && !hasrope)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(noRope),true);
            return; 
        }else if(!hashankie && hasrope)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(noHankie),true);
        } else if (hashankie && hasrope)
        {
            PlayerInventory.Instance.RemoveItem(rope);
            PlayerInventory.Instance.RemoveItem(hankie);
            PlayerInventory.Instance.AddItem(parachute);
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog("If I take this hanky and string... voila! A parachute"),true);
            isSolved = true; 
        }
    }
}