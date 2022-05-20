using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consumable", menuName = "Items/Elements")]
public class Elements : Item
{
    public ElementsType type;
    public ElementOrder elementOrder;
}

public enum ElementsType { Oxygene, Hydrogene, Azote, Carbone }

public enum ElementOrder { Carbone, Hydrogene, Azote, Oxygene }