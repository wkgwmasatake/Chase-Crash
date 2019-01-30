using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Rayの色
///     赤：縦 V
///     青：横 H
/// </summary>

public class PoliceAI : MonoBehaviour {

    [SerializeField] private float distanceV;  //Rayを表示するRayの長さ
    [SerializeField] private float distanceH;  //Rayを表示するRayの長さ

    [SerializeField] private float SpeedH;      //PoliceAIの速度

    private float direction;                   //方向

    private string Name;

    //移動可能か調べる
    private bool MoveChack;


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        //Rayの作成
        for(int i = 1; i > -2; i -= 2)
        {
            Ray(i, true);
            Ray(i, false);
        }

        if(MoveChack)
        {

        }
    }

    //四方のRay作成
    void Ray(int x, bool direction)
    {
        //Rayが衝突したコライダーの情報を格納
        RaycastHit hit;


        if (direction)
        {
            //上下のRay
            Ray ray = new Ray(transform.position, x * transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * distanceV, Color.red, 5, true);

            //Rayが衝突したかどうか
            if(Physics.Raycast(ray, out hit, distanceV))
            {
                //テストプレイとして衝突したオブジェクトの名前を取得
                Name = hit.collider.name;
            }

            Debug.Log("当たったオブジェクトの名前は : " + Name);

        }
        else
        {
            //左右のRay
            Ray ray = new Ray(transform.position, x * transform.right);
            Debug.DrawRay(ray.origin, ray.direction * distanceH, Color.blue, 5, true);

            //Rayが衝突したかどうか
            if (Physics.Raycast(ray, out hit, distanceH))
            {
                //テストプレイとして衝突したオブジェクトの名前を取得
                Name = hit.collider.name;

                if( x == 1 )
                {
                    MoveChack = Chack(hit);
                }
                else if( x == -1 )
                {
                    MoveChack = Chack(hit);
                }
            }

            Debug.Log("当たったオブジェクトの名前は : " + Name);

        }

    }

    //移動可能か調べる
    bool Chack(RaycastHit hit)
    {
        //当たったのが壁なら
        if(hit.collider.tag == "Wall")
        {
            //移動できない
            return false;
        }

        //何もなければ移動可能
        return true;
    }
}
