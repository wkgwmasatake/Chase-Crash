using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMove : MonoBehaviour {

    [SerializeField] private float Speed;      //速さ
    [SerializeField] private int chengeSpeed;  //可変速度

    public PlayerController player;

	// Use this for initialization
	void Start ()
    {
        chengeSpeed = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(0, 0, Speed * chengeSpeed * Time.deltaTime);

        if(transform.position.z >= player.GetComponent<PlayerController>().transform.position.z)
        {
            chengeSpeed = 0;
        }
	}
}
