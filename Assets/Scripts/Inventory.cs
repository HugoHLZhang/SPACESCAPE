using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Items[] inventory;

    [SerializeField] PlayerHUD hud;

    public void Start()
    {
        GetReference();
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

        //Update itemUI
        hud.UpdateItemUI(newItem);
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

    private void GetReference()
    {
        hud = GetComponent<PlayerHUD>();
    }
}
