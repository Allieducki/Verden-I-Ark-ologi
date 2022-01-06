using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float sensitivity = 100f;
    public Joystick joystick;



    public float xrotation = 0f;
    public Camera cam;

    public float yrotation = 0f;

    public Transform player;

    // Used for initialization 
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // This is used to move the camera. Method is called every fixed frame-rate frame (50 calls per second).
    void FixedUpdate()
    {

        float horizontal = joystick.Horizontal * sensitivity * Time.deltaTime;
        float vertical = joystick.Vertical * sensitivity * Time.deltaTime;
        yrotation += horizontal;
        xrotation -= vertical;


        // clamps to make sure you can spin the camera 360 vertically
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xrotation, yrotation, 0f);
        cam.transform.eulerAngles = new Vector3(xrotation, yrotation, 0);
        player.transform.rotation = Quaternion.Euler(0, yrotation, 0);
    }
}
