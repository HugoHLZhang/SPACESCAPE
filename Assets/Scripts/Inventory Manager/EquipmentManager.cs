using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public int currentlyEquipedItem = 0;
    public Transform currentItemBarrel = null;
    public GameObject currentItemObject = null;

    [SerializeField] public Transform ItemHolderR = null;
    private Animator anim;
    private Inventory inventory;
    private int LayerArms;
    public Animator saberAnim;

    
    [SerializeField] PlayerHUD hud;

    public bool isSwitching;
    private void Start()
    {
        GetReference();
        LayerArms = LayerMask.NameToLayer("Arms");
    }

   

    private void Update()
    {

        //currentItemObject.layer = LayerArms ;
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentlyEquipedItem == 2 && inventory.GetItem(0) != null && isSwitching == false)
        {
            isSwitching = true;
            UnequipItem();
            currentlyEquipedItem = 0;
            anim.SetInteger("itemType", 0);
            //Update itemUI
            hud.UpdateItemUI(inventory.GetItem(0));
            if (inventory.GetItem(2) != null)
            {
                hud.UpdateItemSize(inventory.GetItem(2));
            }
            if (inventory.GetItem(1) != null)
            {
                hud.UpdateItemSize(inventory.GetItem(1));
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && currentlyEquipedItem == 1 && inventory.GetItem(0) != null && isSwitching == false)
        {
            isSwitching = true;
            UnequipItem();
            currentlyEquipedItem = 0;
            FindObjectOfType<AudioManager>().Stop("EquipSaber");
            FindObjectOfType<AudioManager>().Play("PowerDown");
            anim.SetInteger("itemType", 0);
            //Update itemUI
            hud.UpdateItemUI(inventory.GetItem(0));
            if (inventory.GetItem(2) != null)
            {
                hud.UpdateItemSize(inventory.GetItem(2));
            }
            if (inventory.GetItem(1) != null)
            {
                hud.UpdateItemSize(inventory.GetItem(1));
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && currentlyEquipedItem != 1 && isSwitching == false)
        {
            if (inventory.GetItem(1) == null)
            {
                hud.UpdateMessage("Tu n'as pas cet objet. Essaye de le trouver.");
                return;
            }
            isSwitching = true;
            UnequipItem();
            EquipItem(inventory.GetItem(1));
            FindObjectOfType<AudioManager>().Play("EquipSaber");
            hud.UpdateItemSize(inventory.GetItem(0));
            if (inventory.GetItem(2) != null)
            {
                hud.UpdateItemSize(inventory.GetItem(2));
            }
            inventory.GetItem(1).prefab.layer = LayerArms;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && currentlyEquipedItem == 0 && isSwitching == false) 
        {
            if(inventory.GetItem(2) == null)
            {
                hud.UpdateMessage("Tu n'as pas cet objet. Essaye de le trouver.");
                return;
            }
            isSwitching = true;
            UnequipItem();
            EquipItem(inventory.GetItem(2));
            hud.UpdateItemSize(inventory.GetItem(0));
            if (inventory.GetItem(1) != null)
            {
                hud.UpdateItemSize(inventory.GetItem(1));
            }
            //inventory.GetItem(2).prefab.layer = LayerArms;

        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && currentlyEquipedItem == 1 && isSwitching == false)
        {
            if (inventory.GetItem(2) == null)
            {
                hud.UpdateMessage("Tu n'as pas cet objet. Essaye de le trouver.");
                return;
            }
            isSwitching = true;
            UnequipItem();
            FindObjectOfType<AudioManager>().Stop("EquipSaber");
            FindObjectOfType<AudioManager>().Play("PowerDown");
            EquipItem(inventory.GetItem(2));
            hud.UpdateItemSize(inventory.GetItem(0));
            if (inventory.GetItem(1) != null)
            {
                hud.UpdateItemSize(inventory.GetItem(1));
            }
            //inventory.GetItem(2).prefab.layer = LayerArms;

        }


    }

    private void EquipItem(Items item)
    {
        currentlyEquipedItem = (int)item.itemOrder;
        anim.SetInteger("itemType", (int)item.itemType);
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


    

}
