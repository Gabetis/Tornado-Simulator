using UnityEngine;
using System.Collections.Generic;
public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private int poolSize = 10;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            Debug.Log("Out of Object");
            return null;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
