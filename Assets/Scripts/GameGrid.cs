using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{

    private int height = 11;
    private int width = 11;
    private int depth = 11;
    private float gridSpaceSize = 1f;
    public float size = 1f;
    public int artifactAmount;

    private int randomX;
    private int randomY;
    private int randomZ;

    [SerializeField] public GameObject[,,] gameGrid;
    [SerializeField] private GameObject CubePrefab;
    [SerializeField] private GameObject TopLayerPrefab;
    [SerializeField] private GameObject LightPrefab;
    [SerializeField] private GameObject DarkPrefab;
    [SerializeField] private GameObject ArtifactPrefab;
    [SerializeField] private GameObject ClosePrefab;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateGrid());
        PlaceArtifact(artifactAmount);
    }


    public IEnumerator CreateGrid()
    {
        // This gameGrid is used to store all the tiles in
        gameGrid = new GameObject[height, width, depth];

        //CubePrefab.transform.localScale = new Vector3(size, size / 2, size);

        if (CubePrefab == null)
        {
            Debug.Log("Error: Grid cell prefab on the game grid not assigned");
            yield return null;
        }
        // Instantiates 3-dimensional grid of tiles
        for (float y = 0; y < height; y++)
        {
            for (float x = 0; x < width; x++)
            {

                for (float z = 0; z < depth; z++)
                {
                    // Top layer
                    if(y == 9)
                    {
                        InstantiateCube(x, y, z, TopLayerPrefab, 0.2f, -90, false);
                    }
                    // Lightbrown layer
                    else if (y >= 6 && y <= 8)
                    {
                        InstantiateCube(x, y, z, LightPrefab, 0, -90, false);
                    } 
                    // Brown layer
                    else if(y >= 3 && y <= 5)
                    {
                        InstantiateCube(x, y, z, CubePrefab, 0, 0, false);
                    } 
                    // Darkbrown layer
                    else if (y >= 0 && y <= 2)
                    {
                        InstantiateCube(x, y, z, DarkPrefab, 0, -90, false);
                    }
                }
            }
        }

    }

    // Function used to instantiate every cube
    private void InstantiateCube(float x,float y, float z,GameObject cube, float offset, float rotation, bool artifact)
    {
        gameGrid[(int)x, (int)y, (int)z] = Instantiate(cube, new Vector3(x * gridSpaceSize, (y / 2) * gridSpaceSize - (height /2f-0.5f) + offset, z * gridSpaceSize), Quaternion.Euler(rotation, 0, 0));
        gameGrid[(int)x, (int)y, (int)z].GetComponent<GridCell>().SetPosition((int)x, (int)y, (int)z);
        gameGrid[(int)x, (int)y, (int)z].transform.parent = transform;
        // gameGrid[(int)x, (int)y, (int)z].gameObject.tag = "Interactable";
        if (!artifact)
        {
            gameGrid[(int)x, (int)y, (int)z].gameObject.name = "Tile";
        }else if (artifact)
        {
            gameGrid[(int)x, (int)y, (int)z].gameObject.name = "Artifact";
        }
        
        //yield return new WaitForSeconds(.01f);
    }

    // Randomly picks location below the top layer, destroys the current tile in that position and adjacent blocks and
    // instantiates artifact tiles and "close tiles"
    private void PlaceArtifact(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            randomX = Random.Range(0, width);
            randomY = Random.Range(0, height-3);
            randomZ = Random.Range(0, depth);
            Destroy(gameGrid[randomX, randomY, randomZ].gameObject);
            InstantiateCube(randomX, randomY, randomZ, ArtifactPrefab, 0, 0, true);
            try {
                if(gameGrid[randomX + 1, randomY, randomZ].gameObject.name == "Tile")
                {
                    Destroy(gameGrid[randomX + 1, randomY, randomZ].gameObject);
                    InstantiateCube(randomX + 1, randomY, randomZ, ClosePrefab, 0, 0, false);
                }
                
            }catch(System.Exception e)
            {
             
            }

            try
            {
                if (gameGrid[randomX - 1, randomY, randomZ].gameObject.name == "Tile")
                {
                    Destroy(gameGrid[randomX - 1, randomY, randomZ].gameObject);
                    InstantiateCube(randomX - 1, randomY, randomZ, ClosePrefab, 0, 0, false);
                }
            }
            catch (System.Exception e)
            {
              
            }

            try
            {
                if (gameGrid[randomX, randomY + 1, randomZ].gameObject.name == "Tile")
                {
                    Destroy(gameGrid[randomX, randomY + 1, randomZ].gameObject);
                    InstantiateCube(randomX, randomY + 1, randomZ, ClosePrefab, 0, 0, false);
                }
                
            }
            catch (System.Exception e)
            {
            }

            try
            {
                if (gameGrid[randomX, randomY - 1, randomZ].gameObject.name == "Tile")
                {
                    Destroy(gameGrid[randomX, randomY - 1, randomZ].gameObject);
                    InstantiateCube(randomX, randomY - 1, randomZ, ClosePrefab, 0, 0, false);
                }
                
            }
            catch (System.Exception e)
            {
               
            }

            try
            {
                if (gameGrid[randomX, randomY, randomZ + 1].gameObject.name == "Tile")
                {
                    Destroy(gameGrid[randomX, randomY, randomZ + 1].gameObject);
                    InstantiateCube(randomX, randomY, randomZ + 1, ClosePrefab, 0, 0, false);
                }
                
            }
            catch (System.Exception e)
            {
               
            }

            try
            {
                if (gameGrid[randomX, randomY, randomZ - 1].gameObject.name == "Tile")
                {
                    Destroy(gameGrid[randomX, randomY, randomZ - 1].gameObject);
                    InstantiateCube(randomX, randomY, randomZ - 1, ClosePrefab, 0, 0, false);
                }
            }
            catch (System.Exception e)
            {
                
            }
        }
    }

    // Gets grid position in the world
    public Vector3Int GetGridPosFromWorld(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / gridSpaceSize);

        int y = Mathf.FloorToInt(worldPosition.y / gridSpaceSize);

        int z = Mathf.FloorToInt(worldPosition.z / gridSpaceSize);
        x = Mathf.Clamp(x, 0, width);
        y = Mathf.Clamp(x, 0, height);
        return new Vector3Int(x, z, y);
    }

    // Gets world position from grid
    public Vector3 getWorldPositionFromGrid(Vector3Int gridPos)
    {
        float x = gridPos.x * gridSpaceSize;
        float y = gridPos.y * gridSpaceSize;
        float z = gridPos.z * gridSpaceSize;

        return new Vector3(x, y, z);


    }

}
