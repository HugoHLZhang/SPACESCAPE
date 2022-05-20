using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAntidote : MonoBehaviour
{

    [SerializeField] public float range = 5f;
    [SerializeField] private GameObject table;
    [SerializeField] private GameObject trigger;
    [SerializeField] public bool isGood = false;
    [SerializeField] private ElementsInventory elements;
    [SerializeField] private GameObject antidote;

    private Camera fpscam;
    private PlayerStats stats;
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
        stats = PlayerStats.playerStats;
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckAntidote();
        }


        //hud Update
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            hud.UpdateDoorMessage("E", "Concevoir", true);
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
                if (elements.GetElement(0) != null && elements.GetElement(1) != null && elements.GetElement(2) != null && elements.GetElement(3) != null) { 
                    if (elements.GetElement(0).nom == "C" && elements.GetElement(1).nom == "H" && elements.GetElement(2).nom == "N" && elements.GetElement(3).nom == "O")
                    {
                        isGood = true;
                    }
                }
                if (!antidoteInstantiate && elements.GetElement(0)!=null)
                {
                    hud.UpdateMessage("Tu as déjà créé un antidote ! Teste le !");
                    Instantiate(antidote);
                    antidoteInstantiate = true;
                }
                else if( elements.GetElement(0) == null)
                {
                    hud.UpdateMessage("Trouve des éléments chimiques pour concevoir l'antidote ! Ne fonce pas tête baissée...");
                }
                else
                {
                    hud.UpdateMessage("Teste d'abord l'antidote que tu viens de créer ↜(╰ •ω•)╯ψ");
                }

            }
        }
    }
}
