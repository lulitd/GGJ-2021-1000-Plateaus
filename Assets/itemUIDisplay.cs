using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class itemUIDisplay : MonoBehaviour
{
    [SerializeField]private Image _image;
    [SerializeField]private TextMeshProUGUI _textMeshProUgui;
    private int _amount = 1;
    public int Amount => _amount;
    private Item item;
    private void OnEnable()
    {
        // disable it
        if (_textMeshProUgui != null ) _textMeshProUgui.transform.gameObject.SetActive(false);
        
        
    }

    public void SetItem(Item item)
    {
        if (item != null ||_image != null )
        _image.sprite = item.uiSprite ? item.uiSprite : item.sprite;
        gameObject.name = item.name;
        this.item = item; 
    }

    public void UpdateAmount(int amount)
    {
        _amount += amount;
        _textMeshProUgui.text = "x"+_amount.ToString();
        
        _textMeshProUgui.transform.gameObject.SetActive(_amount>1);
    }

    public void Drop(Vector3 screenPosition)
    {
        // TO MERGE:
        
        
        // TO DO RAYCAST: 

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.Raycast(mousePos, Vector2.zero);
            
        if (hit.collider !=null)
        {

            var _collectible = hit.collider.gameObject.GetComponent<IInteractable>();
            
            _collectible?.onInteract(item,_amount);


        }
    }
}
