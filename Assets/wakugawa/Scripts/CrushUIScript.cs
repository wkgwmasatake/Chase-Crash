using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrushUIScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text = GameStateStash._breakCarCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
