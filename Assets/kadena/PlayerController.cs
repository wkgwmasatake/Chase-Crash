using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    int CrashCount;

    public float player_speed = 10f;
    public float step_speed = 10f;

    public bool player_move;//プレイヤーが動いているかどうか  true:移動中 false:待機中
    public int player_lane;//プレイヤーの現在レーン地点の取得 -7.98:左端  7.98:右端 
    int max_lane = 7;
    int min_lane = 0;
    //float moveX = 0f;

    float max_moveX = 7f;
    Vector3 Move_X = new Vector3(2.66f, 0, 0);
    Vector3 target;//移動場所
    Vector3 prevPos;//移動前の位置の保存
    Rigidbody rb;

    //当たり判定用オブジェクト
    [SerializeField] GameObject Front;
    [SerializeField] GameObject Back;
    [SerializeField] GameObject Left;
    [SerializeField] GameObject Right;

    //子オブジェクト
    private Hit_Front player_front;
    private Hit_Back player_back;
    private Hit_Left player_left;
    private Hit_Right player_right;

    void Start()
    {
        player_front = Front.GetComponent<Hit_Front>();
        player_back = Back.GetComponent<Hit_Back>();
        player_left = Left.GetComponent<Hit_Left>();
        player_right = Right.GetComponent<Hit_Right>();
        rb = GetComponent<Rigidbody>();

        target = transform.position;
        player_lane = 4;
    }

    void Update()
    {
        //moveX = Input.GetAxis("Horizontal") * player_speed;
      
        //Vector3 direction = new Vector3(moveX, 0, 0);

        if (player_front.Front_col == true)
        {
            Debug.Log("Front_Hit!!  GameOver!!");
            //SceneManager.LoadScene("GameOver");//ゲームオーバー処理に移行する処理
            player_front.Front_col = false;
        }
        else if (player_back.Back_col == true)
        {
            Debug.Log("Back_Hit!!後ろから！");
            player_back.Back_col = false;
        }
        else if (player_left.Left_col == true)
        {
            Debug.Log("Left_hit!左から！");
            player_left.Left_col = false;
        }
        else if (player_right.Right_col == true)
        {
            Debug.Log("Right_Hit!!右から！");

            player_right.Right_col = false;
        }
        if (transform.position == target)
        {
            SetTargetposition();
            player_move = false;
        }
        else
        {
            player_move = true;
        }
        
        Move();
        Debug.Log(player_move);
    }

    //void FixedUpdate()
    //{
    //    rb.velocity = new Vector3(moveX, 0, 0);
    //}

    public bool _player_move
    {
        get { return player_move; }
    }

    void SetTargetposition()
    {
        prevPos = target;

        if (Input.GetKey(KeyCode.D) && transform.position.x < max_moveX)
        {
            target = transform.position + Move_X;
            player_lane++;
            return;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -max_moveX)
        {
            target = transform.position - Move_X;
            player_lane--;
            return;
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step_speed * Time.deltaTime);
    }
    //撃破した敵の点数をint型の返り値で示す処理
    public int ReturnCrashCount()
    {
        return CrashCount;
    }

    public Transform ReturnPlayerTransform()
    {
        return this.transform;
    }
}
