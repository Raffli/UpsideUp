using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowTo : MonoBehaviour {

	void Start () {
        StartCoroutine(Fade());
    }

    void Update () {
		
	}

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(3.5f);
        gameObject.SetActive(false);
    }

}
