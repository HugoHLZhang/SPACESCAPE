using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShooting : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    //public GameObject player;
    public EquipmentManager inventory;
    public Camera fpscam;
    public ParticleSystem fireffect;

    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") )
        {   
            Shoot();
        }
    }

  
    private void Shoot()
    {
        if ( GameObject.Find("Player").GetComponent<EquipmentManager>().GunEquiped == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                
                Target target = hit.transform.GetComponent<Target>();

                if(target!= null)
                {
                    target.TakeDamage(damage);
                }
            }

            fireffect.Play();
        }
    }
   
}
    
