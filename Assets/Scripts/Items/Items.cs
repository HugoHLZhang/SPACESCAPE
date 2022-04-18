using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Items")]

public class Items : Item
{
    public GameObject prefab;
    public float range;
    public ItemType itemType;
}


public enum ItemType { Hands, Gun, Saber}

