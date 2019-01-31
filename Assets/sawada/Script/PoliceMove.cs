using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMove : MonoBehaviour {

    [SerializeField] private float SpeedZ;      //速さ
    [SerializeField] private float SpeedX;
    [SerializeField] private int chengeSpeed;  //可変速度

    [SerializeField] private PlayerController player;

    private Vector3 Move_X = new Vector3(4.0f, 0.0f, 0.0f);
    private Vector3 targetPos = Vector3.zero;

    private float MoveTime = 0.0f;
    private float MoveSpan = 3.0f;       //３秒間隔で移動
    private float MoveFlg = 0;

	// Use this for initialization
	void Start ()
    {

        chengeSpeed = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveTime += Time.deltaTime;

        //Z座標に動く
        if (chengeSpeed == 1)
        {
            transform.Translate(0, 0, SpeedZ * chengeSpeed * Time.deltaTime);
        }

        if (transform.position.z >= player.GetComponent<PlayerController>().transform.position.z)
        {
            chengeSpeed = 0;
        }

        if (player.GetComponent<PlayerController>().transform.position.x >= this.transform.position.x)
        {
            //右に動かす
            Debug.Log("みぎ");
            if (MoveTime >= MoveSpan)
            {
                MoveFlg = 1;
                Move();
                targetPos = transform.position + Move_X;
            }

            if (MoveTime >= 3.5f)
            {
                Debug.Log("aaaaaaaaaaaaaa");
                MoveTime = 0;
            }
        }
        else if (player.GetComponent<PlayerController>().transform.position.x <= this.transform.position.x)
        {
            //左に動かす
            Debug.Log("ひだり");
            if (MoveTime >= MoveSpan)
            {
                MoveFlg = -1;
                Move();
                targetPos = transform.position - Move_X;
            }

            if (MoveTime >= 3.5f)
            {
                Debug.Log("aaaaaaaaaaaaaa");

                MoveTime = 0;
            }
        }
    }

    void Move()
    {
        Debug.Log("うごくみたい");
        transform.position = Vector3.MoveTowards(transform.position, targetPos, SpeedX * Time.deltaTime);
    }
}
