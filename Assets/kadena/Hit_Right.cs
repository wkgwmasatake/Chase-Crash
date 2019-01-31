using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Right : MonoBehaviour {

    public bool Right_col = false;
    public GameObject player_controller;
    void OnTriggerEnter(Collider other)
    {
        Right_col = true;
        other.transform.position = Vector3.MoveTowards(other.transform.position, new Vector3(4, 0, 0), 200 * Time.deltaTime);
        
    }
}
