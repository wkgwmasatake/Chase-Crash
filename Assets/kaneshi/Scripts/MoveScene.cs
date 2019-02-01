using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public float WaitTime = 7.0f;
    public string SceneName = "";
    private float nowTime;
    public bool Startflg = false;
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButtonDown("Horizontal"))
        {
            Startflg = true;
        }
        if (!Startflg) { return; }

        nowTime += Time.deltaTime;

        if(nowTime >= WaitTime)
        {
            SceneManager.LoadScene(SceneName);
        }
	}
}
