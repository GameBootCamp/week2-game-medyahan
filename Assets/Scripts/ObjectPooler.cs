using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : Singleton<ObjectPooler>
{
    [SerializeField]
    private List<PoolItem> poolItemList = new List<PoolItem>();
    private Dictionary<PoolItemType, Queue<GameObject>> POOL;

    private void Start()
    {
        POOL = new Dictionary<PoolItemType, Queue<GameObject>>();

        foreach (PoolItem item in poolItemList)
        {
            Queue<GameObject> objectQue = new Queue<GameObject>();

            for (int i = 0; i < item.quantity; i++)
            {
                GameObject gameObject = Instantiate(item.poolItem);
                gameObject.SetActive(false);
                objectQue.Enqueue(gameObject);
            }

            POOL.Add(item.poolItemType, objectQue);
        }
    }

    public GameObject getFromPool(PoolItemType objectType, Vector3 getPosition, Quaternion rotation)
    {

        GameObject poolItem = POOL[objectType].Dequeue();
        poolItem.SetActive(true);
        poolItem.transform.position = getPosition;
        poolItem.transform.rotation = rotation;

        return poolItem;
    }

    public void PoolDestroy(PoolItemType objectType, GameObject objectToDestroy)
    {
        objectToDestroy.SetActive(false);
        POOL[objectType].Enqueue(objectToDestroy);
    }
}


[System.Serializable]
public class PoolItem
{
    public PoolItemType poolItemType;
    public GameObject poolItem;
    public int quantity;
}

public enum PoolItemType
{
    enemy,
    gold
}