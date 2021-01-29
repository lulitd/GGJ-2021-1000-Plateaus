using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Puzzle : MonoBehaviour, IInteractable
{
   private bool isSolved = false;
   private string unSolvedLine = "";
   private string onSolvedLine = "";
   private string isSolvedLine = "";
   private string attemptSolved = "";
   
   void OnInspect()
   {

      Debug.Log(isSolved ? isSolvedLine : unSolvedLine);

   }

   void OnSolved()
   {
      Debug.Log(onSolvedLine);

   }
   
   void OnAttempt()
   {
      Debug.Log(attemptSolved);

   }

   public virtual void onInteract(Item item, int amount = 1)
   {
      
   }
}


