// このスクリプトはSourcetreeで取得後、削除しても構いません

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// テストのためのスクリプト
/// </summary>
public class test5 : MonoBehaviour {

    [SerializeField] private bool MoveFlg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool _MoveFlg
    {
        get { return MoveFlg; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ENEMY")
        {
            this.GetComponent<Rigidbody>().AddForce(-100, 0, 0, ForceMode.Impulse);
        }
    }
}
