using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTime : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("DestroyTime");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
}
