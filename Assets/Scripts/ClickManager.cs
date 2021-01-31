using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour
{
    private Camera _mainCamera;
    private RaycastHit2D[] hits;
    [SerializeField] private GameObject blocker;

    public UnityEvent OnHitBlocker; 

    private void OnEnable()
    {
        _mainCamera = Camera.main;
        hits= new RaycastHit2D[5];
        if (!blocker)
            blocker = GameObject.FindWithTag("Blocker");
    }

    void Update () {
        
        if (Input.GetMouseButtonDown(0)) {
            
            var mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                return;
            }
            var amount = Physics2D.RaycastNonAlloc(mousePos, Vector2.zero,hits);

           
            if (blocker && blocker.activeInHierarchy && amount == 1)
            {
                
             OnHitBlocker.Invoke(); 
             return;
            }
            for (var i = 0; i < amount; i++)
            {
                var hit = hits[i];

                var _gameObject = hit.collider.gameObject;
                if (_gameObject.CompareTag("Blocker")) continue; 
                
                    var collectible = _gameObject.GetComponent<Collectable>() ;
                    if (collectible)
                    {
                        collectible.OnSelect();
                    }
                    else
                    {
                        var click = _gameObject.GetComponent<IClickable>();
                        if(click !=null) click.onClick();
                        else
                        {
                            var puzzle = _gameObject.GetComponentInParent<Puzzle>();
                            if(puzzle!=null) puzzle.OnInspect();
                            else
                            { 
                              var p =  _gameObject.GetComponentInParent<IClickable>();
                              p?.onClick();
                            }
                           
                        }
                    }

            } 
            
           
        }
    }
    }

