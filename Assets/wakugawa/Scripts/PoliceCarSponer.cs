using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarSponer : MonoBehaviour {

    public GameObject PoliceCar;
    public GameObject[] SpawnPoint;

    float time = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > 15)               // 一定時間経過後に生成(結合後に変更)
        {
            time = 0;
            //Instantiate(PoliceCar,)
        }
	}
}
