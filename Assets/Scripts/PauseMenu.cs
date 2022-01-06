using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
  
    public static bool gameIsPaused = false;

    public GameObject pauseGameUi;

    

    public GameObject MenuItem;

   // public Button wasPressed;


    public static bool MenuButtonPressed = false;

    // sets pause screen to be active
    public void SetPanelActive() 
    {
        pauseGameUi.SetActive(true);
    }
  
    // Loads main menu from pause screen
    public void MainMenu() 
    {

        SceneManager.LoadScene(0);
    }

    // if pausing, pause gameplay
    void Update()
    {

      

        if (Input.GetKeyDown(KeyCode.Escape))
        {



        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();


        }
            
        }
   

    }

     


    public void Resume() 
    {
        pauseGameUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    
    }

    public void Pause() 
    {
        pauseGameUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
