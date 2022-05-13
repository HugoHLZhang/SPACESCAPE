using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Doors : MonoBehaviour
{
    [SerializeField] public Camera fpscam;
    [SerializeField] public float range = 5f;
    [SerializeField] private GameObject doorFrame;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject trigger;
    [SerializeField] public Animator anim;
    [SerializeField] private bool isOpen= false;
    [SerializeField] private PlayerHUD hud;

    private void Start()
    {
        doorFrame.AddComponent<BoxCollider>();
        door.AddComponent<NavMeshObstacle>();
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
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range) && hit.transform.name == trigger.transform.name && isOpen == true)
        {
            hud.UpdateDoorMessage("E", "Close", true);
        }
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range) && hit.transform.name == trigger.transform.name && isOpen == false)
        {
            hud.UpdateDoorMessage("E", "Open", true);
        }
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range) && hit.transform.name == doorFrame.transform.name && hit.transform.name != trigger.transform.name)
        {
            hud.UpdateDoorMessage("", "", false);
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
                Destroy(doorFrame.GetComponent<BoxCollider>());
                Destroy(door.GetComponent<NavMeshObstacle>());
                isOpen = true;
                hud.UpdateDoorMessage("", "", false);
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
                doorFrame.AddComponent<BoxCollider>();
                door.AddComponent<NavMeshObstacle>();
                isOpen = false;
                hud.UpdateDoorMessage("", "", false);
            }
        }
    }

}