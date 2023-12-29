using System;
using System.Collections;
using JellyShift.Managers;
using UnityEngine;

namespace JellyShift.Remaining
{
    public class RemainingChances : MonoBehaviour
    {
        [SerializeField] private float startingLives;
        public float CurrentLives { get; private set; }
        private bool _isTakeDamage = false;

        private void OnEnable()
        {
            GameManager.GameStarted += OnGameStart;
            GameManager.GameReset += OnGameReset;
        }

        private void OnDisable()
        {
            GameManager.GameStarted -= OnGameStart;
            GameManager.GameReset -= OnGameReset;
        }

        private void OnGameReset()
        {
            CurrentLives = startingLives;
        }

        private void OnGameStart()
        {
            CurrentLives = startingLives;
        }
        
        private void ChangeLive(float damage)
        {
            CurrentLives -= damage;

            if (CurrentLives <= 0)
            {
                GameManager.Instance.EndGame(true);
            }

            _isTakeDamage = true;
            StartCoroutine(ResetDamageFlag());
        }

        private IEnumerator ResetDamageFlag()
        {
            yield return new WaitForSeconds(0.5f);
            _isTakeDamage = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Obstacle") && !_isTakeDamage)
            {
                ChangeLive(1);
            }
        }
    }
}