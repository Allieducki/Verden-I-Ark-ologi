using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    CharacterController cc;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.velocity.magnitude > 2f && audio.isPlaying == false)
        {
            //GetComponent<AudioSource>().volume = Random.Range(0.8f, 1);
            audio.volume = Random.Range(0.9f, 1.5f);
            
            audio.pitch = Random.Range(0.8f, 1.1f);
            audio.Play();
        }
    }
}
