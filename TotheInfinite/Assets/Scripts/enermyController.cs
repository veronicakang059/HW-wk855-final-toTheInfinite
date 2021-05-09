using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class enermyController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    public float xRange = 8;
    public float speedAMT = 5;
    public GameObject enermyPrefab;
    public float yRange= -6f;
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    public void SpawnEnemy()
    {
        if (rb2d == null)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        transform.position = new Vector2(Random.Range(-xRange, xRange), 10f);
        rb2d.velocity = Vector2.down * speedAMT;
    }


    void Update()
    {
        if (transform.position.y < yRange)
        {
            EnemyPool.instance.Push(gameObject);
        }
    }
}
