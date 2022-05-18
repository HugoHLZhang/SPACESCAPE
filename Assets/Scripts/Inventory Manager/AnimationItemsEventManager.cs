using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationItemsEventManager : MonoBehaviour
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

    public void InstantiateItem()
    {
        manager.currentItemObject =  Instantiate(inventory.GetItem(manager.currentlyEquipedItem).prefab, manager.ItemHolderR);
        manager.currentItemBarrel = manager.currentItemObject.transform.GetChild(0);
        if(manager.currentlyEquipedItem == 1)
        {
            manager.saberAnim = manager.currentItemObject.GetComponent<Animator>();
        }

    }

    public void EndAnimation()
    {
        manager.isSwitching = false;
    }

    public void ExpandSaber()
    {
        manager.saberAnim.SetTrigger("expand");
    }

    public void CollapseSaber()
    {
        manager.saberAnim.SetTrigger("collapse");
    }


    private void GetReference()
    {
        inventory = GetComponentInParent<Inventory>();
        manager = GetComponentInParent<EquipmentManager>();
    }

    public IEnumerator randomfootsteps()
    {
        string random = Random.Range(1, 4).ToString();
        FindObjectOfType<AudioManager>().Play("Footsteps"+random);
        yield return new WaitForSeconds(0.15f);
        FindObjectOfType<AudioManager>().Stop("Footsteps"+random);
    }
}
