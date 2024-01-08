using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace JellyShift.Manager
{
    public class LoseManager : MonoBehaviour
    {
        private const string ObstacleTag = "Obstacle";
        private bool _isBouncing;
        [SerializeField] private AudioSource mainAudioSource;
        [SerializeField] private AudioSource loseAudioSource;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ObstacleTag) && !_isBouncing)
            {
                Bounce();
                mainAudioSource.Stop();
                loseAudioSource.Play();
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
