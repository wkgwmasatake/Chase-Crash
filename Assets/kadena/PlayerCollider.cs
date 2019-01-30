using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    public bool Player_col = false;

    void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.tag == "Enemy_1")
        {
            Debug.Log("Enemy_1");
        }

        if (other.gameObject.tag == "Enemy_2")
        {
            Debug.Log("Enemy_2");
        }
        Player_col = true;
    }
    
}
