using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaberAttack : MonoBehaviour
{
    [SerializeField] private float damage = 50f;
    [SerializeField] private float range = 5f;
    //public GameObject player;
    public EquipmentManager inventory;
    public Camera fpscam;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }


    private void Attack()
    {
        if (GameObject.Find("Player").GetComponent<EquipmentManager>().SaberEquiped == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();

                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }

}

