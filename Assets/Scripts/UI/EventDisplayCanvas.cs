using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDisplayCanvas : MonoBehaviour
{

    [SerializeField] public GameObject Canvas;
    [SerializeField] public GameObject EventSystem;
    void displayCanvas()
    {
        Canvas.SetActive(true);
        EventSystem.SetActive(true);
    }
   
}
