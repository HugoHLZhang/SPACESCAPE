using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckKey : MonoBehaviour
{
    [SerializeField] public float range = 5f;
    [SerializeField] private GameObject trigger;
    [SerializeField] private ElementsInventory elements;

    private Camera fpscam;
    private PlayerHUD hud;

    public bool antidoteInstantiate = false;

    private void Start()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        fpscam = CameraController.cam;
        hud = PlayerHUD.hud;
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            hasKey();
        }


        //hud Update
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range) && hit.transform.name == trigger.transform.name)
        {
            hud.UpdateDoorMessage("E", "Démarrer", true);
        }

    }

    private void hasKey()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            if (hit.transform.name == trigger.transform.name)
            {
                if (elements.GetElement(0) == null)
                {
                    hud.UpdateMessage("Tu n'as pas la clé du vaisseau.");
                    return;
                }
                if (elements.GetElement(0) != null)
                {
                    if (elements.GetElement(0).nom == "Key" || elements.GetElement(1).nom == "Key" || elements.GetElement(2).nom == "Key" || elements.GetElement(3).nom == "Key")
                    {
                        SceneManager.LoadScene(3);
                        FindObjectOfType<AudioManager>().Stop("Theme");
                        FindObjectOfType<AudioManager>().Play("TakeOff");
                    }
                    else
                    {
                        hud.UpdateMessage("Tu n'as pas la clé du vaisseau.");
                    }
                }
                

            }
        }
    }
}
