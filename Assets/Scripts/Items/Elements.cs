using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consumable", menuName = "Items/Elements")]
public class Elements : Item
{
    public ElementsType type;
    public GameObject prefab;
}

public enum ElementsType { Oxygene, Hydrogene, Azote, Carbone, Argon, Chlore, Helium, Krypton, Xenon, Radon, Fluor, Neon, Key }
