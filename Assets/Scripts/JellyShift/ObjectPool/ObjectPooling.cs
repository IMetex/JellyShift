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
            public Queue<GameObject> PooledObjects;
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
                pools[j].PooledObjects = new Queue<GameObject>();

                for (int i = 0; i < pools[j].poolSize; i++)
                {
                    GameObject obj = Instantiate(pools[j].objectPrefab, transform);
                    obj.SetActive(false);
                    pools[j].PooledObjects.Enqueue(obj);
                }
            }
        }


        public GameObject GetPooledObject()
        {
            int randomIndex = UnityEngine.Random.Range(0, pools.Length);

            if (pools[randomIndex].PooledObjects.Count == 0)
            {
                AddSizePool(3f, randomIndex);
            }

            GameObject obj = pools[randomIndex].PooledObjects.Dequeue();
            obj.SetActive(true);
            pools[randomIndex].PooledObjects.Enqueue(obj);
            return obj;
        }

        public void AddSizePool(float amount, int index)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject obj = Instantiate(pools[index].objectPrefab, transform);
                obj.SetActive(false);
                pools[index].PooledObjects.Enqueue(obj);
            }
        }
    }
}