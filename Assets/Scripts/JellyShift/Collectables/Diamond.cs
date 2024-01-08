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

        [SerializeField] private ParticleSystem _particle;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                transform.DOKill();
                _audioSource.Play();
                _particle.Play();
                gameObject.SetActive(false);
            }

            if (other.gameObject.CompareTag("Deactivate"))
            {
                gameObject.SetActive(true);
            }
        }

        private void OnEnable()
        {
            transform.DORotate(Vector3.up * -360, 2f, RotateMode.WorldAxisAdd)
                .SetLoops(-1)
                .SetEase(Ease.Linear);
        }

        private void OnDisable()
        {
            transform.DOKill();
        }
    }
}