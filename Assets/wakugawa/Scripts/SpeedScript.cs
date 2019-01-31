using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedScript : MonoBehaviour {

    Text SpeedText;

	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text = Mathf.FloorToInt(GameStateStash._speed * 100).ToString();
    }
	
	// Update is called once per frame
	void Update () {
        GameStateStash.SpeedUp(0.03f);
        this.GetComponent<Text>().text = Mathf.FloorToInt(GameStateStash._speed * 100).ToString();
    }
}
