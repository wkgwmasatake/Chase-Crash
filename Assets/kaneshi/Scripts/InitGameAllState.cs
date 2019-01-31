using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/InitGameAllState")]
[System.Serializable]
public class InitGameAllState : ScriptableObject
{
    /// <summary>
    /// スコア初期値
    /// </summary>
    [SerializeField]
    private uint _score = 0;
    public uint score
    {
        get { return _score; }
    }

    /// <summary>
    /// スピード初期値
    /// </summary>
    [SerializeField]
    private float _speed = 1.0f;
    public float speed
    {
        get { return _speed; }
    }

    [SerializeField]
    private float _maxSpeed = 3.0f;
    public float maxSpeed
    {
        get { return _maxSpeed; }
    }

    /// <summary>
    /// 壁破壊数初期値
    /// </summary>
    [SerializeField]
    private int _breakCarCount = 0;
    public int breakCarCount
    {
        get { return _breakCarCount; }
    }


    /// <summary>
    /// 壁破壊ノルマ初期値
    /// </summary>
    [SerializeField]
    private int _breakCarMaxCount = 100;
    public int breakCarMaxCount
    {
        get { return _breakCarMaxCount; }
    }

    /// <summary>
    /// ゲームオーバーフラグ
    /// </summary>
    [SerializeField]
    private bool _gameOverFlg = false;
    public bool gameOverFlg
    {
        get { return _gameOverFlg; }
    }

}