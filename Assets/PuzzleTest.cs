using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTest : Puzzle
{
    public override void onInteract(Item item, int amount = 1)
    {
        DialogSystem.Instance.PleasePlayDialog.Invoke(
        new DialogSystem.Dialog("This is a test message. Try again."));
        DialogSystem.Instance.PleasePlayDialog.Invoke(
            new DialogSystem.Dialog("Use a different shape instead."));
        DialogSystem.Instance.PleasePlayDialog.Invoke(
            new DialogSystem.Dialog("Message 3",disappearAfterTime:-1));
        
    }
}
