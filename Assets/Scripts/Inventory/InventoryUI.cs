using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryContainer;

    [SerializeField] private GameObject inventoryPrefab;

    private Dictionary<Item, itemUIDisplay> items;
    private void OnEnable()
    {   
        if (PlayerInventory.Instance!=null)
        PlayerInventory.Instance._ui = this; 
        
        items = new Dictionary<Item, itemUIDisplay>();
    }

    private void OnDisable()
    {
        if (PlayerInventory.Instance!=null)
        PlayerInventory.Instance._ui = null;
    }
    

    public void AddInventory(Item item)
    {

        if (item == null || inventoryPrefab==null) return;

        if (items.TryGetValue(item, out var display))
        {
            display.UpdateAmount(1);
        }
        else
        {
            var displayGameObject = Instantiate(inventoryPrefab);
            var itemDisplay = displayGameObject.GetComponentInChildren<itemUIDisplay>();
            itemDisplay.SetItem(item);
            displayGameObject.transform.SetParent(inventoryContainer.transform);
            displayGameObject.transform.localScale= Vector3.one; // scale fix. 
            items.Add(item,itemDisplay);
        }

    }
    
    public void RemoveInventory(Item item)
    {
        if (item == null) return;
        
        if (items.TryGetValue(item, out var display))
        {
            if (display.Amount > 1)
            {
                display.UpdateAmount(-1);
            }
            else
            {
                items.Remove(item);

                if (display.parent)
                {
                    var p = display.parent;
                    Destroy(display.parent.gameObject);
                }
                else {Destroy(display.gameObject);}
         
            }
        }
    }

  
    
}
