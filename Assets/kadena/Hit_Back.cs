using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Back : MonoBehaviour {

    public bool Back_col = false;
    public GameObject parent;

    void Start()
    {
        parent = transform.parent.gameObject;
    }
    void OnTriggerEnter(Collider other)
    {
        Back_col = true;
        if (other.gameObject.tag == "NormalEnemy")
        {
            Destroy(parent.gameObject);
            GameStateStash.GameOver();
        }
    }
}
