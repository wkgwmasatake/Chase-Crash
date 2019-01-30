using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Back : MonoBehaviour {

    public bool Back_col = false;

    void OnTriggerEnter(Collider other)
    {
        Back_col = true;
    }
}
