using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMoveTo : MonoBehaviour {

    [SerializeField] float ReStartPosZ;     //リスタートする位置(２つ目のの道路の初めの位置)
    [SerializeField] float DeletePosZ;      //消すＺ座標
    private Vector3 bufPos;
    private float PosZdiff;                 //所定の位置と実際に消えた位置の差分

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position -= new Vector3(0, 0, GameStateStash._speed * 1.5f);

        if(this.transform.position.z <= DeletePosZ)
        {
            PosZdiff = this.transform.position.z - DeletePosZ;
            bufPos = new Vector3(this.transform.position.x, this.transform.position.y, ReStartPosZ + PosZdiff);
            this.transform.position = bufPos;
        }

    }
}
