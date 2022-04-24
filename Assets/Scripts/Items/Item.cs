using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
