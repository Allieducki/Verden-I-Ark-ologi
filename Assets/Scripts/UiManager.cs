using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Test to try to make floating text in hub world
public class UiManager : MonoBehaviour
{

    public Text textPrefab;

    private Text textUi;



    // Start is called before the first frame update
    void Start()
    {

        textUi = Instantiate(textPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {

        textUi.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }
}
