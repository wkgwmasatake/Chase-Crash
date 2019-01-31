using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Left : MonoBehaviour {

    public bool Left_col = false;
    public bool left_enemy;
    public GameObject parent;

    void Start()
    {
        parent = transform.parent.gameObject;
        left_enemy = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NormalEnemy")//一般車と衝突
        {
            Debug.Log("NormalEnemy");
            Destroy(parent.gameObject);
        }
        else if (other.gameObject.tag == "Wall")//壁と衝突
        {
            //other.transform.position = Vector3.MoveTowards(other.transform.position, new Vector3(4, 0, 0), 200 * Time.deltaTime);
            Debug.Log("Wall");
            Destroy(parent.gameObject);
        }
        else if (other.gameObject.tag == "Enemy")//特殊敵と衝突
        {
            Debug.Log("NormalEnemy");
            left_enemy = true;
        }
        Left_col = true;
    }
}
