using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float shootTimer = 0;

    private Camera cam;
    private Inventory inventory;
    private EquipmentManager manager;
    private Animator anim;

    private void Start()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        manager = GetComponent<EquipmentManager>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(manager.currentlyEquipedItem == 2)
            {
                Shoot();
            }
            if (manager.currentlyEquipedItem == 1)
            {
                Slash();
            }
        }
    }

    private void RaycastShoot(Items currentItem)
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, currentItem.range))
        {
            Debug.Log(hit.transform.name);
            if(hit.transform.tag == "Destroyable")
            {
                CharacterStats enemyStats = hit.transform.GetComponent<CharacterStats>();
                StartCoroutine(DamageDelay(enemyStats, currentItem));
            }
        }
        
    }
    private IEnumerator DamageDelay(CharacterStats enemyStats, Items currentItem)
    {
        yield return new WaitForSeconds(currentItem.fireRate);
        enemyStats.TakeDamage(currentItem.damage);
    }

    private void Shoot()
    {
        Items currentItem = inventory.GetItem(manager.currentlyEquipedItem);

        if(Time.time > shootTimer + currentItem.fireRate)
        {
            Debug.Log("Shoot");
            shootTimer = Time.time;
            Instantiate(currentItem.gunParticules, manager.currentItemBarrel);
            RaycastShoot(currentItem);
            anim.SetTrigger("isFiring");
        }
    }

    private void Slash()
    {
        Items currentItem = inventory.GetItem(manager.currentlyEquipedItem);

        if (Time.time > shootTimer + currentItem.fireRate)
        {
            Debug.Log(currentItem.fireRate);
            shootTimer = Time.time;
            RaycastShoot(currentItem);
            anim.SetTrigger("isSlashing");
        }
    }
}
