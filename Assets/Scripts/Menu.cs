using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    // Loads hub world
    public void StartGame() 
    {
        SceneManager.LoadScene("Forrest");
    }

    // Quits game
    public void QuitGame()
    {
        Application.Quit();
    }

    // Loads level 1
    public void LevelPicked()
    {
        SceneManager.LoadScene("Level 1");
    }

    // Loads level 1 too?
    public void HubArea() 
    {
        SceneManager.LoadScene(2);
    
    }

}
