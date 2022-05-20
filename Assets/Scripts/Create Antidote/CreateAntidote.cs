using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAntidote : MonoBehaviour
{
    private Camera fpscam;
    [SerializeField] public float range = 5f;
    [SerializeField] private GameObject table;
    [SerializeField] private GameObject trigger;
    [SerializeField] private bool isGood = false;
    private PlayerHUD hud;

    private void Start()
    {
        fpscam = CameraController.cam;
        hud = PlayerHUD.hud;
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckAntidote();
        }
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            hud.UpdateDoorMessage("E", "Create", true);
        }
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range) && hit.transform.name != trigger.transform.name)
        {
            hud.UpdateDoorMessage("", "", false);
        }


    }

    private void CheckAntidote()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            if (hit.transform.name == trigger.transform.name)
            {
                Debug.Log("hello");
                //check if player have right combinaison of elements in inventory
            }
        }
    }
}
