using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCarSponer : MonoBehaviour
{

    public GameObject[] EnemyCar;
    public GameObject PoliceCar;

    public GameObject[] SpawnPoint;

    float SpawnTime;

    // Use this for initialization
    void Start()
    {
        SpawnTime = Random.Range(0.2f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {

        SpawnTime -= Time.deltaTime;

        if (SpawnTime < 0)
        {
            Instantiate(EnemyCar[Random.Range(0, EnemyCar.Length - 1)], SpawnPoint[Random.Range(0, SpawnPoint.Length - 1)].transform);
            SpawnTime = Random.Range(0.2f, 0.8f);
        }
    }
}
