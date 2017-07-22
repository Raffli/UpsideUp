using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    public GameObject player;
    Animator animator;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    bool up = false;
	void Update () {
        if (player.transform.position.y > 0)
        {
            player.transform.rotation = Quaternion.Euler(180, -90, 0);

        }
        else if (player.transform.position.y < 0) {
            player.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
}
