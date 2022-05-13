using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Items")]

public class Items : Item
{
    public GameObject prefab;
    public GameObject gunParticules;
    public float range;
    public int damage;
    public float fireRate;
    public ItemType itemType;
    public ItemOrder itemOrder;
}


public enum ItemType { Hands, Saber, Gun}

public enum ItemOrder { Hands, Primary, Secondary}
