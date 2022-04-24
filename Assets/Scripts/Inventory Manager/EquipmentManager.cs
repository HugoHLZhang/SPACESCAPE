using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public int currentlyEquipedItem = 0;
    public GameObject currentItemObject = null;

    [SerializeField] public Transform ItemHolderR = null;
    private Animator anim;
    private Inventory inventory;

    [SerializeField] Items defaultItem = null;
    [SerializeField] PlayerHUD hud;
    private void Start()
    {
        GetReference();
        InitVariables();
    }

   

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && currentlyEquipedItem != 0 && inventory.GetItem(0) != null)
        {
            UnequipItem();
            currentlyEquipedItem = 0;
            anim.SetInteger("itemType", 0);
            if (currentItemObject != null)
            {
                Destroy(currentItemObject);
            }
            //Update itemUI
            hud.UpdateItemUI(inventory.GetItem(0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentlyEquipedItem != 1)
        {
            if (inventory.GetItem(1) == null)
            {
                Debug.Log("No item here ! Try to find it !");
                return;
            }
            UnequipItem();
            EquipItem(inventory.GetItem(1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && currentlyEquipedItem != 2) 
        {
            if(inventory.GetItem(2) == null)
            {
                Debug.Log("No item here ! Try to find it !");
                return;
            }
            UnequipItem();
            EquipItem(inventory.GetItem(2));
        }
        
        
    }

    private void EquipItem(Items item)
    {
        currentlyEquipedItem = (int)item.itemOrder;
        anim.SetInteger("itemType", (int)item.itemType);
        //Update itemUI
        hud.UpdateItemUI(item);
        
    }

    private void UnequipItem()
    {
        anim.SetTrigger("unequipItem");
    }
    private void GetReference()
    {
        anim = GetComponentInChildren<Animator>();
        inventory = GetComponent<Inventory>();
        hud = GetComponent<PlayerHUD>();
        
    }

    private void InitVariables()
    {
        inventory.AddItem(defaultItem);
    }

}
