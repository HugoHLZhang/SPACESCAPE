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

    private void Start()
    {
        GetReference();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            Debug.Log("hello");

            if(Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
            {
                
                Items newItem = hit.transform.GetComponent<ItemObject>().item as Items;
                inventory.AddItem(newItem);
                hud.UpdateMessage("Well played ! You have added " + newItem.nom + " to your inventory !");
                Destroy(hit.transform.gameObject);
                hud.UpdateItemColor(newItem);
            }
        }
    }

    private void GetReference()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
    }
}
