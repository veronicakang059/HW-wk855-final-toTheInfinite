using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPool : ObjectPool
{
    // Start is called before the first frame update
    public GameObject starBuff;
    public static StarPool instance;
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

    protected override GameObject GetNewObject()
    {
        return Instantiate<GameObject>(starBuff);
    }

    public GameObject GetStar()
    {
        GameObject recycledStar = Get();
        recycledStar.GetComponent<StarScript>().Reset();
        return recycledStar;
    }
    
}
