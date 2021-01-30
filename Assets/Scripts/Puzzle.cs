using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Puzzle : MonoBehaviour, IInteractable, IClickable
{
   [SerializeField] protected bool isSolved = false;
   [SerializeField] protected string unSolvedLine = "";
   [SerializeField]protected string onSolvedLine = "";
   [SerializeField] protected string isSolvedLine = "";
   [SerializeField]protected string attemptSolved = "";

   public bool IsSolved => isSolved;

   public virtual void OnInspect()
   {

      Debug.Log(isSolved ? isSolvedLine : unSolvedLine);

   }

   public virtual void OnSolved()
   {
      Debug.Log(onSolvedLine);

   }
   
   public virtual void OnAttempt()
   {
      Debug.Log(attemptSolved);

   }

   public virtual void onInteract(Item item, int amount = 1)
   {
      
   }

   public virtual void onClick()
   {
   }
}


