using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
   // public GameObject pauseMenu;
    public GameObject panelActive;
    public bool isPaused;
   // public AudioSource sounds;
    void Start()
    {
       //sounds = GetComponent<AudioSource>();
    }

   public void ActivatePanel() 
    {
        panelActive.SetActive(true);
        Time.timeScale = 0f;
        //sounds.Pause();
        isPaused = true;

    }

    public void Resume() 
    {
        panelActive.SetActive(false);
       // sounds.Play();
        Time.timeScale = 1f;
        isPaused = false;
    
    }

    public void QuitGame() 
    {
        SceneManager.LoadScene("Main Menu");
    }

}
