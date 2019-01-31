using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test01 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.Translate(-0.01f, 0, 0);//左移動
        this.transform.Translate(0.01f, 0, 0);//右移動
    }
}
