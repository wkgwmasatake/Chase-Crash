﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarSponer : MonoBehaviour {

    public GameObject PoliceCar;

    float time = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > 15)
        {
            time = 0;
            //Instantiate(PoliceCar,)
        }
	}
}
