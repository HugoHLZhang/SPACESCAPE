using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Doors : MonoBehaviour
{
    private Camera fpscam;
    [SerializeField] public float range = 5f;
    [SerializeField] private GameObject doorFrame;
    [SerializeField] private GameObject trigger;
    [SerializeField] public Animator anim;
    [SerializeField] private bool isOpen= false;
    private PlayerHUD hud;

    private void Start()
    {
        
        fpscam = CameraController.cam;
        hud = PlayerHUD.hud;
        doorFrame.GetComponent<NavMeshObstacle>().enabled = true;
        doorFrame.GetComponent<BoxCollider>().enabled = true;
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
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range) && hit.transform.tag == doorFrame.transform.tag && hit.transform.name != trigger.transform.name)
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
                doorFrame.GetComponent<BoxCollider>().enabled = false;
                doorFrame.GetComponent<NavMeshObstacle>().enabled = false;
                isOpen = true;
                hud.UpdateDoorMessage("", "", false);
                FindObjectOfType<AudioManager>().Play("DoorSound");
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
                doorFrame.GetComponent<BoxCollider>().enabled = true;
                doorFrame.GetComponent<NavMeshObstacle>().enabled = true;
                isOpen = false;
                hud.UpdateDoorMessage("", "", false);
                FindObjectOfType<AudioManager>().Play("DoorSound");
            }
        }
    }

}