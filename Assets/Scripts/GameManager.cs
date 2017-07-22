using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour {

    public GameObject[] level1Walkable;
    public GameObject[] level1Deadly;
    public GameObject[] level2Walkable;
    public GameObject[] level2Deadly;
    public GameObject floorFolder;
    public Vector3 upperSpawnPosition;
    public Vector3 lowerSpawnPosition;
    public int level;
    public GameObject mainCamera;

    List<GameObject> upperTiles = new List<GameObject>();
    List<GameObject> lowerTiles = new List<GameObject>();

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");

        for (int x = 0; x < 4; x++) {
            upperTiles.Add(Instantiate(level1Walkable[Random.Range(0, level1Walkable.Length - 1)], upperSpawnPosition, Quaternion.identity));
            upperTiles.Last().transform.parent = floorFolder.transform;
            upperSpawnPosition = new Vector3(upperSpawnPosition.x + 9, upperSpawnPosition.y, upperSpawnPosition.z);

            lowerTiles.Add(Instantiate(level1Walkable[Random.Range(0, level1Walkable.Length - 1)], lowerSpawnPosition, Quaternion.identity));
            lowerTiles.Last().transform.parent = floorFolder.transform;
            lowerSpawnPosition = new Vector3(lowerSpawnPosition.x + 9, lowerSpawnPosition.y, lowerSpawnPosition.z);
        }
    }

    void Update () {

        if (upperSpawnPosition.x < (mainCamera.transform.position.x + 20))
        {

            int deadly = Random.Range(0, level+2);
            GameObject upperTile = level1Walkable[Random.Range(0, level1Walkable.Length - 1)];
            GameObject lowerTile = level1Walkable[Random.Range(0, level1Walkable.Length - 1)];

            if (deadly > 1)
            {
                if (Random.Range(0, 1) == 1)
                {
                    upperTile = level1Deadly[Random.Range(0, level1Walkable.Length - 1)];
                }
                else
                {
                    lowerTile = level1Deadly[Random.Range(0, level1Walkable.Length - 1)];
                }
            }

            upperTiles.Add(Instantiate(upperTile, upperSpawnPosition, Quaternion.identity));
            upperTiles.Last().transform.parent = floorFolder.transform;

            lowerTiles.Add(Instantiate(lowerTile, lowerSpawnPosition, Quaternion.identity));
            lowerTiles.Last().transform.parent = floorFolder.transform;

            upperSpawnPosition = new Vector3(upperSpawnPosition.x + 9, upperSpawnPosition.y, upperSpawnPosition.z);
            lowerSpawnPosition = new Vector3(lowerSpawnPosition.x + 9, lowerSpawnPosition.y, lowerSpawnPosition.z);
            if (lowerSpawnPosition.x > 500) {
                level = 2;
            }
        }
    }
}
