using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{

    private int posX;
    private int posY;
    private int posZ;
    public GameObject objectInThisGridSpace = null;

    public bool isOccupied = false;

    // Sets the position of each tile in our gamegrid, so that they are easier to fetch later on. 
    public void SetPosition(int x, int y, int z) 
    {
        posX = x;
        posY = y;
        posZ = z;
    }

    // Sets the position of each tile, but with a Vector3Int type
    public Vector3Int SetVector3(int x, int y, int z)
    {
        posX = x;
        posY = y;
        posZ = z;

        return new Vector3Int(posX, posY, posZ);
    }

    // Gets the Vector3Int position of a certain tile
    public Vector3Int GetPosition() 
    {

        return new Vector3Int(posX, posY, posZ);
    
    }

    // Gets the Tile below a certain tile
    public Vector3Int GetY()
    {

        return new Vector3Int(0, posY - 1, 0);

    }
   
}
