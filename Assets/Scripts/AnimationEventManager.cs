using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{

    private EquipmentManager manager;
    private Inventory inventory;

    private void Start()
    {
        GetReference();
    }

    public void DestroyItem()
    {
        Destroy(manager.currentItemObject);
    }

    private void InstantiateItem()
    {
        manager.currentItemObject =  Instantiate(inventory.GetItem(manager.currentlyEquipedItem).prefab, manager.ItemHolderR);
    }

    private void GetReference()
    {
        inventory = GetComponentInParent<Inventory>();
        manager = GetComponentInParent<EquipmentManager>();
    }
}
