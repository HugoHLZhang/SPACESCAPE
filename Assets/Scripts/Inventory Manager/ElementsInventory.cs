using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsInventory : MonoBehaviour
{
    [SerializeField] private Elements[] elements;


    public void Start()
    {
        InitVariables();
    }

    public void AddElement(Elements newItem)
    {
        int newItemIndex = (int)newItem.elementOrder;

        if (elements[newItemIndex] != null)
        {
            RemoveElement(newItemIndex);
        }
        elements[newItemIndex] = newItem;

    }

    public void RemoveElement(int index)
    {
        elements[index] = null;
    }

    public Elements GetElement(int index)
    {
        return elements[index];
    }

    private void InitVariables()
    {
        elements = new Elements[4];
    }
}
