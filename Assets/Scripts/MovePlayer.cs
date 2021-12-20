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
    // Update is called every frame
    void Update()
    {
        // Checks if Player is standing on ground. if not, starts accelerating the velocity downwards to simulate gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);



        // Moves the player according to the joystick input
        horizontal = joyStick.Horizontal;
        vertical = joyStick.Vertical;
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * Time.deltaTime * speed);



    }
}
