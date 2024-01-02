using System.Collections;
using System.Collections.Generic;
using JellyShift.ObjectPool;
using UnityEngine;

namespace JellyShift
{
    public class CreateObstacle : MonoBehaviour
    {
        private const string ScoreTag = "Score";
        [SerializeField] private Transform spawnPoint;
        public ObjectPooling objectPooling = null;
        private GameObject _obstacle;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ScoreTag))
            {
                _obstacle = objectPooling.GetPooledObject();
                _obstacle.transform.position = spawnPoint.position;
                _obstacle.SetActive(true);
            }
        }
    }
}