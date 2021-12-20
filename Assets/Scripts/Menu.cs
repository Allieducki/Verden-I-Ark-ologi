using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{

   

    


    public void StartGame() 
    {
        SceneManager.LoadScene("Forrest");

    
    }

    public void QuitGame()
    {

        Application.Quit();
    }

    public void LevelPicked()
    {
        SceneManager.LoadScene("Level 1");


    }

    public void HubArea() 
    {
        SceneManager.LoadScene(2);
    
    }

}
