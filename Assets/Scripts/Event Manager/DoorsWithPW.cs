using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorsWithPW : MonoBehaviour
{
    private Camera fpscam;
    [SerializeField] public float range = 5f;
    [SerializeField] private GameObject doorFrame;
    [SerializeField] private GameObject trigger;
    [SerializeField] private GameObject trigger2;
    [SerializeField] public Animator anim;
    [SerializeField] private bool isOpen = false;
    private PlayerHUD hud;
    private bool isValid;
    [SerializeField] public bool popUpIsOpen = false;

    [SerializeField] private string password;
    private bool isNumber;

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
        if(!popUpIsOpen)
        {
            hud.showPasswordAndButtonVaisseau(false);
            hud.showPasswordAndButtonMorse(false);
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
            
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range) && hit.transform.name == trigger.transform.name && isOpen == true)
        {
            hud.UpdateDoorMessage("E", "Fermer", true);
        }
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range) && hit.transform.name == trigger.transform.name && isOpen == false)
        {
            hud.UpdateDoorMessage("E", "Ouvrir", true);
        }
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range) && hit.transform.name == trigger2.transform.name && isOpen == true)
        {
            hud.UpdateDoorMessage("E", "Fermer", true);
        }
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range) && hit.transform.name == trigger2.transform.name && isOpen == false)
        {
            hud.UpdateDoorMessage("E", "Ouvrir", true);
        }
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range) && hit.transform.tag == doorFrame.transform.tag && hit.transform.name != trigger.transform.name && hit.transform.name != trigger2.transform.name)
        {
            hud.UpdateDoorMessage("", "", false);
        }


    }

    private void Open()
    {


        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            if (hit.transform.name == trigger.transform.name || hit.transform.name == trigger2.transform.name)
            {
                hud.showInvalidMessage("", false, new Color(0, 0, 0, 0));
                hud.showPasswordAndButtonVaisseau(false);
                hud.showPasswordAndButtonMorse(false);
                if (!isValid)
                {
                    hud.PopUpDoorWindow();
                    if(password == "660")
                        hud.showPasswordAndButtonVaisseau(true);
                    else if( password == "ESIEE")
                        hud.showPasswordAndButtonMorse(true);

                }
                else
                {
                    anim.SetTrigger("open");
                    doorFrame.GetComponent<BoxCollider>().enabled = false;
                    doorFrame.GetComponent<NavMeshObstacle>().enabled = false;
                    isOpen = true;
                    hud.showInvalidMessage("Mot de passe correte. Passez au niveau suivant.", true, new Color(1, 0.75f, 0, 1));

                    hud.UpdateDoorMessage("", "", false);
                    FindObjectOfType<AudioManager>().Play("DoorSound");
                }
            }

        }
    }


    public void CheckPassword()
    {
        if (password == "660")
        {
            int intPassword;
            isNumber = int.TryParse(hud.readPasswordVaisseau(), out intPassword);
            Debug.Log(isNumber);
            Debug.Log(intPassword);
            if (isNumber)
                if (int.Parse(password) - 50 <= intPassword && intPassword <= int.Parse(password)) isValid = true;
                else { isValid = false; }
            else { isValid = false; }
        }
        else if (password == "ESIEE")
            if (hud.readPasswordMorse() == password) isValid = true;
            else { isValid = false; }
    }

    public void OpenDoor()
    {
        if (isValid)
        {
            anim.SetTrigger("open");
            doorFrame.GetComponent<BoxCollider>().enabled = false;
            doorFrame.GetComponent<NavMeshObstacle>().enabled = false;
            isOpen = true;
            hud.showInvalidMessage("Mot de passe correte. Passez au niveau suivant.", true, new Color(0,0.75f,0,1));
            hud.ClosePopUpWindow();
            hud.UpdateDoorMessage("", "", false);
            FindObjectOfType<AudioManager>().Play("DoorSound");
        }
        else
        {
            hud.showInvalidMessage("Mot de passe incorrecte. Veuillez réessayer.", true, new Color(0.75f, 0, 0,1));
        }
        
    }

    private void Close()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {

            if (hit.transform.name == trigger.transform.name || hit.transform.name == trigger2.transform.name)
            {

                anim.SetTrigger("close");
                doorFrame.GetComponent<BoxCollider>().enabled = true;
                doorFrame.GetComponent<NavMeshObstacle>().enabled = true;
                isOpen = false;
                hud.showInvalidMessage("", false, new Color(0,0,0,0));
                hud.UpdateDoorMessage("", "", false);
                FindObjectOfType<AudioManager>().Play("DoorSound");
            }
        }
    }

}