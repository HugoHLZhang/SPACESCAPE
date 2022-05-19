using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorPassword : MonoBehaviour
{
    [SerializeField] private InputField password;
    [SerializeField] public Text invalidMessage;


    public string readPassword()
    {
        return password.text;
    }

    public void setMessage(string message, Color color)
    {
        invalidMessage.text = message;
        invalidMessage.color = color;
    }

}
