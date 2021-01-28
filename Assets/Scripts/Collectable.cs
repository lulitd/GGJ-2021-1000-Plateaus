using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    private SpriteRenderer _renderer;
    private Collider2D _collider2D;

    public Item itemData;
    public bool isCollectable; 
    
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
        
        if (itemData.sprite != null) _renderer.sprite = itemData.sprite;
    }

    public void OnSelect()
    {
        Debug.Log("please?");
        if (!isCollectable || !PlayerInventory.Instance) return;
        
        Debug.Log("collect");
        PlayerInventory.Instance.AddItem(itemData);
        Destroy(gameObject);
    }
}
