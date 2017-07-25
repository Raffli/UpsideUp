using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    Animator playerAnimator;
    bool isGrounded = true;
    AudioSource audio;
    void Start () {
        playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

    }

    void Update () {
		
	}
    public void ChangeGravity()
    {
        if (isGrounded) {
            playerAnimator.SetTrigger("falling");
            Physics.gravity = new Vector3(0, (-1 * Physics.gravity.y), 0);
            isGrounded = false;
            audio.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent.tag.Contains("W")|| collision.transform.parent.tag.Contains("D"))
        {
            isGrounded = true;
        }
    }
}
