using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Right : MonoBehaviour {

    public bool Right_col = false;
    public bool right_enemy;
    public GameObject parent;

    void Start()
    {
        parent = transform.parent.gameObject;
        right_enemy = false;
    }
    void OnTriggerEnter(Collider other)
    {
        Right_col = true;
        if (other.gameObject.tag == "NormalEnemy" )//一般車と衝突
        {
            Debug.Log("NormalEnemy");
            Destroy(parent.gameObject);
        }
        else if (other.gameObject.tag == "Wall")//壁と衝突
        {
            
            Debug.Log("Wall");
            Destroy(parent.gameObject);
        }
        else if(other.gameObject.tag == "Enemy")//特殊敵と衝突
        {
            Debug.Log("NormalEnemy");
            right_enemy = true;
        }
    }
}
