using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrushUIScript : MonoBehaviour {

    int OldbreakCarCount;

	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text = GameStateStash._breakCarCount.ToString();
        OldbreakCarCount = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if (OldbreakCarCount != GameStateStash._breakCarCount)
        {
            OldbreakCarCount = GameStateStash._breakCarCount;
            this.GetComponent<Text>().text = GameStateStash._breakCarCount.ToString();
        }
    }
}
