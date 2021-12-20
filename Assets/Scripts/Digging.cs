using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digging : MonoBehaviour
{
    GameObject diggingButton;
    AudioSource diggingSound;
    void Start()
    {
        diggingButton = GetComponent<GameObject>();
        diggingSound = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (diggingButton.gameObject.name == "Brug")
        {
            diggingSound.Play();
        }


    }
}
