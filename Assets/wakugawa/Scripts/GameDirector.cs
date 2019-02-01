using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

    private uint tes;
    public GameObject SceneMove;
	
	// Update is called once per frame
	void Update () {
        if(GameStateStash._gameOverFlg)         // gameoverflgがtrueならシーン遷移
        {
            PlayerPrefs.SetInt("score", (int)GameStateStash._score);
            PlayerPrefs.SetInt("BreakCarCount", (int)GameStateStash._breakCarCount);
            Instantiate(SceneMove);
            GameStateStash.reStart();
        }
	}
}
