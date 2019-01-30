using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Left : MonoBehaviour {

    public bool Left_col = false;
    Rigidbody rb;
    void OnTriggerEnter(Collider other)
    {
        
        Left_col = true;
    }
}
