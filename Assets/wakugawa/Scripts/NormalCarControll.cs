using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCarControll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position -= new Vector3(0, 0, 0.5f);

        if(this.transform.position.z < -7.0f)
        {
            Destroy(this.gameObject);
        }
	}
}
