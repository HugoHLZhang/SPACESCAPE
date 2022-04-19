using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private Transform ItemHolderR = null;
    private Animator anim;
    private Inventory inventory;

    private void Start()
    {
        GetReference();
    }

   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetInteger("itemType",(int)ItemType.Hands);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetItemAnimations(1, ItemType.Saber);
            EquipItem(inventory.GetItem(1).prefab,1);
            anim.SetFloat("Motion",0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetItemAnimations(2, ItemType.Gun);
            EquipItem(inventory.GetItem(2).prefab,2);
        }
    }

    private void SetItemAnimations(int itemOrder, ItemType itemType)
    {
        Items item = inventory.GetItem(itemOrder);
        if(item != null)
        {
            if (item.itemType == itemType)
            {
                anim.SetInteger("itemType", (int)itemType);
            }
        }
    }

    private void EquipItem(GameObject itemObject, int itemOrder)
    {
        Items item = inventory.GetItem(itemOrder);
        if (item != null)
        {
            Instantiate(itemObject, ItemHolderR);
        }
    }
    private void GetReference()
    {
        anim = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
    }

}
