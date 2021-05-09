using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StarScript : MonoBehaviour
{
    // Start is called before the first frame update
    const float min_speed = 0.01f;
    const float max_speed = 0.05f;
    public float xRange;
    const float max_y = 10;
    const float min_y = -10;
    float speed;
    
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    public void Reset()
    {
        speed = -Random.Range(min_speed, max_speed);
        transform.position = new Vector2(Random.Range(-xRange, xRange), max_y);
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y);
        if (transform.position.y < min_y)
        {
            StarPool.instance.Push(gameObject);
        }

    }
}
