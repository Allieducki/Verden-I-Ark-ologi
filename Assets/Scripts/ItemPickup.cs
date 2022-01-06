using UnityEngine;
using UnityEngine.UI;


// First attempt at pickup method with interactable extension
public class ItemPickup : Interactable
{
    public Transform theDest;
    public Button yourButton;
    int click = 0;

    public override void Interact()
    {
        base.Interact();

        if (click % 2 == 0) 
        { 
            PickUp();
            click++;
        }
        else if(click % 2 == 1)
        {
            Drop();
            click++;
        }



    }

    private void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(Interact);
    }

    void PickUp()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        transform.eulerAngles = new Vector3(0, 0, 0);
        
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;

    }

    void Drop()
    {
        this.transform.parent = null;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
