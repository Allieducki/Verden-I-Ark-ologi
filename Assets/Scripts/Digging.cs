using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digging : MonoBehaviour
{
    GameObject diggingButton;
    AudioSource diggingSound;

    // Initializes a button and sound
    void Start()
    {
        diggingButton = GetComponent<GameObject>();
        diggingSound = GetComponent<AudioSource>();
    }

    // plays sound if "Brug" button is pressed
    void Update()
    {
        if (diggingButton.gameObject.name == "Brug")
        {
            diggingSound.Play();
        }


    }
}
