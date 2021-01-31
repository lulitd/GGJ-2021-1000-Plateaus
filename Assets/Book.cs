using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Book : MonoBehaviour,IClickable
{
    private int currentlyActive = 0;
    private GameObject currentPage;
    void Awake()
    {
        for(int i=0; i< gameObject.transform.childCount; i++) {
            var t =gameObject.transform.GetChild(i).gameObject;

            if (i == currentlyActive)
            {
                currentPage = t; 
                currentPage.SetActive(true);
            }
            else
            {
                t.SetActive(false);
            }
        }
    }


    public void onClick()
    {
        currentPage.SetActive(false);
        currentlyActive = (currentlyActive + 1) % gameObject.transform.childCount;
        currentPage = gameObject.transform.GetChild(currentlyActive).gameObject;
        currentPage.SetActive(true);
    }
}
