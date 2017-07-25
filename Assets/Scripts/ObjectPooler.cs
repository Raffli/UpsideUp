using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem{
    public int amountToPool;
    public GameObject objectToPool;
}

public class ObjectPooler : MonoBehaviour {

    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;

    public static ObjectPooler SharedInstance;
    public GameManager gm;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
        gm.startBuilding();

    }

    void Update () {
		
	}

    public GameObject GetPooledObject(string tag)
    {
        print("get pooled object" + tag);
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                print("return object" + tag);

                return pooledObjects[i];
            }
        }
        print("return null" + tag);

        return null;
    }
}
