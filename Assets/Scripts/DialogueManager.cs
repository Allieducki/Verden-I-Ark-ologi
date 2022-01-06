using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    
    public Text dialogueText;

    public Text dialogName;
    public Animator animator;
    private Queue<string> sentences;

    // Start is called when scene is loaded
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Starts the dialogue when dialogue trigger has been triggered
    public void StartDialogue(Dialogue dialogue) 
    {
        
        dialogName.text = dialogue.name;
        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        
        
    }

    // Changes the dialogue text to the next sentence
    public void DisplayNextSentence() 
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();

        StartCoroutine(TypeSentence(sentence));
    }

    // Types out the sentences letter by letter with a Coroutine
    IEnumerator TypeSentence (string sentence) 
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    //ends the dialogue
   void EndDialogue() 
    {
        Time.timeScale = 1;
        animator.SetBool("IsOpen", false);

    }
}
