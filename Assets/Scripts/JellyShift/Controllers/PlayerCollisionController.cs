using System;
using DG.Tweening;
using JellyShift.Managers;
using JellyShift.ObjectPool;
using UnityEngine;


namespace JellyShift.Controllers
{
    public class PlayerCollisionController : MonoBehaviour
    {
        [SerializeField] private ObjectPooling objectPooling = null;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private ParticleSystem effect;
        
        private bool _isBouncing = false;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Obstacle") && !_isBouncing)
            {
               Bounce();
               StartCoroutine(GameManager.Instance.SetObstacleSpeed(12f,1f));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("ScoreCollider"))
            {
                if (_isBouncing) return;

                IncreaseObject();
                CreateRandomObstacle();
                effect.Play();
            }
        }

        private void CreateRandomObstacle()
        {
            var obstacles = objectPooling.GetPooledObject();

            if (obstacles != null)
            {
                obstacles.transform.position = spawnPoint.transform.position;
                obstacles.SetActive(true);
            }
        }
        
        private void IncreaseObject()
        {
            GameManager.Instance.Score++;
            GameManager.Instance.IncreaseObstacleSpeed();
        }

        private void Bounce()
        {
            _isBouncing = true;
            Vector3 originalPosition = transform.position;
            Vector3 bounceBackPosition = new Vector3(originalPosition.x, originalPosition.y,
                originalPosition.z - 6f);

            float bounceBackDuration = 0.2f;
            transform.DOMove(bounceBackPosition, bounceBackDuration).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                DOVirtual.DelayedCall(0.2f, () => { _isBouncing = false; });
            });
        }
    }
}