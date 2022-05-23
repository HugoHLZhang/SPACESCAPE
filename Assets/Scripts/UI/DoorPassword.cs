using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorPassword : MonoBehaviour
{
    [SerializeField] public Text titre;
    [SerializeField] public InputField passwordVaisseau;
    [SerializeField] public InputField passwordMorse;
    [SerializeField] public Text invalidMessage;
    [SerializeField] private Image background;
    [SerializeField] private Button buttonVaisseau;
    [SerializeField] private Button buttonMorse;
    [SerializeField] private Button closeButton;

    public string readPasswordVaisseau()
    {
        return passwordVaisseau.text;
    }
     public string readPasswordMorse()
    {
        return passwordMorse.text;
    }

    public void setMessage(string message, Color color)
    {
        invalidMessage.text = message;
        invalidMessage.color = color;
    }

    public void setBackground(Color color)
    {
        background.color = color;
    }

    public void showButtonVaisseau(bool show)
    {
        titre.gameObject.SetActive(show);
        buttonVaisseau.gameObject.SetActive(show);
        passwordVaisseau.gameObject.SetActive(show);
        closeButton.gameObject.SetActive(show);
        invalidMessage.gameObject.SetActive(show);
        
    } 
    public void showButtonMorse(bool show)
    {
        titre.gameObject.SetActive(show);
        buttonMorse.gameObject.SetActive(show);
        passwordMorse.gameObject.SetActive(show);
        closeButton.gameObject.SetActive(show);
        invalidMessage.gameObject.SetActive(show);
    }
}
