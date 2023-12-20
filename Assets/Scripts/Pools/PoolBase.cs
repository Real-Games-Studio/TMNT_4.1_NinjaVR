using UnityEngine;
using System.Collections.Generic;

public class PoolBase<T> where T : Component
{
    private T prefab;
    private Queue<T> pool = new Queue<T>();
    private Transform objectsParent;

    public PoolBase(T prefab, int initialSize, Transform objectsParentTemp = null)
    {
        this.prefab = prefab;

        objectsParent = objectsParentTemp ? objectsParentTemp : GameObject.FindGameObjectWithTag("bulletscontender").transform;

        for (int i = 0; i < initialSize; i++)
        {
            T newObj = CreateObject();
            ObjectOff(newObj);
        }
    }
    public T GetObjectFromPool()
    {
        if (pool.Count > 0)
        {
            T obj = pool.Dequeue();
            obj.gameObject.SetActive(true);

            return obj;
        }

        return CreateObject();
    }
    public void ObjectOff(T targetObject)
    {
        targetObject.gameObject.SetActive(false);
        pool.Enqueue(targetObject);
    }
    private T CreateObject()
    {
        T newObj = Object.Instantiate(prefab, objectsParent);
        newObj.gameObject.SetActive(true);
        return newObj;
    }

}