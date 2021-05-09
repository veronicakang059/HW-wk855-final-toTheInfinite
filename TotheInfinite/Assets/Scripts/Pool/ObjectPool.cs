using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    // Start is called before the first frame update
    protected Stack<GameObject> pool = new Stack<GameObject>();

    public GameObject Get()
    {
        GameObject result;
        if (pool.Count == 0)
        {
            result = GetNewObject();
        }
        else
        {
            result = pool.Pop();
        }

        result.transform.parent = this.transform;
        result.SetActive(true);
        return result;
    }

    protected abstract GameObject GetNewObject();

    public void Push(GameObject used)
    {
        used.SetActive(false);
        pool.Push(used);
    }

}
