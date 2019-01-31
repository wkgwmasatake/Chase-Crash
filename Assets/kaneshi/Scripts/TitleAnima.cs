using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnima : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetButton("Horizontal"))
        {
            GetComponent<Animator>().SetTrigger("StartTrigger");
        }
    }
}
