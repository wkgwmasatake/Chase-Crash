using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Front : MonoBehaviour {

	public bool Front_col = false;
    public GameObject parent;

    void Start()
    {
        parent = transform.parent.gameObject;
    }
    void OnTriggerEnter(Collider other)
    {
        Front_col = true;
        if (other.gameObject.tag == "NormalEnemy")
        {
            Debug.Log("NormalEnemy");
            Destroy(parent.gameObject);
        }
    }
}
