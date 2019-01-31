using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Right : MonoBehaviour {

    public bool Right_col = false;
    
    public GameObject parent;

    void Start()
    {
        parent = transform.parent.gameObject;
    }
    void OnTriggerEnter(Collider other)
    {
        Right_col = true;
        if (other.gameObject.tag == "NormalEnemy" )//
        {
            Debug.Log("NormalEnemy");
            Destroy(parent.gameObject);
        }
        else if (other.gameObject.tag == "Wall")//
        {
            //other.transform.position = Vector3.MoveTowards(other.transform.position, new Vector3(4, 0, 0), 200 * Time.deltaTime);
            Debug.Log("Wall");
            Destroy(parent.gameObject);
        }
    }
}
