using System;
using DG.Tweening;
using JellyShift.Manager;
using UnityEngine;

namespace JellyShift.Animation
{
    public class PlayerIdleAnimation : MonoBehaviour
    {
        private bool _isPlayed;
        private Sequence _idleAnimation;
        [SerializeField] private Vector3 scale;
        [SerializeField] private float duration;

        private void OnEnable()
        {
            GameManager.Instance.GameStarted += OnGameStarted;
            InitializeAnimation();
        }

        private void OnDisable()
        {
            if (_isPlayed)
            {
                _idleAnimation.Kill();
            }

            GameManager.Instance.GameStarted -= OnGameStarted;
        }

        private void InitializeAnimation()
        {
            if (!_isPlayed)
            {
                _idleAnimation = DOTween.Sequence()
                    .Append(transform.DOScale(scale, duration))
                    .SetLoops(-1, LoopType.Yoyo)
                    .SetEase(Ease.OutBack);

                _isPlayed = true;
            }
        }

        private void OnGameStarted()
        {
            if (_isPlayed)
            {
                _idleAnimation.Kill();
            }
        }
    }
}