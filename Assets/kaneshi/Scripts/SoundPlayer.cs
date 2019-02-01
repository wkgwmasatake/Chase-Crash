using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public float[] WaitTime;
    public GameObject[] PlaySE;
    public bool[] isPlay = { false };
    public float[] nowTime = {0};
    private bool Startflg = false;

	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Horizontal"))
        {
            Startflg = true;
        }
        if (!Startflg) { return; }

        for(int i = 0; i < nowTime.Length; i++)
        {
            if (isPlay[i]) { continue; }
            nowTime[i] += Time.deltaTime;
            if(nowTime[i] >= WaitTime[i])
            {
                Instantiate(PlaySE[i]);
                isPlay[i] = true;
            }
        }
	}
}
