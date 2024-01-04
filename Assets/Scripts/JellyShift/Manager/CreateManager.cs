using System.Collections;
using JellyShift.ObjectPool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JellyShift.Manager
{
    public class CreateManager : MonoBehaviour
    {
        [Header("ObjectPool Ref")] public ObjectPooling objectPooling = null;

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
            var randomIndex = Random.Range(0, 3);

            if (other.gameObject.CompareTag(ScoreTag))
            {
                var obstacle = objectPooling.GetPooledObject(randomIndex);
                obstacle.transform.position = obstacleSpawnPoint.position;
                obstacle.SetActive(true);
            }
        }


        private IEnumerator CreateDiamond()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
                var randomIndex = Random.Range(3, 7);
                var diamond = objectPooling.GetPooledObject(randomIndex);
                diamond.transform.position = diamondSpawnPoint.position;
                diamond.SetActive(true);
            }
        }
    }
}