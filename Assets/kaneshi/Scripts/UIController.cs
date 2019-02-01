using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text Score;
    public Text Score_Shadow;
    public Text Crush;
    public Text Crush_Shadow;
    public Text MaxCrush;
    public Text MaxCrush_Shadow;

    // Use this for initialization
    void Start ()
    {
        Score.text = GameStateStash._score.ToString("D8");
        Score_Shadow.text = GameStateStash._score.ToString("D8");
        Crush.text = GameStateStash._breakCarCount.ToString("D3");
        Crush_Shadow.text = GameStateStash._breakCarCount.ToString("D3");
        MaxCrush.text = GameStateStash._breakCarMaxCount.ToString("D3");
        MaxCrush_Shadow.text = GameStateStash._breakCarMaxCount.ToString("D3");
    }
}
