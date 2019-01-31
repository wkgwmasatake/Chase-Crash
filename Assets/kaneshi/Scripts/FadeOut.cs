using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float WaitFadeTime = 3.0f;
    public float FadeTime = 3.0f;
    private bool Startflg = false;
    private Image panel;
    private float alpha;
    private float nowTime;

	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Horizontal"))
        {
            Startflg = true;
            panel = GetComponent<Image>();            
        }

        if (!Startflg) { return; }
        nowTime += Time.deltaTime;
        if (WaitFadeTime <= nowTime)
        {
            panel.color = new Color(0, 0, 0, alpha);
            alpha += Time.deltaTime / FadeTime;
        }
    }
}
