using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour,IBeginDragHandler, IDragHandler,IEndDragHandler
{

    // for caching purposes
    private Vector3 position;
    private Vector3 scale;
    private Quaternion rotation; 
    private Transform parentTransform; 
       
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentTransform);
        transform.rotation = rotation;
        transform.localScale = scale;
        transform.position = position; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        position = transform.position;
        scale = transform.localScale;
        rotation = transform.rotation;
        parentTransform = transform.parent;

        transform.SetParent(transform.root,true); 
    }
}
