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

    [SerializeField] private ItemUI hands;
    [SerializeField] private ItemUI saber;
    [SerializeField] private ItemUI gun;

    [SerializeField] private MessageUI message;
    [SerializeField] private MessageUI pickUpMessage;
    [SerializeField] private MessageUI doorMessage;
    [SerializeField] private float messageTiming = 0f;

    [SerializeField] private DoorPassword doorPassword;

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


    public void FadeRedScreen()
    {
        takingDamage.Fade();
    }

    public void PopUpDoorWindow()
    {
        doorPassword.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ClosePopUpWindow()
    {
        doorPassword.gameObject.SetActive(false);
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
        }
        if (newItem.name == "gun")
        {
            gun.UpdateColor(newItem.icon, Color.white);
        }
    }

    
}
