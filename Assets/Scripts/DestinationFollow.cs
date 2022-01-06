using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationFollow : MonoBehaviour
{
    public Transform Cam;
    public Vector3 Offset;

    // LateUpdate is called after all Update functions have been called. this late update. 
    // this LateUpdate is used to update the position of the held tool
    void LateUpdate()
    {
        transform.position = Cam.position + Offset;
        transform.rotation = Cam.rotation;
    }
}
