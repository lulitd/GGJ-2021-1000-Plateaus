using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    
    public List<Item> inventory;
    
    public InventoryUI _ui;

    public static PlayerInventory Instance; 
    
    void SetupSingleton()
    {
        if (Instance != null)
        {
            Destroy(this);
        } else
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Awake()
    {

        SetupSingleton();
    }

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

    public void RemoveItem(Item item,int amount=1)
    {
        for (int i = 0; i < amount; i++)
        {
            if (item != null)
            {
                inventory.Remove(item);
                _ui.RemoveInventory(item);
            }
        }
    }

    
    public bool CheckInventory(Item item)
    {
        return inventory.Contains(item);
    }

}
