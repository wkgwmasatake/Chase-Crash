using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Rayの色
///     赤：縦 V
///     青：横 H
///     
///changeSpeed
///     プレイヤーを追跡中は　　　　　　   3
///     プレイヤーの隣についたら　　　　   1
///     プレイヤーのフロントに当たると　　-1
/// </summary>

public class PoliceAI : MonoBehaviour {

    [SerializeField] private float distanceV;  //Rayを表示するRayの長さ
    [SerializeField] private float distanceH;  //Rayを表示するRayの長さ

    [SerializeField] private float SpeedH;      //PoliceAIの速度
    [SerializeField] private float SpeedV;

    private Vector3 Move_X = new Vector3(4.0f, 0.0f, 0.0f);
    private bool MoveFlg = true;               //自機が動いているか判定
    private bool RayFlg = true;                //Rayを出すか判定

    private int FrontFlg = 0;             //自機がフロントの前まで来たか

    private Vector3 vDirection;                //方向(Vector型)
    private int direction;                     //方向(int型)

    private int randomDirection;               //移動する方向をランダムで決める

    private bool directionFlgR = false;
    private bool directionFlgL = false;

    private int randomMove = 0;                 //これからする行動をランダムで決める

    private int changeSpeed;　　　　　　　      //初期速度（倍率）

    private string Name;

    private Vector3 targetPos;

    //移動可能か調べる
    private int MoveCheckH;             //横の移動判定
    private bool MoveCheckV = false;             //縦の移動判定

    // Use this for initialization
    void Start ()
    {
        targetPos = transform.position;
        changeSpeed = 3;

        randomMove = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update ()
    {
        Debug.Log("方向：" + direction);
        if (transform.position.x == targetPos.x)
        {
            //自機は動いていない
            MoveFlg = false;

            directionFlgL = false;
            directionFlgR = false;

            if (RayFlg)
            {
                //Rayの作成（四方）
                FrontRay();
                BackRay();
                RightRay();
                LeftRay();
            }
            else
            {
                changeSpeed = -2;
            }

            SetTargetPosition();
            transform.Translate(0, 0, SpeedV * changeSpeed * Time.deltaTime);
        }
        else
        {
            //自機は動いている
            MoveFlg = true;
        }
        Move();

    }

    //次の目的地を設定する
    void SetTargetPosition()
    {
        if(direction == 1 && MoveCheckV && transform.position.x < 8)
        {
            targetPos = transform.position + Move_X;
            return;
        }

        if(direction == -1 && MoveCheckV && transform.position.x > -8)
        {
            targetPos = transform.position - Move_X;
            return;
        }

        if (FrontFlg == 1)
        {
            if (vDirection.normalized.x == 1)
            {
                targetPos = new Vector3(transform.position.x + Move_X.x, 0, vDirection.z + 5);
            }
            if (vDirection.normalized.x == -1)
            {
                targetPos = new Vector3(transform.position.x - Move_X.x, 0, vDirection.z + 5);
            }
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, SpeedH * Time.deltaTime);
    }

    //前方のRay
    void FrontRay()
    {
        RaycastHit FwdHit;
        Ray FwdRay = new Ray(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.forward);
        Debug.DrawRay(FwdRay.origin, FwdRay.direction * distanceV, Color.red, 5, false);

        if(Physics.Raycast(FwdRay, out FwdHit, distanceV))
        {
            Name = FwdHit.collider.gameObject.name;
            MoveCheckV = true;

            //方向をランダムで決める
            randomDirection = Random.Range(0, 2);
            switch(randomDirection)
            {
                case 0:
                    direction = 1;
                    break;
                case 1:
                    direction = -1;
                    break;
            }

            if(directionFlgR && directionFlgL)
            {
                direction = 0;
            }
        }
        else
        {
            MoveCheckV = false;
        }
    }

    //後方のRay
    void BackRay()
    {
        RaycastHit BckHit;
        Ray BckRay = new Ray(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), -transform.forward);
        Debug.DrawRay(BckRay.origin, BckRay.direction * distanceV * 10, Color.red, 5, false);

        if (Physics.Raycast(BckRay, out BckHit, distanceV * 10))
        {
            Name = BckHit.collider.gameObject.name;
            if(BckHit.collider.gameObject.tag == "Front")
            {
                RayFlg = false;
                FrontFlg = 0;
            }
        }
    }

    //右のRay
    void RightRay()
    {

        RaycastHit RightHit;
        Ray RightRay = new Ray(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.right);
        Debug.DrawRay(RightRay.origin, RightRay.direction * distanceH, Color.red, 5, false);

        if (Physics.Raycast(RightRay, out RightHit, distanceH))
        {
            Name = RightHit.collider.gameObject.name;

            MoveCheckH = CheckH(RightHit.collider.gameObject.tag);

            switch (MoveCheckH)
            {
                case 0:
                case 1:
                    break;
                case 2:
                    if(randomMove == 1)
                        changeSpeed = 2;
                    break;
                case 3:
                    vDirection = RightRay.direction;
                    break;
            }

            if(direction == 1)
            {
                directionFlgR = true;
                direction = -1;
            }
        }
    }

    //左のRay
    void LeftRay()
    {
        RaycastHit LeftHit;
        Ray LeftRay = new Ray(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), -transform.right);
        Debug.DrawRay(LeftRay.origin, LeftRay.direction * distanceH, Color.red, 5, false);

        if (Physics.Raycast(LeftRay, out LeftHit, distanceH))
        {
            Name = LeftHit.collider.gameObject.name;

            MoveCheckH = CheckH(LeftHit.collider.gameObject.tag);

            switch(MoveCheckH)
            {
                case 0:
                case 1:
                    break;
                case 2:
                    if (randomMove == 2)
                        changeSpeed = 2;
                    break;
                case 3:
                    vDirection = LeftRay.direction;
                    break;
            }

            if(direction == -1)
            {
                directionFlgL = true;
                direction = 1;
            }
        }
    }

    int CheckH(string tag)
    {
        if(tag == "Wall")
        {
            return 1;
        }

        if(tag == "Player")
        {
            return 2;
        }

        if(tag == "Front")
        {
            FrontFlg = 1;
            return 3;
        }

        return 0;
    }

    //衝突判定
    private void OnTriggerEnter(Collider other)
    {
        //自分自身をデストロイ
        Destroy(this.gameObject);
    }
}
