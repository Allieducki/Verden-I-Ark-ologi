using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RayCastScript : MonoBehaviour
{
    AudioSource diggingSound;
    public Camera cam;

    public float rayDistance = 5;

    public GameObject focus;

    Color highlightColor = Color.yellow;

    Color defaultColor;

    bool hasInteracted = false;

    GameObject col;
    GameObject itemPick;

    RaycastHit hit;

    private GameGrid GameGrid;

    public Transform theDest;
    bool pickedUp = false;
    public Button pickUp;
    public Button use;


    [SerializeField] private Text artifactsText;
    [SerializeField] private Text victoryText;
    [SerializeField] private Canvas victoryScreen;
    private int artifactsFound = 0;
    public int artifactAmount;
    private float startTime;

    void Start()
    {
        diggingSound = GetComponent <AudioSource> ();
        Button btn = pickUp.GetComponent<Button>();
        btn.onClick.AddListener(PickNDrop);
        Button btn2 = use.GetComponent<Button>();
        btn2.onClick.AddListener(Dig);
        GameGrid = FindObjectOfType<GameGrid>();
        startTime = Time.time;
    }

    private void Dig()
    {
        if (hit.transform != null)
        {
            if (hit.transform.gameObject.tag == "Tile")
            {
                Vector3Int position = hit.transform.gameObject.GetComponent<GridCell>().GetPosition();
                if (itemPick.gameObject.transform.name == "Brush")
                {
                    if (hit.transform.gameObject.name == "Artifact")
                    {
                        artifactsFound += 1;
                        artifactsText.text = "Fund fundet: " + artifactsFound;
                        artifactAmount -= 1;

                        //if artifactAmount = 0 you win the game
                        if(artifactAmount == 0)
                        {
                            float endTime = Mathf.Round((Time.time - startTime)*100f)/100f;
                            victoryText.text = "DU VANDT!\n\nDu fandt: " + artifactsFound + " Fund\n\nTid: " + endTime + " Sekunder";
                            victoryScreen.gameObject.SetActive(true);
                        }
                    }
                    DestroyObject(hit.transform.gameObject); 
                }
                if (itemPick.gameObject.transform.name == "Shovel")
                {
                    diggingSound.Play();
                    if (hit.transform.gameObject.name == "Artifact")
                    {
                        artifactsFound += 1;
                        artifactsText.text = "Fund fundet: " + artifactsFound;
                        artifactAmount -= 1;

                        //if artifactAmount = 0 you win the game
                        if (artifactAmount == 0)
                        {
                            Debug.Log("YOU WIN");
                        }
                    }
                    DestroyObject(hit.transform.gameObject);
                    DestroyObject(GameGrid.gameGrid[position.x, position.y - 1, position.z].gameObject);
                }
            }
        }
    }




    private void PickNDrop()
    {
        if (pickedUp == false && hit.transform!=null)
        {
            itemPick = col;
            PickUp();
        }
        else if (pickedUp == true)
        {
            Drop();
            itemPick = null;
        }
    }

    //Picks up tool to dig with
    void PickUp()
    {
        itemPick.transform.GetComponent<BoxCollider>().enabled = false;
        itemPick.transform.GetComponent<Rigidbody>().useGravity = false;
        itemPick.transform.GetComponent<Rigidbody>().isKinematic = true;
        itemPick.transform.parent = GameObject.Find("Destination").transform;
        itemPick.transform.localPosition = new Vector3(0.79f, 0,0);
        if(itemPick.transform.name == "Shovel")
        {
            itemPick.transform.localEulerAngles = new Vector3(180, 0, 180);
        }
        if(itemPick.transform.name == "Brush")
        {
            itemPick.transform.localPosition = new Vector3(0.79f, 0, 0.5f);
            itemPick.transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        
        pickedUp = true;
    }

    //Drops tool
    void Drop()
    {
        itemPick.transform.parent = null;
        itemPick.transform.GetComponent<BoxCollider>().enabled = true;
        itemPick.transform.GetComponent<Rigidbody>().useGravity = true;
        itemPick.transform.GetComponent<Rigidbody>().isKinematic = false;
        pickedUp = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, cam.nearClipPlane));
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (col != hit.transform.gameObject&& hasInteracted == true)
            {
                RemoveFocus();
            }
            var tag = hit.transform.gameObject.tag;
            col = hit.transform.gameObject;
            if(tag == "Interactable" && hasInteracted == false)
            {
                SetFocus();
            }

            

            //TODO Add switch for different tags to reference
            /* if (Input.GetKeyDown("space") && tag !=null)
            {
                switch (tag)
                {
                    case "Interactable":

                        break;
                    case "Digsite":
                        DestroyObject(hit.transform.gameObject);
                        break;
                }
            }*/

            

            Debug.DrawLine(ray.origin, hit.point, Color.red);

            
        }
        else
        {

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayDistance, Color.green);
            if (hasInteracted == true)
            {
                RemoveFocus();
            }
            
        }
    }

    void DestroyObject(GameObject destroyedObject) 
    {
        Destroy(destroyedObject);
    
    }

    void SetFocus()
    {

        
        defaultColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
        
        var selectionRenderer = hit.transform.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material.color = highlightColor;
        }
        hasInteracted = true;
        
    }

    void RemoveFocus()
    {
        var selectionRenderer = col.transform.GetComponent<Renderer>();
        selectionRenderer.material.color = defaultColor;
        hasInteracted = false;
    }

    void Tools(GameObject itemToUse) 
    {
    
    

    }
}