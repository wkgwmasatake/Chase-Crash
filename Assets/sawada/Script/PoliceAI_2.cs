using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceAI_2 : MonoBehaviour {

    [SerializeField] private float distanceV;  //Rayを表示するRayの長さ
    [SerializeField] private float distanceH;  //Rayを表示するRayの長さ

    private string Name;                       //当たったオブジェクトの名前

    // Use this for initialization
    void Start ()
    {
	}

    // Update is called once per frame
    void Update()
    {

    }

    //右のRay
    public bool RightRay
    {
        get
        {
            RaycastHit RightHit;
            Ray RightRay = new Ray(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.right);
            Debug.DrawRay(RightRay.origin, RightRay.direction * distanceH, Color.red, 1, false);

            if (Physics.Raycast(RightRay, out RightHit, distanceH))
            {
                Name = RightHit.collider.gameObject.name;

                return Check(RightHit.collider.gameObject.tag);
            }

            //何も当たらなかった
            return false;
        }
    }

    //左のRay
    public bool LeftRay
    {
        get
        {
            RaycastHit LeftHit;
            Ray LeftRay = new Ray(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), -transform.right);
            Debug.DrawRay(LeftRay.origin, LeftRay.direction * distanceH, Color.red, 1, false);

            if (Physics.Raycast(LeftRay, out LeftHit, distanceH))
            {
                Name = LeftHit.collider.gameObject.name;

                return Check(LeftHit.collider.gameObject.tag);

            }

            //何もなかった
            return false;
        }
    }

    bool Check(string tag)
    {
        if (tag == "Wall")
        {
            return true;
        }

        if (tag == "Player")
        {
            return true;
        }

        return false;
    }
}
