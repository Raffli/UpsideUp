using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    public float moveSpeed;
    public PlayerMovement playerMovement;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!playerMovement.getEnd())
        {
            transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
        }
    }
}
