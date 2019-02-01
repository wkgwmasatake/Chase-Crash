using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateStash : MonoBehaviour {

    private InitGameAllState IGAS;      //初期化用Asset

    //スコア
    public static uint _score { get; private set; }

    //スピード
    public static float _speed { get; private set; }

    //最大スピード
    public static float _maxSpeed { get; private set; }

    //現在の破壊数
    public static int _breakCarCount { get; private set; }

    //破壊数ノルマ
    public static int _breakCarMaxCount { get; private set; }

    //ゲームオーバーフラグ
    public static bool _gameOverFlg { get; private set; }

    // Use this for initialization
    void Awake()
    {
        IGAS = Resources.Load<InitGameAllState>("InitGameAllState");
        Init();
    }

    /// <summary>
    /// 各種ステータスの初期化
    /// </summary>
    private void Init()
    {
        _score = IGAS.score;
        _speed = IGAS.speed;
        _maxSpeed = IGAS.maxSpeed;
        _breakCarCount = IGAS.breakCarCount;
        _breakCarMaxCount = IGAS.breakCarMaxCount;
        _gameOverFlg = IGAS.gameOverFlg;
    }

    /// <summary>
    /// スコア加算関数(壁の固定スコアを要求)
    /// </summary>
    /// <param name="addScore"></param>
    public static void AddScore(uint addScore)
    {
        addScore = (uint)((float)addScore);
        _score += addScore;
    }

    /// <summary>
    /// スピード上昇関数(1つのスクリプトのみ呼ぶ)
    /// </summary>
    public static void SpeedUp(float magnification)
    {
        _speed += Time.deltaTime * magnification;
        _speed = Mathf.Min(_speed, _maxSpeed);
    }

    /// <summary>
    /// 車カウントアップ関数   
    /// /// </summary>
    public static void BreakCarCountUp()
    {
        if (++_breakCarCount > _breakCarMaxCount)
        {
            _breakCarCount = _breakCarMaxCount;
        }
    }

    public static void GameOver()
    {
        _gameOverFlg = true;
    }

    public static void reStart()
    {
        _gameOverFlg = false;
    }
}
