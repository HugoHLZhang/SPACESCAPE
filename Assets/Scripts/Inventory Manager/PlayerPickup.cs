using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask pickupLayer;

    private Camera cam;
    private Inventory inventory;
    [SerializeField]  private PlayerHUD hud;
    [SerializeField]  private Timer timer;

    private PlayerStats stats;

    private void Start()
    {
        GetReference();
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, pickupRange, pickupLayer) && hit.transform.name != null)
        {
            hud.UpdatePickUpMessage("E","PickUp",true);
        }
        else
        {
            hud.UpdatePickUpMessage("", "",false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
            {
                Debug.Log("hit: " + hit.transform.name);
                if (hit.transform.GetComponent<ItemObject>().item as Items)
                {
                    Items newItem = hit.transform.GetComponent<ItemObject>().item as Items;
                    inventory.AddItem(newItem);
                    hud.UpdateMessage("Well played ! You have added " + newItem.nom + " to your inventory !");
                    hud.UpdateItemColor(newItem);
                }
                else
                {
                    Consumable newItem = hit.transform.GetComponent<ItemObject>().item as Consumable;
                    if(newItem.type == ConsumableType.O2)
                    {
                        stats.takeOxygen(newItem.amount);
                        Debug.Log("you got " + newItem.amount + " oxygen");
                    }
                    if (newItem.type == ConsumableType.Medkit)
                    {
                        stats.Heal(newItem.amount);
                        Debug.Log("you healed " + newItem.amount + " HP");
                    }
                    if (newItem.type == ConsumableType.Time)
                    {
                        timer.addTime(newItem.amount);
                        Debug.Log("you added 1minute");
                    }
                }

                Destroy(hit.transform.gameObject);
            }
        }
    }

    private void GetReference()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        stats = GetComponent<PlayerStats>();
        timer = Timer.instanceTimer;
    }
}
