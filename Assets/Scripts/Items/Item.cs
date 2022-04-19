using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public new string name;
    public Sprite icon;
    public string description;

    public virtual void Use()
    {
        Debug.Log(name + "was used");
    }
}