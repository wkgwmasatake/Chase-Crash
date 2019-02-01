using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIScript : MonoBehaviour {

    int OldScore;

	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text = GameStateStash._score.ToString();
        OldScore = (int)GameStateStash._score;
    }

    // Update is called once per frame
    void Update () {
		if(OldScore != GameStateStash._score)
        {
            this.GetComponent<Text>().text = GameStateStash._score.ToString();
            OldScore = (int)GameStateStash._score;
        }
	}
}
