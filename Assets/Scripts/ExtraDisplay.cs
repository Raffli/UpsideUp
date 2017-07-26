using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDisplay : MonoBehaviour {

	void Start () {
		
	}
	
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
