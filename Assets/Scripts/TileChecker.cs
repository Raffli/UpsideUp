using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChecker : MonoBehaviour {

    public GameObject mainCamera;
	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < (mainCamera.transform.position.x - 30)) {
            gameObject.SetActive(false);
            gameObject.transform.parent = null;
        }
		
	}
}
