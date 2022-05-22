using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consumable", menuName = "Items/Consumable")]
public class Consumable : Item
{
    public ConsumableType type;
    public int amount;
}

public enum ConsumableType { O2, Medkit, Time, MedKit_Virus, Antidote}