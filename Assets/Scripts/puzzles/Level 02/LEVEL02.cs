using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVEL02 : MonoBehaviour
{ 
    // Reeally shooould clean this up and use a dictionary but whoses got time for that. 
    [SerializeField]private GameObject Blocker;
    [SerializeField]private GameObject BackgroundInspect;
    [SerializeField]private GameObject SafeCloseup;
    [SerializeField] private GameObject toolBox;
    [SerializeField]private GameObject BookClub;
    [SerializeField] private GameObject BookGear;
    [SerializeField] private GameObject BookMorse;
    [SerializeField] private GameObject Closet;
    [SerializeField] private GameObject BottomCloset;
    [SerializeField] private GameObject Ship;
    [SerializeField] private GameObject Postcard;
    [SerializeField] private GameObject Clock;
    [SerializeField]private GameObject clouseups;


     public void ShowCloseup(bool show)
    {
        Blocker.SetActive(show);
        BackgroundInspect.SetActive(!show);

        if (show) return;
        for(var i=0; i< clouseups.transform.childCount; i++)
        {
            var child = clouseups.transform.GetChild(i).gameObject;
            if(child != null)
                child.SetActive(show);
        }
    }
    
     public void ShowSafe(bool show)
    {
        ShowCloseup(show);
        SafeCloseup.SetActive(show);
    }

     public void ShowBookClub(bool show)
     {
         ShowCloseup(show);
         BookClub.SetActive(show);
     }

     public void ShowToolbox(bool show)
     {
         ShowCloseup(show);
         toolBox.SetActive(show);
     }
     
     public void ShowBookGear(bool show)
     {
         ShowCloseup(show);
         BookGear.SetActive(show);
     }

     public void ShowBookMorse(bool show)
     {
         ShowCloseup(show);
         BookMorse.SetActive(show);
     }
     
     public void ShowBottomCloset(bool show)
     {
         ShowCloseup(show);
         BottomCloset.SetActive(show);
     }
     
     public void ShowCloset(bool show)
     {
         ShowCloseup(show);
       Closet.SetActive(show);
     }
     public void ShowShip(bool show)
     {
         ShowCloseup(show);
         Ship.SetActive(show);
     }
     
     public void ShowPostcard(bool show)
     {
         ShowCloseup(show);
         Postcard.SetActive(show);
     }

     public void ShowClock(bool show)
     {
         ShowCloseup(show);
         Clock.SetActive(show);
     }

     [ContextMenu("Test Safe")]
     public void TestSafe()
     {
         ShowSafe(!SafeCloseup.activeSelf);
     }
     
     [ContextMenu("Test Book club")]
     public void TestBookClub()
     {
         ShowBookClub(!BookClub.activeSelf);
     }
     
     [ContextMenu("Test toolbox")]
     public void TestToolbox()
     {
         ShowToolbox(!toolBox.activeSelf);
     }
     
        
     [ContextMenu("Test Book Gear")]
     public void TestBookGear()
     {
         ShowBookGear(!BookGear.activeSelf);
     }
     
     [ContextMenu("Test Book Morse")]
     public void TestBookMorse()
     {
         ShowBookMorse(!BookMorse.activeSelf);
     }
}
