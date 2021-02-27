using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class PreviewToggler : MonoBehaviour,IClickable
{
    private int currentlyActive = 0;
    private GameObject _currentView;
    private List<GameObject> views; 
    void Awake()
    {
        views = new List<GameObject>(); 
        for(int i=0; i< gameObject.transform.childCount; i++) {
            var t =gameObject.transform.GetChild(i).gameObject;

            var shouldIgnore = t.GetComponent<IgnorePreviewToggler>();

            if (shouldIgnore)
            {
                continue;
            }
            
            views.Add(t);
            if (i == currentlyActive)
            {
                _currentView = t; 
                _currentView.SetActive(true);
            }
            else
            {
                t.SetActive(false);
            }
        }
    }


    public void onClick()
    {
        if (views.Count == 0) return; 
        _currentView.SetActive(false);
        currentlyActive = (currentlyActive + 1) % views.Count;
        _currentView = views[currentlyActive];
        _currentView.SetActive(true);
    }
}
