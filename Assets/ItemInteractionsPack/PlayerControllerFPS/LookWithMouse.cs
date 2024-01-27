// This code is a modification of Unity's First Person Controller

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class LookWithMouse : MonoBehaviour
{
    const float k_MouseSensitivityMultiplier = 0.01f;
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    void Start()
    {
        //CursorLock();
    }

    void Update()
    {
        bool unlockPressed = false;
        bool lockPressed = false;
        float mouseX = 0, mouseY = 0;

#if ENABLE_INPUT_SYSTEM

        if (Mouse.current != null)
        {
            var delta = Mouse.current.delta.ReadValue() / 15.0f;
            mouseX += delta.x;
            mouseY += delta.y;
            lockPressed = Mouse.current.leftButton.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame;
        }
        if (Gamepad.current != null)
        {
            var value = Gamepad.current.rightStick.ReadValue() * 2;
            mouseX += value.x;
            mouseY += value.y;
        }
        if (Keyboard.current != null)
        {
            unlockPressed = Keyboard.current.escapeKey.wasPressedThisFrame;
        }
#else
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        unlockPressed = Input.GetKeyDown(KeyCode.Escape);
        lockPressed = Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1);
#endif
        mouseX *= mouseSensitivity * k_MouseSensitivityMultiplier;
        mouseY *= mouseSensitivity * k_MouseSensitivityMultiplier;

        if (unlockPressed) CursorUnlock();
        if (lockPressed)  CursorLock();

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }


    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
