using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Items[] inventory;
    

    public void Start()
    {
        InitVariables();
    }

    public void AddItem(Items newItem)
    {
        int newItemIndex = (int)newItem.itemOrder;

        if (inventory[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        inventory[newItemIndex] = newItem;

    }

    public void RemoveItem(int index)
    {
        inventory[index] = null;
    }

    public Items GetItem(int index)
    {
        return inventory[index];
    }

    private void InitVariables()
    {
        inventory = new Items[3];
    }

}
