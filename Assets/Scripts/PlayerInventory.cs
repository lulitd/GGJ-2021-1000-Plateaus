using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Singleton<PlayerInventory>
{
    protected PlayerInventory()
    {
    }

    public List<Item> inventory;
    
    private void Start()
    {
        
    }


    public void AddItem(Item item)
    {
        if (item != null)
        {
            if (inventory.Contains(item)) return;
            inventory.Add(item);
        }
    }

    public void RemoveItem(Item item)
    {
        if (item != null)
        {
            inventory.Remove(item);
        }
    }

    public bool CheckInventory(Item item)
    {
        return inventory.Contains(item);
    }

}
