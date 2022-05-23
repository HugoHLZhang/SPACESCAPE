using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDisplayCanvas : MonoBehaviour
{

    [SerializeField] public GameObject Canvas;


    private void Start()
    {
        Canvas.SetActive(false);
    }
    void displayCanvas()
    {
        Canvas.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
   
}
