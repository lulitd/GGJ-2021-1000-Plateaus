using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject 
{
     public string itemName;
     public string itemDescription;
     public Sprite sprite;
     public bool allowMultiple;
}
