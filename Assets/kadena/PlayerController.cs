using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int CrashCount;

    [SerializeField] float player_speed = 3f;

    float moveX = 0f;
   
    Rigidbody rb;

    //当たり判定用オブジェクト
    [SerializeField] GameObject Front;
    [SerializeField] GameObject Back;
    [SerializeField] GameObject Left;
    [SerializeField] GameObject Right;

    //子オブジェクト
    private PlayerCollider player_front;
    private PlayerCollider player_back;
    private PlayerCollider player_left;
    private PlayerCollider player_right;

    void Start()
    {
        player_front = Front.GetComponent<PlayerCollider>();
        player_back = Back.GetComponent<PlayerCollider>();
        player_left = Left.GetComponent<PlayerCollider>();
        player_right = Right.GetComponent<PlayerCollider>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * player_speed;
      
        Vector3 direction = new Vector3(moveX, 0, 0);

        if (player_front.Player_col == true)
        {
            Debug.Log("Front");
            player_front.Player_col = false;
        }
        else if (player_back.Player_col == true)
        {
            Debug.Log("Back");
            player_back.Player_col = false;
        }
        else if (player_left.Player_col == true)
        {
            Debug.Log("Left");
            player_left.Player_col = false;
        }
        else if (player_right.Player_col == true)
        {
            Debug.Log("Right");

            player_right.Player_col = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveX, 0, 0);
    }




    //撃破した敵の点数をint型の返り値で示す処理
    public int ReturnCrashCount()
    {
        return CrashCount;
    }
}
