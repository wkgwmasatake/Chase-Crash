using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarSponer : MonoBehaviour {

    public GameObject PoliceCar;
    public GameObject[] SpawnPoint;

    public PlayerController PlayerInfo;

    float time = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > 3)               // 一定時間経過後に生成(結合後に変更)
        {
            Transform PlayerTransform = PlayerInfo.GetComponent<PlayerController>().ReturnPlayerTransform();

            if ((PlayerTransform.position.x + 8) / 4 == 0)     // レーンの左端にいたら
            {
                Instantiate(PoliceCar, SpawnPoint[(((int)PlayerTransform.position.x + 8) / 4) + 1].transform);      // プレイヤーの右側に生成
            }
            else if((PlayerTransform.position.x + 8) / 4 == 4)  // レーンの右端にいたら
            {
                Instantiate(PoliceCar, SpawnPoint[(((int)PlayerTransform.position.x + 8) / 4) - 1].transform);      // プレイヤーの左側に生成
            }
            else if (Random.Range(-1.0f, 1.0f) < 0)             // ランダム値が0未満なら
            {
                Instantiate(PoliceCar, SpawnPoint[(((int)PlayerTransform.position.x + 8) / 4) + 1].transform);      // プレイヤーの右側に生成
            }
            else                                                // ランダム値が0以上なら
            {
                Instantiate(PoliceCar, SpawnPoint[(((int)PlayerTransform.position.x + 8) / 4) - 1].transform);      // プレイヤーの左側に生成
            }
            time = 0;
            //Instantiate(PoliceCar,)
        }
	}
}
