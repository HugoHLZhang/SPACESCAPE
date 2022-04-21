using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController : MonoBehaviour
{
    Animator armAnim;
    // Start is called before the first frame update
    void Start()
    {
        armAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            armAnim.SetBool("isRunning", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            armAnim.SetBool("isRunning", false);
        }
    }
}
