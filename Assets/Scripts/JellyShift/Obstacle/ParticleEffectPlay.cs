using System;
using System.Collections;
using System.Collections.Generic;
using JellyShift.Movement;
using UnityEngine;

namespace JellyShift.Obstacle
{
    public class ParticleEffectPlay : MonoBehaviour
    {
        [Header("ParticleEffect Reference")]
        [SerializeField] private ParticleSystem effect;
        
        private const string PlayerTag = "Player";

        private ForwardMovement _movement;

        private void Awake()
        {
            _movement = GetComponentInParent<ForwardMovement>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                effect.Play();
                StartCoroutine(SpeedChange());
            }
        }

        private IEnumerator SpeedChange()
        {
            _movement.Speed += 5;
            yield return new WaitForSeconds(0.5f);
            _movement.Speed -= 5;
        }
    }
}