using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace JellyShift.Collectables
{
    public class Diamond : MonoBehaviour
    {
        private const string PlayerTag = "Player";
        [SerializeField] private float endYValue;
        [SerializeField] private float duration;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                CollectAnimation();
            }
        }

        private void OnEnable()
        {
            transform.DORotate(Vector3.up * 360, 2f, RotateMode.WorldAxisAdd)
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
            transform.DOMoveY(transform.position.y + endYValue, duration)
                .OnComplete(() =>
                {
                    transform.gameObject.SetActive(false);
                    transform.DOScale(scale, duration);
                    transform.DOMoveY(transform.position.y - endYValue, duration);
                });
        }
    }
}