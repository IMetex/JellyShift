using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace JellyShift.ObjectPool
{
    public class ObjectPooling : MonoBehaviour
    {
        [Serializable]
        public struct Pool
        {
            public Queue<GameObject> PooledObjects;
            public GameObject objectPrefab;
            public int poolSize;
        }

        public Pool[] pools = null;

        private void Awake()
        {
            InitializePools();
        }

        private void InitializePools()
        {
            for (int j = 0; j < pools.Length; j++)
            {
                pools[j].PooledObjects = new Queue<GameObject>();

                for (int i = 0; i < pools[j].poolSize; i++)
                {
                    GameObject obj = Instantiate(pools[j].objectPrefab, transform);
                    obj.SetActive(false);
                    pools[j].PooledObjects.Enqueue(obj);
                }
            }
        }


        public GameObject GetPooledObject(int objectType)
        {
            if (objectType >= pools.Length) return null;

            if (pools[objectType].PooledObjects.Count == 0)
            {
                AddSizePool(3f, objectType);
            }

            GameObject obj = pools[objectType].PooledObjects.Dequeue();
            obj.SetActive(true);
            pools[objectType].PooledObjects.Enqueue(obj);
            return obj;
        }

        private void AddSizePool(float amount, int objectType)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject obj = Instantiate(pools[objectType].objectPrefab, transform);
                obj.SetActive(false);
                pools[objectType].PooledObjects.Enqueue(obj);
            }
        }
    }
}