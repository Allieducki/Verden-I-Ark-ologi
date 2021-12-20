using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Cam;
    public Vector3 Offset;

    void LateUpdate()
    {
        
        transform.position = Cam.position + Offset;
        transform.rotation = Cam.rotation;
    }
}
