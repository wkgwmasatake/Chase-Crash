using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    int CrashCount;

    public float player_speed = 10f;
    public float step_speed = 10f;

    public bool player_move;//プレイヤーが動いているかどうか  true:移動中 false:待機中
    public int player_lane;//プレイヤーの現在レーン地点の取得 1:左端  7:右端 

    float max_moveX = 10f;
    Vector3 Move_X = new Vector3(4f, 0, 0);
    Vector3 target;//入力受付時、移動後の位置を算出して保存 

    Vector3 prevPos;//// 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存

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
        if (transform.position == target)
        {
            SetTargetposition();
            player_move = false;
            if(player_right.right_enemy == true)
            {
                player_right.right_enemy =false;
            }
            else if (player_left.left_enemy == true)
            {
                player_left.left_enemy = false;
            }
        }
        else
        {
            player_move = true;
        }
        
        Move();
        Debug.Log(player_move);
    }

    public bool _player_move//プレイヤーが移動中か否かをget出力
    {
        get { return player_move; }
    }

    public int _player_lane//プレイヤーがどのレーンかをget出力
    {
        get { return _player_lane; }
    }

    void SetTargetposition()
    {
        prevPos = target;//移動前の位置を保存

        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < max_moveX || player_left.left_enemy == true && player_move == false)
        {
            target = transform.position + Move_X;
            player_lane++;
            return;
        }
        
        else if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -max_moveX || player_right.right_enemy == true && player_move == false)
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

    public Transform ReturnPlayerTransform()
    {
        return this.transform;
    }
}