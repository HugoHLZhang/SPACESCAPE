using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] public Camera fpscam;
    [SerializeField] public float range = 5f;
    [SerializeField] private GameObject door;
    public Animator anim;
    public static bool isOpen = false;

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
            if (hit.transform.name == "Trigger")
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
            if (hit.transform.name == "Trigger")
            {
                anim.SetTrigger("close");
                door.AddComponent<BoxCollider>();
                isOpen = false;
            }

        }
    }
}