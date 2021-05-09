using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBuff : MonoBehaviour
{
    // Start is called before the first frame update
    public float intervalMin = 2f;
    public float intervalMax = 10f;
    public float numStars = 2;
    void Start()
    {
        Invoke("spawnStar",intervalMin);
        
    }

    // Update is called once per frame
    void spawnStar()
    {
        for (int i = 0; i < numStars; i++)
        {
            GameObject starBuff = StarPool.instance.GetStar();
        }
        Invoke("spawnStar",Random.Range(intervalMin,intervalMax));
    }
}
