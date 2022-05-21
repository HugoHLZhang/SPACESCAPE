using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    #region
    public static PlayerHUD hud;

    private void Awake()
    {
        hud = this.GetComponent<PlayerHUD>();
    }
    #endregion

    [SerializeField] private Bar oxygenBar;
    [SerializeField] private Bar healthBar;
    [SerializeField] private Bar poisonBar;

    [SerializeField] private ItemUI hands;
    [SerializeField] private ItemUI saber;
    [SerializeField] private ItemUI gun;

    [SerializeField] private ItemUI element1;
    [SerializeField] private ItemUI element2;
    [SerializeField] private ItemUI element3;
    [SerializeField] private ItemUI element4;

    [SerializeField] private MessageUI message;
    [SerializeField] private MessageUI pickUpMessage;
    [SerializeField] private MessageUI doorMessage;
    [SerializeField] private float messageTiming = 0f;

    [SerializeField] private FadeInOut doorPassword;
    [SerializeField] private DoorPassword passwordText;
    [SerializeField] private DoorsWithPW passwordPopupVaisseau;
    [SerializeField] private DoorsWithPW passwordPopupMorse;

    [SerializeField] private FadeInOut takingDamage;

    private bool fadeOut, fadeIn;

    private void Start()
    {
        message.gameObject.SetActive(false);
        showPasswordAndButtonMorse(false);
        showPasswordAndButtonVaisseau(false);
    }

    private void Update()
    {
        if(messageTiming < Time.time)
        {
            message.gameObject.SetActive(false);
            
        }
    }

    public string readPasswordVaisseau()
    {
        return passwordText.readPasswordVaisseau();
    }

    public string readPasswordMorse()
    {
        return passwordText.readPasswordMorse();
    }

    public void showPasswordAndButtonVaisseau(bool show)
    {
        passwordText.showButtonVaisseau(show);
        passwordText.setBackground(new Color(0.8f, 0, 0, 1));
    }

    public void showPasswordAndButtonMorse(bool show)
    {
        passwordText.showButtonMorse(show);
        passwordText.setBackground(new Color(1, 0.5f, 0, 1)) ;
    }

    public void showInvalidMessage(string message, bool active, Color color)
    {
        passwordText.setMessage(message, color);
        passwordText.invalidMessage.gameObject.SetActive(active);
        
    }

    public void FadeRedScreen()
    {
        takingDamage.Fade();
    }


    public void PopUpDoorWindow()
    {
        if (doorPassword.isFaded)
        {
            doorPassword.Fade();
            passwordPopupVaisseau.popUpIsOpen = !doorPassword.isFaded;
            passwordPopupMorse.popUpIsOpen = !doorPassword.isFaded;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            ClosePopUpWindow();
        }
    }

    public void ClosePopUpWindow()
    {
        doorPassword.Fade();
        passwordPopupVaisseau.popUpIsOpen = !doorPassword.isFaded;
        passwordPopupMorse.popUpIsOpen = !doorPassword.isFaded;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UpdateDoorMessage(string key, string message, bool active)
    {
        doorMessage.UpdateMessage(key + "\n" + message);
        doorMessage.gameObject.SetActive(active);
    }
    public void UpdatePickUpMessage(string key, string message, bool active)
    {
        pickUpMessage.UpdateMessage(key + "\n" + message);
        pickUpMessage.gameObject.SetActive(active);
    }

    public void UpdateMessage(string msg)
    {
        message.gameObject.SetActive(true);
        message.UpdateMessage(msg);
        messageTiming = Time.time + 3f;
    }

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        healthBar.SetValues(currentHealth, maxHealth);
    }

    public void UpdateOxygen(int currentOxygen, int maxOxygen)
    {
        oxygenBar.SetValues(currentOxygen, maxOxygen);
    }

    public void UpdatePoison(int currentPoison, int maxPoison)
    {
        poisonBar.SetValues(currentPoison, maxPoison);
    }

    public void showPoisonBar(bool show)
    {
        poisonBar.gameObject.SetActive(show);
    }



    public void UpdateElementUI(int index, Elements newElements)
    {
        if(index == 0)
        {
            element1.gameObject.SetActive(true);
            element1.UpdateInfo(newElements.icon);
        }
        if (index == 1)
        {
            element2.gameObject.SetActive(true);
            element2.UpdateInfo(newElements.icon);
        }
        if (index == 2)
        {
            element3.gameObject.SetActive(true);
            element3.UpdateInfo(newElements.icon);
        }
        if (index == 3)
        {
            element4.gameObject.SetActive(true);
            element4.UpdateInfo(newElements.icon);
        }
    }

    public void deleteElementUI(int index, Elements element)
    {
        if (index == 0)
        {
            element1.gameObject.SetActive(false);
        }
        if (index == 1)
        {
            element2.gameObject.SetActive(false);
        }
        if (index == 2)
        {
            element3.gameObject.SetActive(false);
        }
        if (index == 3)
        {
            element4.gameObject.SetActive(false);
        }
    }



    public void UpdateItemUI(Items newItem)
    {
        if(newItem.name == "hands")
        {
            hands.UpdateInfo(newItem.icon);
            hands.UpdateSize(newItem.icon, 200f, 200f);
        }
        if(newItem.name == "saber")
        {
            saber.UpdateInfo(newItem.icon);
            saber.UpdateSize(newItem.icon, 200f, 200f);
        }
        if(newItem.name == "gun")
        {
            gun.UpdateInfo(newItem.icon);
            gun.UpdateSize(newItem.icon, 200f, 200f);
        }

    }

    public void UpdateItemSize(Items item)
    {
        if (item.name == "hands")
        {
            hands.UpdateSize(item.icon, 125f, 125f);
        }
        if (item.name == "saber")
        {
            saber.UpdateSize(item.icon, 125f, 125f);
        }
        if (item.name == "gun")
        {
            gun.UpdateSize(item.icon, 125f, 125f);
        }
    }

    public void UpdateItemColor(Items newItem)
    {
        if (newItem.name == "saber")
        {
            saber.UpdateColor(newItem.icon, Color.white);
            FindObjectOfType<AudioManager>().Play("PickupSaber");
        }
        if (newItem.name == "gun")
        {
            gun.UpdateColor(newItem.icon, Color.white);
            FindObjectOfType<AudioManager>().Play("PickupGun");
        }
    }

    
}
