using System.Collections;
using JellyShift.ObjectPool;
using UnityEngine;

namespace JellyShift.Manager
{
    public class CreateManager : MonoBehaviour
    {
        [Header("ObjectPool Ref")] [SerializeField]
        private ObjectPoolManager objectPooling = null;

        [Header("Transform References")] [SerializeField]
        private Transform obstacleSpawnPoint;

        [SerializeField] private Transform diamondSpawnPoint;

        [Header("Diamond Create Time")] [SerializeField]
        private float minInterval = 2f;

        [SerializeField] private float maxInterval = 5f;

        private const string ScoreTag = "Score";

        private void Start()
        {
            StartCoroutine(CreateDiamond());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ScoreTag))
            {
                SpawnFromPool(objectPooling.ObstaclePools, obstacleSpawnPoint);
            }
        }

        private IEnumerator CreateDiamond()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
                SpawnFromPool(objectPooling.DiamondPools, diamondSpawnPoint);
            }
        }

        private void SpawnFromPool(ObjectPool.ObjectPool[] pools, Transform spawnPoint)
        {
            var randomIndex = Random.Range(0, pools.Length);
            var objectFromPool = objectPooling.GetPooledObject(pools, randomIndex);
            objectFromPool.transform.position = spawnPoint.position;
            objectFromPool.SetActive(true);
        }
    }
}