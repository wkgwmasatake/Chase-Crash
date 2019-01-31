using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Left : MonoBehaviour
{
    public bool Left_col = false;
    public bool left_enemy;
    public GameObject parent;
    public GameObject player;
    PlayerController player_check;

    void Start()
    {
        parent = transform.parent.gameObject;
        left_enemy = false;
        player_check = player.GetComponent<PlayerController>();
    }
    void OnTriggerEnter(Collider other)
    {
        Left_col = true;
        if (other.gameObject.tag == "NormalEnemy")//一般車と衝突
        {
            Debug.Log("NormalEnemy");
            Destroy(parent.gameObject);
            GameStateStash.GameOver();
        }
        else if (other.gameObject.tag == "Wall")//壁と衝突
        {
            Debug.Log("Wall");
            Destroy(parent.gameObject);
            GameStateStash.GameOver();
        }
        else if (other.gameObject.tag == "Enemy")//特殊敵と衝突
        {
            if (player_check.player_move == false)
            {
                left_enemy = true;

            }
            else
            {
                Debug.Log("Blast!!");
                other.transform.position = Vector3.MoveTowards(other.transform.position,
                    new Vector3(other.transform.position.x - 4, 0.5f, 0), 200 * Time.deltaTime);
            }
        }
    }
}
