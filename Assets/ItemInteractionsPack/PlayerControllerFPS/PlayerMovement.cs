// This code is a modification of Unity's First Person Controller

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -10f;
    public float jumpHeight = 2f;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;


    void Update()
    {
        float x;
        float z;       


        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        bool jumpPressed = false;
        jumpPressed = Input.GetButtonDown("Jump");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (jumpPressed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //controller.Rotate(Vector3.up * Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime);
    }
}
