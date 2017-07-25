using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject floorFolder;
    public Vector3 upperSpawnPosition;
    public Vector3 lowerSpawnPosition;
    public int level;
    public int tileSize;
    public float score;
    public GameObject mainCamera;
    public Text scoreText;
    public PlayerMovement playerMovement;
    public int walkableCount;
    public int deadlyCount;
    public static ObjectPooler SharedInstance;

    List<GameObject> upperTiles = new List<GameObject>();
    List<GameObject> lowerTiles = new List<GameObject>();

    void Start()
    {
            mainCamera = GameObject.FindWithTag("MainCamera");

        
    }

    public void startBuilding() {
        for (int x = 0; x < 6; x++)
        {
            upperTiles.Add(ObjectPooler.SharedInstance.GetPooledObject("W" + (Random.Range(1, walkableCount))));
            upperTiles.Last().transform.position = new Vector3(upperSpawnPosition.x, upperSpawnPosition.y, upperSpawnPosition.z);
            upperTiles.Last().transform.rotation = new Quaternion(180, 0, 0, 0);
            upperTiles.Last().SetActive(true);
            upperTiles.Last().transform.parent = floorFolder.transform;
            upperSpawnPosition = new Vector3(upperSpawnPosition.x + tileSize, upperSpawnPosition.y, upperSpawnPosition.z);

            lowerTiles.Add(ObjectPooler.SharedInstance.GetPooledObject("W" + (Random.Range(1, walkableCount))));
            lowerTiles.Last().transform.position = new Vector3(lowerSpawnPosition.x, lowerSpawnPosition.y, lowerSpawnPosition.z);
            lowerTiles.Last().transform.rotation = Quaternion.identity;
            lowerTiles.Last().SetActive(true);
            lowerTiles.Last().transform.parent = floorFolder.transform;
            lowerSpawnPosition = new Vector3(lowerSpawnPosition.x + tileSize, lowerSpawnPosition.y, lowerSpawnPosition.z);
        }
    }

    void Update() {
        if (!playerMovement.getEnd()) {
            if (upperSpawnPosition.x < (mainCamera.transform.position.x + 30))
            {

                int deadly = Random.Range(0, level + 2);
                GameObject upperTile = ObjectPooler.SharedInstance.GetPooledObject("W" + (Random.Range(1, walkableCount)));
                GameObject lowerTile = ObjectPooler.SharedInstance.GetPooledObject("W" + (Random.Range(1, walkableCount)));

                if (deadly > 1)
                {
                    int upper = Random.Range(0, 2);
                    print(upper);
                    if (upper == 1)
                    {
                        upperTile = ObjectPooler.SharedInstance.GetPooledObject("D" + (Random.Range(1, deadlyCount)));
                    }
                    else
                    {
                        lowerTile = ObjectPooler.SharedInstance.GetPooledObject("D" + (Random.Range(1, deadlyCount)));
                    }
                }

                upperTiles.Add(upperTile);
                upperTiles.Last().transform.position = upperSpawnPosition;
                upperTiles.Last().transform.rotation = new Quaternion(180, 0, 0, 0);
                upperTiles.Last().SetActive(true);
                upperTiles.Last().transform.parent = floorFolder.transform;

                lowerTiles.Add(lowerTile);
                lowerTiles.Last().transform.position = lowerSpawnPosition;
                lowerTiles.Last().transform.rotation = Quaternion.identity;
                lowerTiles.Last().SetActive(true);
                lowerTiles.Last().transform.parent = floorFolder.transform;

                upperSpawnPosition = new Vector3(upperSpawnPosition.x + tileSize, upperSpawnPosition.y, upperSpawnPosition.z);
                lowerSpawnPosition = new Vector3(lowerSpawnPosition.x + tileSize, lowerSpawnPosition.y, lowerSpawnPosition.z);

                if (lowerSpawnPosition.x > 500) {
                    level = 2;
                }
                if (lowerSpawnPosition.x > 800)
                {
                    level = 3;
                }
                if (lowerSpawnPosition.x > 1100)
                {
                    level = 4;
                }
            }
            score += 0.1f * level;
            scoreText.text = "Score: " + (int)(score);
        }
    }
}
