using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Front : MonoBehaviour {

	public bool Front_col = false;
    public GameObject parent;

    private AudioSource hit_SE;

    [SerializeField] AudioClip SE_hit;
    void Start()
    {
        parent = transform.parent.gameObject;
        hit_SE = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        Front_col = true;
        if (other.gameObject.tag == "NormalEnemy")
        {
            hit_SE.PlayOneShot(SE_hit);
            GameStateStash.GameOver();
            Destroy(parent.gameObject);
        }
    }
}
