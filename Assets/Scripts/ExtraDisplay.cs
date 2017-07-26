using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(Fade());
    }
}
