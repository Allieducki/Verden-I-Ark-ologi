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

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }


    void FixedUpdate()
    {

        float horizontal = joystick.Horizontal * sensitivity * Time.deltaTime;

        float vertical = joystick.Vertical * sensitivity * Time.deltaTime;

        yrotation += horizontal;

        xrotation -= vertical;



        xrotation = Mathf.Clamp(xrotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xrotation, yrotation, 0f);
        cam.transform.eulerAngles = new Vector3(xrotation, yrotation, 0);
        player.transform.rotation = Quaternion.Euler(0, yrotation, 0);
        //transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);




    }
}
