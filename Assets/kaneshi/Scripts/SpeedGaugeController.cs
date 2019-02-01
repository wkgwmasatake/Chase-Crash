using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedGaugeController : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Image>().fillAmount = GameStateStash._speed / GameStateStash._maxSpeed;
	}
}
