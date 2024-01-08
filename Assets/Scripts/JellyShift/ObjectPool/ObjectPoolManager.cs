using System;
using System.Collections.Generic;
using UnityEngine;

namespace JellyShift.ObjectPool
{
    [Serializable]
    public class ObjectPool
    {
        public Queue<GameObject> PooledObjects;
        public GameObject ObjectPrefab;
        public int InitialPoolSize;
    }
    
    public class ObjectPoolManager : MonoBehaviour
    {
        public ObjectPool[] ObstaclePools;
        public ObjectPool[] DiamondPools;

        private const float PoolExpansionFactor = 3f;

        private void Awake()
        {
            InitializeAllPools();
        }
        
        private void InitializeAllPools()
        {
            InitializePools(ObstaclePools);
            InitializePools(DiamondPools);
        }

        private void InitializePools(ObjectPool[] pools)
        {
            foreach (var pool in pools)
            {
                pool.PooledObjects = new Queue<GameObject>();
                for (int i = 0; i < pool.InitialPoolSize; i++)
                {
                    AddObjectToPool(pool);
                }
            }
        }

        private void AddObjectToPool(ObjectPool pool)
        {
            var newObj = Instantiate(pool.ObjectPrefab, transform);
            newObj.SetActive(false);
            pool.PooledObjects.Enqueue(newObj);
        }

        public GameObject GetPooledObject(ObjectPool[] pools, int objectType)
        {
            if (objectType >= pools.Length) return null;

            var pool = pools[objectType];
            if (pool.PooledObjects.Count == 0)
            {
                ExpandPool(pool);
            }

            var obj = pool.PooledObjects.Dequeue();
            obj.SetActive(true);
            pool.PooledObjects.Enqueue(obj);

            return obj;
        }

        private void ExpandPool(ObjectPool pool)
        {
            for (int i = 0; i < PoolExpansionFactor; i++)
            {
                AddObjectToPool(pool);
            }
        }
    }
}