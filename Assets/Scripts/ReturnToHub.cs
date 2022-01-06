using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToHub : MonoBehaviour
{

    public Button continueToHub;
    // Start is called before the first frame update. initializing continue button
    void Start()
    {
        Button btn = continueToHub.GetComponent<Button>();
        btn.onClick.AddListener(GoToHub);
    }

    // Loads the hub when continue is pressed upon victory
    private void GoToHub()
    {
        SceneManager.LoadScene(3);
    }
}
