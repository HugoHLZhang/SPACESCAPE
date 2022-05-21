using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region
    public static Camera cam;

    private void Awake()
    {
        cam = this.GetComponent<Camera>();
    }
    #endregion


    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform arms;
    [SerializeField] private Transform body;

    private float xRot;
    [SerializeField] private DoorsWithPW doorVaisseau;
    [SerializeField] private DoorsWithPW doorBoss;
    [SerializeField] private DialogueManager dialogueManager;
    private void Start()
    {
        LockCursor();
    }

    private void Update()
    {
        HandleMouseLook();
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);
        if (!doorVaisseau.popUpIsOpen && !dialogueManager.isOpen && !doorBoss.popUpIsOpen )
        {
            arms.localRotation = Quaternion.Euler(new Vector3(xRot, 0, 0));
            body.Rotate(new Vector3(0, mouseX, 0));
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
