using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private Key key;


    public void AddItem(Key newItem)
    {
        key = newItem;
    }

    public Key GetItem()
    {
        return key;
    }
}
