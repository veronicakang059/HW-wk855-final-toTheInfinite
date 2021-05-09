using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float interval = 1f;
    void Start()
    {
        InvokeRepeating("spawnEnemy",interval,interval);
    }

    // Update is called once per frame
    void spawnEnemy()
    {
        GameObject enemy = EnemyPool.instance.GetEnemy();
    }
    void Update()
    {
        
    }
}
