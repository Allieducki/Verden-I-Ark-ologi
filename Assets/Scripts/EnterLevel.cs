using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterLevel : MonoBehaviour
{
 
    // Loads level 1 when walking through trigger in hub
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);
    }
}
