using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public float speed = 10f;
    GameManager gm;
    public GameObject mainCamera;


    void Start () {
		gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        mainCamera = GameObject.FindWithTag("MainCamera");

    }


    void Update()
    {
        if (transform.position.x < (mainCamera.transform.position.x - 30))
        {
            Destroy(gameObject);
        }
        else {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") {
            gm.CoinCollected();
            Destroy(gameObject);
        }
    }

}
