using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Right : MonoBehaviour {

    public bool Right_col = false;

    void OnTriggerEnter(Collider other)
    {
        Right_col = true;
    }
}
