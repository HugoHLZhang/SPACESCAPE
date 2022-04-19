using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    private int currentlyEquipedItem = 0;
    private GameObject currentItemObject = null;

    [SerializeField] private Transform ItemHolderR = null;
    private Animator anim;
    private Inventory inventory;

    [SerializeField] Items defaultItem = null;

    private void Start()
    {
        GetReference();
    }

   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentlyEquipedItem != 0)
        {
            anim.SetTrigger("unequipItem");
            Destroy(currentItemObject);
            anim.SetInteger("itemType", 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentlyEquipedItem != 1)
        {
            UnequipItem();
            EquipItem(inventory.GetItem(1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && currentlyEquipedItem != 2)
        {
            UnequipItem();
            EquipItem(inventory.GetItem(2));
        }
    }

    private void EquipItem(Items item)
    {
        currentlyEquipedItem = (int)item.itemOrder;
        anim.SetInteger("itemType", (int)item.itemType);
        currentItemObject = Instantiate(item.prefab, ItemHolderR);

    }

    private void UnequipItem()
    {
        anim.SetTrigger("unequipItem");
        Destroy(currentItemObject);
    }
    private void GetReference()
    {
        anim = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
    }

}
