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

    public void SetPanelActive() 
    {
        pauseGameUi.SetActive(true);
    }
  

    public void MainMenu() 
    {

        SceneManager.LoadScene(0);
    }

    private void Start()
    {
       
    }

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
