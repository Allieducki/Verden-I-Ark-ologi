using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameObject objectToDelete;
    [SerializeField] private LayerMask whatIsGridLayer;
    private GameGrid GameGrid;
    
    void Start()
    {
        GameGrid = FindObjectOfType<GameGrid>();
    }



    // Update is called once per frame
    void Update()
    {
        GridCell cellMouseIsOver = isMouseOverAGridSpace();
        if (cellMouseIsOver != null)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(cellMouseIsOver.isOccupied);
                Debug.Log(cellMouseIsOver.GetPosition());
                // Debug.Log(result);
                //cellMouseIsOver.GetComponent<MeshRenderer>().material.color = Color.green;
                // var result = GameGrid.getWorldPositionFromGrid(cellMouseIsOver.GetPosition() - cellMouseIsOver.GetY());



                //cellMouseIsOver.transform.position = cellMouseIsOver.SetVector3(4, 2, 0);


                // cellMouseIsOver.gameObject.transform.position = cellMouseIsOver.GetPosition() - cellMouseIsOver.GetY();

                // cellMouseIsOver.gameObject.transform.position = result;

               
                // Destroy (hitColliders [i].gameObject);
                // Debug.Log(cellMouseIsOver.GetY());
                Destroy(cellMouseIsOver.transform.gameObject);

            //cellMouseIsOver.GetComponentInChildren<SpriteRenderer>().material.color = Color.green;

            }
        }
    }


    private GridCell isMouseOverAGridSpace() 
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, whatIsGridLayer))
        {

       
            return hit.transform.GetComponent<GridCell>();
        }
        else
        {
            return null;
        }
    
    }

}
