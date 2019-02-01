using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(PoliceMove.DestroyFlg)
        {
            audio.PlayOneShot(audio.clip);
            PoliceMove.DestroyFlg = false;
        }
	}


}