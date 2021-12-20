using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRotation : MonoBehaviour
{

    private Touch initTouch;
    public Camera cam;
    public Transform player;

    private float rotX = 0f;
    private float rotY = 0f;

    private Vector3 origRot;

    public float rotSpeed = 0.005f;
    public float dir = 1;


    // Start is called before the first frame update
    void Start()
    {
        initTouch = new Touch();
        origRot = cam.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            } 
            else if(touch.phase == TouchPhase.Moved)
            {
                //swiping action
                float deltaX = initTouch.position.x - touch.position.x;
                float deltaY = initTouch.position.y - touch.position.y;
                rotX -= deltaY * Time.deltaTime * rotSpeed * 1;
                rotY += deltaX * Time.deltaTime * rotSpeed * 1;
                rotX = Mathf.Clamp(rotX, -80, 80);
                transform.localRotation = Quaternion.Euler(rotX, 0, 0);
                cam.transform.eulerAngles = new Vector3(rotX, rotY, 0);
                player.transform.rotation = Quaternion.Euler(0, rotY, 0);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
    }
}
