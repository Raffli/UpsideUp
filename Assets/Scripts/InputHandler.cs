using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    Animator playerAnimator;

    void Start () {
        playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }
	
	void Update () {
		
	}

    public void ChangeGravity()
    {
        playerAnimator.SetTrigger("falling");
        Physics.gravity = new Vector3(0, (-1 * Physics.gravity.y), 0);
    }
}
