using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShooting : MonoBehaviour
{
    //private Camera cam;
    //private Inventory inventory;
    //private EquipmentManager manager;

    //private void Start()
    //{
    //    GetReferences();
    //}

    //private void GetReferences()
    //{
    //    cam = GetComponentInChildren<Camera>();
    //    inventory = GetComponent<Inventory>();
    //    manager = GetComponent<EquipmentManager>();
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        Shoot();
    //    }
    //}

    //private void Shoot()
    //{
    //    Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
    //    RaycastHit hit;

    //    if(Physics.Raycast(ray, out hit, inventory.GetItem(manager.currentlyEquipedItem).range))
    //    {
    //        Debug.Log(hit.transform.name);
    //    }
    //}
    //[SerializeField] private int damage = 10;
    //[SerializeField] private float range = 100f;
    ////public GameObject player;
    //public EquipmentManager inventory;
    //public Camera fpscam;
    //public ParticleSystem fireffect;


    //private void Update()
    //{
    //    if (Input.GetButtonDown("Fire1") )
    //    {   
    //        Shoot();
    //    }
    //}


    //private void Shoot()
    //{
    //    if ( GameObject.Find("Player").GetComponent<EquipmentManager>().GunEquiped == true)
    //    {
    //        RaycastHit hit;

    //        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
    //        {

    //            Debug.Log(hit.transform.name);
    //            Target target = hit.transform.GetComponent<Target>();
    //            CharacterStats alienStats = hit.transform.GetComponent<CharacterStats>();
    //            if(target!= null)
    //            {
    //                target.TakeDamage(damage);
    //            }
    //            if(alienStats != null)
    //            {
    //                alienStats.TakeDamage(damage);
    //            }
    //        }

    //        fireffect.Play();
    //    }
    //}

}
    
