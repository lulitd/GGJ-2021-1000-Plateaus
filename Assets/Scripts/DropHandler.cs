using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHandler : MonoBehaviour,IDropHandler
{
    private GraphicRaycaster graphicRaycaster;
  
    public void OnDrop(PointerEventData eventData)
    {
        var r =  transform as RectTransform;
        if (RectTransformUtility.RectangleContainsScreenPoint(r, Input.mousePosition))
        {
            var droppedObject = eventData.pointerDrag;
            var itemUI = droppedObject.GetComponent<itemUIDisplay>();

            if (itemUI != null)
            {
                itemUI.Drop(Input.mousePosition);
            }
        }
    }
}
