using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Front : MonoBehaviour {

	public bool Front_col = false;

    void OnTriggerEnter(Collider other)
    {
        Front_col = true;
        if (other.gameObject.tag == "Enemy_1")//
        {
            Debug.Log("Unttaged");

        }
        
    }
}
