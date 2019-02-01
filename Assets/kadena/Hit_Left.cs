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
    [SerializeField] private float impulse_Power = 50f;
    private AudioSource hit_SE;

    [SerializeField] AudioClip SE_hit;
    void Start()
    {
        parent = transform.parent.gameObject;
        left_enemy = false;
        player_check = player.GetComponent<PlayerController>();
        hit_SE = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        Left_col = true;
        if (other.gameObject.tag == "NormalEnemy")//一般車と衝突
        {
            hit_SE.PlayOneShot(SE_hit);
            GameStateStash.GameOver();
            Destroy(parent.gameObject);
        }
        else if (other.gameObject.tag == "Wall")//壁と衝突
        {
            hit_SE.PlayOneShot(SE_hit);
            GameStateStash.GameOver();
            Destroy(parent.gameObject);
        }
        else if (other.gameObject.tag == "Enemy")//特殊敵と衝突
        {
            hit_SE.PlayOneShot(SE_hit);
            GameStateStash.BreakCarCountUp();
            GameStateStash.AddScore(10);
            if (player_check.player_move == false)
            {
                left_enemy = true;

            }
            else
            {
                var rigid = other.gameObject.GetComponent<Rigidbody>();
                var impulse = (rigid.position - transform.parent.position).normalized * impulse_Power;
                rigid.AddForce(impulse, ForceMode.Impulse);
                Debug.Log("Blast!!");
                
                
            }
        }
    }
}
