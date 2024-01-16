using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace JellyShift.Manager
{
    public class LoseManager : MonoBehaviour
    {
        private const string ObstacleTag = "Obstacle";
        private bool _isBouncing;
        [SerializeField] private ParticleSystem _loseEffect;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ObstacleTag))
            {
                if (!_isBouncing)
                {
                    _isBouncing = true;
                    _loseEffect.Play();
                    Bounce();
                    GameManager.Instance.EndGame();
                }
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