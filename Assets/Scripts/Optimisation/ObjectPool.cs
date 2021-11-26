using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool sharedInstance;
    [SerializeField] List<GameObject> pooledObjects;
    [SerializeField] GameObject objectToPool;
    [SerializeField] int amountToPool;
    [SerializeField] Transform pooledObjectsStorage;

    void Awake()
    {
        sharedInstance = this;
        pooledObjects = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < amountToPool; i++)
        {
            temp = Instantiate(objectToPool);
            temp.transform.SetParent(pooledObjectsStorage);
            temp.SetActive(false);
            pooledObjects.Add(temp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy) return pooledObjects[i];
        }
        return null;
    }
}
