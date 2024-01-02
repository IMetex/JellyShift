using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JellyShift.ObjectPool
{
    public class ObstaclePool : MonoBehaviour
    {
        public GameObject obstacle;
        public List<GameObject> _obstaclePool;

        private GameObject _newObstacle;
        private bool _isCreateObstacle;
        private const string ScoreTag = "Score";
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ScoreTag) && !_isCreateObstacle)
            {
                CreateObstacle();
                _isCreateObstacle = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(ScoreTag))
            {
                _isCreateObstacle = false;
            }
        }

        private GameObject CreateObstacle()
        {
            for (int i = 0; i < _obstaclePool.Count; i++)
            {
                if (_obstaclePool[i] != null && !_obstaclePool[i].activeSelf)
                {
                    _obstaclePool[i].SetActive(true);
                    return _obstaclePool[i];
                }
            }

            _newObstacle = Instantiate(obstacle);
            _obstaclePool.Add(_newObstacle);
            StartCoroutine(DeactivateObstacle(_newObstacle));
            return _newObstacle;
        }

        public IEnumerator DeactivateObstacle(GameObject obj)
        {
            if (!_isCreateObstacle)
            {
                yield return new WaitForSeconds(3f);
                obj.SetActive(false);
            }
        }
    }
}