using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool:ObjectPool
{
    public GameObject enemy;
    public static EnemyPool instance;
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override GameObject GetNewObject()
    {
        return Instantiate<GameObject>(enemy);
    }

    public GameObject GetEnemy()
    {
        GameObject recycledEnemy = Get();
        recycledEnemy.GetComponent<enermyController>().SpawnEnemy();
        return recycledEnemy;
    }
}
