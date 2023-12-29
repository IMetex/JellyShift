using System;
using System.Collections.Generic;
using UnityEngine;

namespace JellyShift.ObjectPool
{
    public class ObjectPooling : MonoBehaviour
    {
        [Serializable]
        public struct Pool
        {
            public Queue<GameObject> pooledObjects;
            public GameObject objectPrefab;
            public int poolSize;
        }

        [SerializeField] private Pool[] pools = null;

        private void Awake()
        {
            InitializePools();
        }

        private void InitializePools()
        {
            for (int j = 0; j < pools.Length; j++)
            {
                pools[j].pooledObjects = new Queue<GameObject>();

                for (int i = 0; i < pools[j].poolSize; i++)
                {
                    GameObject obj = Instantiate(pools[j].objectPrefab, transform);
                    obj.SetActive(false);

                    pools[j].pooledObjects.Enqueue(obj);
                }
            }
        }

        public GameObject GetPooledObject()
        {
            int randomIndex = UnityEngine.Random.Range(0, pools.Length);
            GameObject objFromPool = pools[randomIndex].pooledObjects.Dequeue();
            objFromPool.SetActive(true);
            pools[randomIndex].pooledObjects.Enqueue(objFromPool);
            return objFromPool;
        }
    }
}