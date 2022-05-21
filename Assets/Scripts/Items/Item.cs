using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public string nom;
    public Sprite icon;
    public string description;

    public virtual void Use()
    {
        Debug.Log(nom + "was used");
    }
}
