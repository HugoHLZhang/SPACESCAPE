using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour
{
    [SerializeField] private Text message;

    public void UpdateMessage(string msg)
    {
        message.text = msg;
    }
}
