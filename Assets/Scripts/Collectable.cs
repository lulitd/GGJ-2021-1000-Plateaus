using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Collectable : MonoBehaviour, IInteractable
{

    private SpriteRenderer _renderer;
    private Collider2D _collider2D;

    public Item itemData;
    private bool _isCollectible;

    public UnityEvent OnClicked; 
    
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();

        _isCollectible = itemData.isCollectible; 

        if (itemData.sprite != null)
        {
            _renderer.sprite = itemData.sprite;
            
            //reset the collider to fit correctly based on the sprite. 
            DestroyImmediate(_collider2D);
            _collider2D = gameObject.AddComponent<BoxCollider2D>();
        }
    }

    public void OnSelect()
    {
        if (DialogSystem.Instance)
        {
            DialogSystem.Instance.PlayDialogImmediately.Invoke(
                new Dialog(itemData.itemDescription), true);
        }

        OnClicked.Invoke();
        if (!_isCollectible || !PlayerInventory.Instance) return;
        PlayerInventory.Instance.AddItem(itemData);
        Destroy(gameObject);
    }

    [ContextMenu("Set from Item data")]
    public void SetFromItemData()
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

            _collider2D = GetComponent<Collider2D>();
            if (_collider2D != null)
            {
                DestroyImmediate(_collider2D);
                
            }
            _collider2D = gameObject.AddComponent<BoxCollider2D>();
        }

        gameObject.name = itemData.name; 
    }


    public void BecomeCollectable(bool val)
    {
        _isCollectible = val;
    }

    public void onItemInteract(Item item, int amount=1)
    {
        Debug.Log("item?");
        
    }
}
