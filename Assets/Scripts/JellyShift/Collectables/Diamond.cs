using System;
using DG.Tweening;
using UnityEngine;

namespace JellyShift.Collectables
{
    public class Diamond : MonoBehaviour
    {
        private const string PlayerTag = "Player";
        [SerializeField] private float endYValue;
        [SerializeField] private float duration;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                CollectAnimation();
                _audioSource.Play();
            }   
        }

        private void OnEnable()
        {
            transform.DORotate(Vector3.up * -360, 2f, RotateMode.LocalAxisAdd)
                .SetLoops(-1)
                .SetEase(Ease.Linear);
        }

        private void OnDisable()
        {
            transform.DOKill();
        }

        private void CollectAnimation()
        {
            Vector3 scale = transform.localScale;

            transform.DOKill();
            transform.DOScale(0.15f, duration);
            transform.DOMoveY(endYValue - transform.position.y, duration);
            transform.DOMoveX(endYValue - transform.position.y, duration)
                .OnComplete(() =>
                {
                     // Deactivate the object
                    transform.gameObject.SetActive(false);
                    
                    // Reset scale and move down
                    transform.DOScale(scale, duration);
                    transform.DOMoveY(endYValue - transform.position.y, duration);
                });
        }
    }
}