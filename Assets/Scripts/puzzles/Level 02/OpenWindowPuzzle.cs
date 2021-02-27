using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenWindowPuzzle : Puzzle
{
    private bool didReadNewspaper;
    public Item parachute;
    public Item newspaper;

    public string noClue; 
    public string onFirstRead;
    public string noClip;
    public UnityEvent onFinishLevel;
    
    public override void onClick()
    {
        var hasChute = PlayerInventory.Instance.CheckInventory(parachute);
        if (!hasChute)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(noClue),true);
            return;
        }
        
        var hasClipping = PlayerInventory.Instance.CheckInventory(newspaper);

        if (!hasClipping)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(noClip),true);
            return;
        }
        if (hasChute && hasClipping)
        {   DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(isSolvedLine),true);
            isSolved = true;
            onFinishLevel.Invoke();
            return;
        }
    }

    public override void OnInspect()
    {
        var hasChute = PlayerInventory.Instance.CheckInventory(parachute);
        if (!hasChute)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(noClue),true);
            return;
        }
        
        var hasClipping = PlayerInventory.Instance.CheckInventory(newspaper);

        if (!hasClipping)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(noClip),true);
            return;
        }
        
        if (hasChute && hasClipping)
        {   DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(isSolvedLine),true);
            isSolved = true;
            onFinishLevel.Invoke();
            return;
        }
    }
    
    public override void onItemInteract(Item item, int amount = 1)
    {
        var hasClipping = PlayerInventory.Instance.CheckInventory(newspaper);
        var hasChute = PlayerInventory.Instance.CheckInventory(parachute);
        
        if (parachute!= item &&  newspaper!=item)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog("That doesn't work."),true);
        }
    
        if (!hasClipping)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(noClip),true);
            return;
        }
        
        if (!hasChute)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(noClue),true);
            return;
        }

        if (hasChute && hasClipping)
        {   DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(isSolvedLine),true);
            isSolved = true;
            onFinishLevel.Invoke();
            return;
        }
        
    }
    
    
   
    
}
