using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float minX = -60f;
    public float maxX = 60f;
    public float movementSpeed;
    public float speed;
    public float sensitivity;
    public Camera cam;
    float rotX = 0f;
    float rotY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        rotY += Input.GetAxis("Mouse X") * sensitivity;
        rotX += Input.GetAxis("Mouse Y") * sensitivity;

        rotX = Mathf.Clamp(rotX, minX, maxX);

        Quaternion target = Quaternion.Euler(-rotX, rotY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * speed);
    }
}
