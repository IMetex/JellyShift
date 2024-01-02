using System.Collections;
using JellyShift.ObjectPool;
using UnityEngine;

namespace JellyShift
{
    public class CreateDiamond : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        public ObjectPooling objectPooling = null;
        private GameObject _diamond;

        public float minInterval = 2f; 
        public float maxInterval = 5f; 

        private void Start()
        {
            StartCoroutine(CreateDiamondRoutine());
        }

        private IEnumerator CreateDiamondRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
                
                Create();
            }
        }

        private void Create()
        {
            _diamond = objectPooling.GetPooledObject();
            _diamond.transform.position = spawnPoint.position;
            _diamond.SetActive(true);
        }
    }
}