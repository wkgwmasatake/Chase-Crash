using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMoveTo : MonoBehaviour {

    private float DefPosZ = 170.0f;

    private float PosZ;
    private Vector3 vDefPos;

	// Use this for initialization
	void Start () {

        vDefPos = new Vector3(0, 0, DefPosZ);
        PosZ = DefPosZ;
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position -= new Vector3(0, 0, GameStateStash._speed * 1.0f);

        if(this.transform.position.z <= -70.0f)
        {
            //PosZ = PosZ - (this.transform.position.z + 70.0f);
            //vDefPos = new Vector3(0, 0, PosZ);
            this.transform.position = vDefPos;

            //PosZ = DefPosZ;
        }
    }
}
