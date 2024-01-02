using System;
using DG.Tweening;
using JellyShift.Manager;
using UnityEngine;

namespace JellyShift.Controller
{
    public class LoseController : MonoBehaviour
    {
        private const string ObstacleTag = "Obstacle";
        private bool _isBouncing;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ObstacleTag) && !_isBouncing)
            {
                Bounce();
                GameManager.Instance.EndGame();
            }
        }
        
        private void Bounce()
        {
            _isBouncing = true;
            Vector3 originalPosition = transform.position;
            Vector3 bounceBackPosition = new Vector3(originalPosition.x, originalPosition.y,
                originalPosition.z - 4f);

            float bounceBackDuration = 0.2f;
            transform.DOMove(bounceBackPosition, bounceBackDuration).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                DOVirtual.DelayedCall(0.2f, () => { _isBouncing = false; });
            });
        }
    }
}
