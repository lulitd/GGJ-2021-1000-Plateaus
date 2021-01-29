using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Collectable : MonoBehaviour, IInteractable
{

    private SpriteRenderer _renderer;
    private Collider2D _collider2D;

    public Item itemData;
    private bool _isCollectible;
    
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();

        _isCollectible = itemData.isCollectible; 

        if (itemData.sprite != null)
        {
            _renderer.sprite = itemData.sprite;
            
            //resetting the collider to fit correctly based on the sprite. 
            DestroyImmediate(_collider2D);
            _collider2D = gameObject.AddComponent<BoxCollider2D>();
        }
    }

    public void OnSelect()
    {
        DialogSystem.Instance.PlayDialogImmediately.Invoke(
            new DialogSystem.Dialog(itemData.itemDescription),true);
        if (!_isCollectible || !PlayerInventory.Instance) return;
        
        PlayerInventory.Instance.AddItem(itemData);
        Destroy(gameObject);
    }

    [ContextMenu("Set Image from Item data")]
    public void SetImageFromItemData()
    {
        if (itemData == null) return;
        
        if (_renderer == null)
        {
            _renderer = GetComponent<SpriteRenderer>();
        }
        _renderer.sprite = itemData.sprite;
        
        _isCollectible = itemData.isCollectible; 
        if (itemData.sprite != null)
        {
            _renderer.sprite = itemData.sprite;
            DestroyImmediate(_collider2D);

            _collider2D = gameObject.AddComponent<BoxCollider2D>();
        }
    }


    public void BecomeCollectable(bool val)
    {
        _isCollectible = val;
    }

    public void onInteract(Item item, int amount=1)
    {
        Debug.Log(item.name + amount);
    }
}
