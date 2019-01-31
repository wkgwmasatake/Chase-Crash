using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePressTextController : MonoBehaviour
{
    private float multipliedAlpha = 1;
    private Text myText;
    private Color nowColor;
    private bool Startflg = false;
    private int Waitflame;

	// Use this for initialization
	void Start ()
    {
        myText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetButton("Horizontal"))
        {
            Startflg = true;
        }

        if (!Startflg)
        {
            nowColor = myText.color;
            myText.color = new Color(nowColor.r, nowColor.g, nowColor.b,
                                        nowColor.a - (1.0f * Time.deltaTime * multipliedAlpha));
            if (myText.color.a < 0 || myText.color.a > 1)
            {
                multipliedAlpha *= -1;
            }
        }
        else
        {
            if(++Waitflame > 2)
            {
                myText.color = new Color(nowColor.r, nowColor.g, nowColor.b,
                                        nowColor.a * multipliedAlpha);
                multipliedAlpha *= -1;
                Waitflame = 0;
            }
        }
    }
}
