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

    [SerializeField] private DoorsWithPW door;

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
        if (Input.GetKey(KeyCode.Mouse0) && !door.popUpIsOpen)
        {
                
            if (manager.currentlyEquipedItem == 2)
            {
                Shoot();
            }
            if (manager.currentlyEquipedItem == 1)
            {
                Slash();
            }
        }
    }

    private void RaycastAttack(Items currentItem)
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Ray rayLaser = Camera.main.ScreenPointToRay(Input.mousePosition);
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
        /*
        if (Physics.Raycast(ray,out hit, currentItem.range))
        {
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            //laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 2f);
        }
        */
    }
    private IEnumerator DamageDelay(CharacterStats enemyStats, Items currentItem)
    {
        if (manager.currentlyEquipedItem == 1)
        {
            FindObjectOfType<AudioManager>().Play("SaberHit" + Random.Range(1,4).ToString());
        }
        yield return new WaitForSeconds(currentItem.fireRate);
        enemyStats.TakeDamage(currentItem.damage);   
    }

    private void Shoot()
    {
        Items currentItem = inventory.GetItem(manager.currentlyEquipedItem);

        if(Time.time > shootTimer + currentItem.fireRate)
        {
            //debug.Log("Shoot");
            shootTimer = Time.time;
            Instantiate(currentItem.gunParticules, manager.currentItemBarrel);
            RaycastAttack(currentItem);
            anim.SetTrigger("isFiring");
            FindObjectOfType<AudioManager>().Play("GunSound");
        }
    }

    private void Slash()
    {
        Items currentItem = inventory.GetItem(manager.currentlyEquipedItem);

        if (Time.time > shootTimer + currentItem.fireRate)
        {
            //Debug.Log(currentItem.fireRate);
            shootTimer = Time.time;
            RaycastAttack(currentItem);
            anim.SetTrigger("isSlashing");
            StartCoroutine(playSaberAttackSound());
        }
    }

    public IEnumerator playSaberAttackSound()
    {
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<AudioManager>().Play("SwingSound");
    }

}
