using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject CubeTrigger;
     bool hasPlayed = false;

    // Triggers the dialogue shown from the dialogue manager
    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed)
        {
        hasPlayed = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
