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
    public GameObject extraDisplay;

    List<GameObject> upperTiles = new List<GameObject>();
    List<GameObject> lowerTiles = new List<GameObject>();
    CameraMover mainCameraMover;
    Animator playerAnimator;

    void Start()
    {
            mainCamera = GameObject.FindWithTag("MainCamera");
            mainCameraMover = mainCamera.GetComponent<CameraMover>();
            playerAnimator = playerMovement.getPlayerAnimator();
        
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
        if (!playerMovement.getEnd())
        {
            if (upperSpawnPosition.x < (mainCamera.transform.position.x + 30))
            {

                int deadly = Random.Range(0, level + 2);
                GameObject upperTile = ObjectPooler.SharedInstance.GetPooledObject("W" + (Random.Range(1, walkableCount)));
                GameObject lowerTile = ObjectPooler.SharedInstance.GetPooledObject("W" + (Random.Range(1, walkableCount)));

                if (deadly > 1)
                {
                    int upper = Random.Range(0, 2);
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

                if (lowerSpawnPosition.x > 400 && lowerSpawnPosition.x < 407)
                {
                    level = 2;
                    mainCameraMover.moveSpeed = 7;
                    playerAnimator.GetComponent<Animator>().speed = 1.5f;
                    playerMovement.turnSpeed = 3;
                    if (Physics.gravity.y < 0)
                    {
                        Physics.gravity = new Vector3(0, -14, 0);
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0, 14, 0);
                    }
                    ShowInfo(level);

                }
                if (lowerSpawnPosition.x > 700 && lowerSpawnPosition.x < 707)
                {
                    level = 3;
                    mainCameraMover.moveSpeed = 9;
                    playerAnimator.GetComponent<Animator>().speed = 2.5f;
                    playerMovement.turnSpeed = 4;
                    if (Physics.gravity.y < 0)
                    {
                        Physics.gravity = new Vector3(0, -16, 0);
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0, 16, 0);
                    }
                    ShowInfo(level);

                }
                if (lowerSpawnPosition.x > 1000 && lowerSpawnPosition.x < 1007)
                {
                    level = 4;
                    mainCameraMover.moveSpeed = 11;
                    playerAnimator.GetComponent<Animator>().speed = 3.5f;
                    playerMovement.turnSpeed = 5;
                    if (Physics.gravity.y < 0)
                    {
                        Physics.gravity = new Vector3(0, -18, 0);
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0, 18, 0);
                    }
                    ShowInfo(level);

                }
                if (lowerSpawnPosition.x > 1200 && lowerSpawnPosition.x < 1207)
                {
                    level = 5;
                    mainCameraMover.moveSpeed = 13;
                    playerAnimator.GetComponent<Animator>().speed = 4.5f;
                    playerMovement.turnSpeed = 6;
                    if (Physics.gravity.y < 0)
                    {
                        Physics.gravity = new Vector3(0, -18, 0);
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0, 18, 0);
                    }
                    ShowInfo(level);
                }
            }
            score += 0.1f * level;
            scoreText.text = "Score: " + (int)(score);
        }
        else
        {
            int score1 = PlayerPrefs.GetInt("Score1");
            int score2 = PlayerPrefs.GetInt("Score2");
            int score3 = PlayerPrefs.GetInt("Score3");
            if (score > score1)
            {
                PlayerPrefs.SetInt("Score1", (int)score);
            }
            else if (score > score2)
            {
                PlayerPrefs.SetInt("Score2", (int)score);
            }
            else if (score > score3)
            {
                PlayerPrefs.SetInt("Score3", (int)score);
            }
        }
    }

    void ShowInfo(int multiplier)
    {
        extraDisplay.GetComponent<Text>().text = multiplier + " x Multiplier";
        extraDisplay.SetActive(true);
    }
}
