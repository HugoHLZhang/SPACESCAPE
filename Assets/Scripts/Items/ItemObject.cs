using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item;

    public void Update()
    {
        if(item.nom == "Timer" || item.nom == "Key")
        {
            gameObject.transform.Rotate(Vector3.up, 50f * Time.deltaTime, Space.World);
        }
    }
}
