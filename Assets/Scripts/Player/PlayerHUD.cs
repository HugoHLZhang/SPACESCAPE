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

    [SerializeField] private MessageUI message;
    [SerializeField] private MessageUI pickUpMessage;
    [SerializeField] private MessageUI doorMessage;
    [SerializeField] private float messageTiming = 0f;

    [SerializeField] private FadeInOut doorPassword;
    [SerializeField] private DoorPassword passwordText;
    [SerializeField] private DoorsWithPW passwordPopup;

    [SerializeField] private FadeInOut takingDamage;

    private bool fadeOut, fadeIn;

    private void Start()
    {
        message.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(messageTiming < Time.time)
        {
            message.gameObject.SetActive(false);
            
        }
    }

    public string readPassword()
    {
        return passwordText.readPassword();
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
            passwordPopup.popUpIsOpen = !doorPassword.isFaded;
            Debug.Log(passwordPopup.popUpIsOpen);
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
        passwordPopup.popUpIsOpen = !doorPassword.isFaded;
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
