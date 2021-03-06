﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCarSponer : MonoBehaviour
{

    public GameObject[] EnemyCar;
    public GameObject[] SpawnPoint;

    float SpawnTime;
    int OldSpawnPoint;      // 前回の生成場所を保存する変数

    // Use this for initialization
    void Start()
    {
        OldSpawnPoint = 99;
        SpawnTime = Random.Range(0.2f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        int NowSpawnPoint;  // 現在の生成場所を保存する変数

        SpawnTime -= Time.deltaTime;

        if (SpawnTime < 0)
        {
            NowSpawnPoint = Random.Range(0, SpawnPoint.Length);

            while (NowSpawnPoint == OldSpawnPoint)
            {
                NowSpawnPoint = Random.Range(0, SpawnPoint.Length);
            }

            OldSpawnPoint = NowSpawnPoint;
            Instantiate(EnemyCar[Random.Range(0, EnemyCar.Length - 1)], SpawnPoint[NowSpawnPoint].transform);

            float PlayerSpeed = Mathf.Round(GameStateStash._speed * 10) / 10;       // 小数第二位以下を偶数丸め
            SpawnTime = Random.Range(0.6f / (PlayerSpeed - 0.5f), 1.2f / (PlayerSpeed - 0.5f));       // プレイヤーのスピードに応じて生成間隔を変化
        }
    }
}
