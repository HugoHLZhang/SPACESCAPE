using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] public Camera fpscam;
    [SerializeField] public float range = 5f;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject trigger;
    public Animator anim;
    [SerializeField] private bool isOpen= false;


    private void Start()
    {
        door.AddComponent<BoxCollider>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
            {
                Close();

            }
            else
            {
                Open();

            }
        }
    }

    private void Open()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            if (hit.transform.name == trigger.transform.name)
            {
                anim.SetTrigger("open");
                Destroy(door.GetComponent<BoxCollider>());
                isOpen = true;
            }

        }
    }

    private void Close()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            if (hit.transform.name == trigger.transform.name)
            {
                anim.SetTrigger("close");
                door.AddComponent<BoxCollider>();
                isOpen = false;
            }
        }
    }

}