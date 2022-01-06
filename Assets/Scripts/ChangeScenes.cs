using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScenes : MonoBehaviour
{

    // Changes scene when the player enters a trigger
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
    }


}
