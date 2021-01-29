using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Singleton<PlayerInventory>
{
    protected PlayerInventory()
    { }

    public List<Item> inventory;
    
    public InventoryUI _ui;

    public void AddItem(Item item)
    {
        if (item != null)
        {
           
            inventory.Add(item);

            if (_ui != null)
            {
            
                _ui.AddInventory(item);
            }
        }
    }

    public void RemoveItem(Item item)
    {
        if (item != null)
        {
            inventory.Remove(item);
            _ui.RemoveInventory(item);
        }
    }

    
    public bool CheckInventory(Item item)
    {
        return inventory.Contains(item);
    }

}
