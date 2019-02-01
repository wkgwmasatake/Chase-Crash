using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedScript : MonoBehaviour {

    byte MaxSpeedArrivalFlg = 0;            // 最大スピードに達したときにちょっとした演出を加える
    float EffectTime = 1.0f;                   // 演出のための変数

    // Use this for initialization
    void Start () {
        this.GetComponent<Text>().text = Mathf.FloorToInt(GameStateStash._speed * 100).ToString();
    }
	
	// Update is called once per frame
	void Update () {
        switch(MaxSpeedArrivalFlg)
        {
            case 0:
                GameStateStash.SpeedUp(0.03f);
                if(GameStateStash._speed >= GameStateStash._maxSpeed)
                {
                    EffectTime -= Time.deltaTime;
                    if (EffectTime < 0)
                    {
                        MaxSpeedArrivalFlg = 1;
                    }
                }
                
                break;

            case 1:
                EffectTime = Random.Range(1.0f, 2.5f);
                GameStateStash.SpeedUp(-0.01f);
                MaxSpeedArrivalFlg = 2;
                break;

            case 2:
                EffectTime -= Time.deltaTime;
                if(EffectTime < 0)
                {
                    EffectTime = Random.Range(1.0f, 3.0f);
                    MaxSpeedArrivalFlg = 0;
                }
                break;
        }
        this.GetComponent<Text>().text = Mathf.FloorToInt(GameStateStash._speed * 100).ToString();
        Debug.Log(MaxSpeedArrivalFlg);
    }
}
