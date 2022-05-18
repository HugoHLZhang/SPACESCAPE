using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorPassword : MonoBehaviour
{
    [SerializeField] private InputField password;
    [SerializeField] private Button enter;


    public void readPassword()
    {
        Debug.Log(password.text);
    }

}
