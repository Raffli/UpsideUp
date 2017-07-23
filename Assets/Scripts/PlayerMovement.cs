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
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, -180), 10 * turnSpeed * Time.deltaTime);
        }
        else if (player.transform.position.y < 1) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 10 * turnSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger");
        if (other.transform.tag == "Deadly") {
            end = true;
            anim.SetBool("isDead", true);
        }
    }

    public bool getEnd()
    {
        return end;
    }

}
