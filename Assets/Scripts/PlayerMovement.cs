using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    public GameObject player;
    public int turnSpeed;
    public Animator anim;
    public bool end;
    void Start () {
        anim = GetComponent<Animator>();
    }


	void Update () {
        if (player.transform.position.y > 1)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), 10 * turnSpeed * Time.deltaTime);
        }
        else if (player.transform.position.y < 1) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), 10 * turnSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Contains("D")) {
            end = true;
            anim.SetBool("isDead", true);
        }
    }

    public bool getEnd()
    {
        return end;
    }

    public Animator getPlayerAnimator()
    {
        return anim;
    }

}
