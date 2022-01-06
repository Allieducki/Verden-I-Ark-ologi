using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//First iteration of player movement
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public Joystick joyStick;

    public float playerSpeed = 4.0f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 move = transform.right * joyStick.Horizontal + transform.forward * joyStick.Vertical;
        
        controller.Move(move * Time.deltaTime * playerSpeed);
        
    }
}
