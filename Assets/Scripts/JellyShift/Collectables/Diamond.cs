using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace JellyShift.Collectables
{
    public class Diamond : MonoBehaviour
    {
        private const string PlayerTag = "Player";
        [SerializeField] private ParticleSystem _particle;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
               // transform.DOKill();
                //Instantiate(_particle, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
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
    }
}