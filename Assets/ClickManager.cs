using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private Camera _mainCamera;

    private void OnEnable()
    {
        _mainCamera = Camera.main;
    }

    void Update () {
        
        if (Input.GetMouseButtonDown(0)) {
            var mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
          
            
            var hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider !=null)
            {
                Debug.Log("hello?");

                var _gameObject = hit.collider.gameObject;

                var _collectable = _gameObject.GetComponent<Collectable>() ;
                
                if (_collectable) _collectable.OnSelect();

            }
        }
    }
}
