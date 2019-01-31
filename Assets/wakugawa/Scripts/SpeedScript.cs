using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedScript : MonoBehaviour {

    Text SpeedText;

	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text = GameStateStash._maxSpeed.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
