using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrainscript : MonoBehaviour
{
    public Transform spawnPos;

    public GameObject currentPrefab;

    public GameObject topLayer;

    public float height = 10f;

    public float width = 10f;

    public float zAxis = 10f;

    public float size = 0.4f;

    public float halfSize = 0.5f;

    public MovePlayer rayScript;

    private void Start()
    {
        rayScript = new MovePlayer();

        currentPrefab.transform.localScale = new Vector3(size, size / 2, size);
        topLayer.transform.localScale = new Vector3(size, size / 2, size);


        rayScript.speed = 100f;

        for (float x = 0; x < width; x++)
        {

            for (float z = 0; z < zAxis; z++)
            {

                for (float y = 0; y < height; y++)
                {

                    if (y == height - 1)
                    {
                        Instantiate(topLayer, new Vector3(spawnPos.position.x + x, spawnPos.position.y + (y / 2), spawnPos.position.z + z), spawnPos.rotation);
                    }
                    else
                    {
                        Instantiate(currentPrefab, new Vector3(spawnPos.position.x + x, spawnPos.position.y + (y / 2), spawnPos.position.z + z), spawnPos.rotation);
                    }
                }

            }

        }

    }
}
