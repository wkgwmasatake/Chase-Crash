using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

    private uint tes; 

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if(GameStateStash._gameOverFlg)         // gameoverflgがtrueならシーン遷移
        {
            //SceneManager.LoadScene("GameOverScene");
            Debug.Log("ゲームオーバーに遷移");
        }
	}
}
