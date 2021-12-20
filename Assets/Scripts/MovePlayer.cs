using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public CharacterController controller;

    public float gravity = -9.81f;
    public float speed = 30f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    private Vector3 playerVelocity;
    public Joystick joyStick;

    float vertical = 0f;
    float horizontal = 0f;





    Vector3 velocity;

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        horizontal = joyStick.Horizontal;
        vertical = joyStick.Vertical;

        /*
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        */
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        controller.Move(move * Time.deltaTime * speed);



    }
}
