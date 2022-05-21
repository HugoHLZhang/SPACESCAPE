using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask pickupLayer;

    private Camera cam;
    private Inventory inventory;
    private ElementsInventory elements;
    [SerializeField]  private PlayerHUD hud;
    private Timer timer;
    [SerializeField] private CreateAntidote antidote;

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
            if (hit.transform.GetComponent<ItemObject>().item as Items)
                hud.UpdatePickUpMessage("E","Ramasser",true);
            else if(hit.transform.GetComponent<ItemObject>().item as Consumable)
                hud.UpdatePickUpMessage("E", "Utiliser", true);
            else if(hit.transform.GetComponent<ItemObject>().item as Elements)
                hud.UpdatePickUpMessage("E", "Ramasser", true);
        }
        else
            hud.UpdatePickUpMessage("", "",false);



        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
            {
                if (hit.transform.GetComponent<ItemObject>().item as Items)
                {
                    Items newItem = hit.transform.GetComponent<ItemObject>().item as Items;
                    inventory.AddItem(newItem);
                    hud.UpdateMessage("Bien joué ! Tu as trouvé " + newItem.description + ". Il est ajouté dans ton inventaire.");
                    hud.UpdateItemColor(newItem);
                }
                else if(hit.transform.GetComponent<ItemObject>().item as Consumable)
                {
                    Consumable newItem = hit.transform.GetComponent<ItemObject>().item as Consumable;
                    if(newItem.type == ConsumableType.O2)
                    {
                        stats.takeOxygen(newItem.amount);
                        hud.UpdateMessage("Tu as récupéré " + newItem.amount + "% d'oxygène.");
                        FindObjectOfType<AudioManager>().Play("PickOxygen");
                        Debug.Log("PickOxygen"+Random.Range(1, 2).ToString());
                    }
                    if (newItem.type == ConsumableType.Medkit)
                    {
                        stats.Heal(newItem.amount);
                        hud.UpdateMessage("Tu as récupéré " + newItem.amount + "% PV.");
                        FindObjectOfType<AudioManager>().Play("HealSound");
                    }
                    if (newItem.type == ConsumableType.Time)
                    {
                        timer.addTime(newItem.amount);
                        hud.UpdateMessage("Tu as ajouté 1 minute au minuteur.");
                        FindObjectOfType<AudioManager>().Play("TimeSound");
                    }
                    if (newItem.type == ConsumableType.MedKit_Virus)
                    {
                        stats.Heal(-newItem.amount);
                        hud.UpdateMessage("Ughh pas de chance, ce kit de soin ne convient pas à ton organisme... Tu perds " + newItem.amount + "% PV.");
                        FindObjectOfType<AudioManager>().Play("PoisonSound");
                    }
                    if(newItem.type == ConsumableType.Antidote)
                    {
                        antidote.antidoteInstantiate = false;
                        if (antidote.isGood)
                        {
                            stats.healFromPoison(newItem.amount);
                            hud.UpdateMessage("Bien joué ! L'antidote a parfaitement fonctionné !");
                            hud.showPoisonBar(false);
                            StopCoroutine(stats.increasePoisonTimer());
                            FindObjectOfType<AudioManager>().Play("HealSound");
                        }
                        else
                        {
                            stats.increasePoison(10);
                            hud.UpdateMessage("Cet antidote n'est pas du tout efficace ! Le poison se propage encore plus vite...");
                            FindObjectOfType<AudioManager>().Play("PoisonSound");
                        }
                    }
                }
                else if(hit.transform.GetComponent<ItemObject>().item as Elements)
                {
                    Elements newItem = hit.transform.GetComponent<ItemObject>().item as Elements;
                    elements.AddElement(newItem);
                    hud.UpdateMessage("Tu as ajouté " + newItem.description + " dans ton inventaire.");
                }

                Destroy(hit.transform.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            elements.RemoveElement();
        }
    }

    private void GetReference()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        stats = GetComponent<PlayerStats>();
        timer = Timer.instanceTimer;
        elements = GetComponent<ElementsInventory>();
    }
}
