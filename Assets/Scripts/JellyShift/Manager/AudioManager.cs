using System;
using System.Collections;
using UnityEngine;

namespace JellyShift.Manager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource mainAudioSource;
        [SerializeField] private AudioSource loseAudioSource;
        [SerializeField] private AudioSource diamondAudioSource;
        [SerializeField] private AudioSource scoreAudioSource;

        private void OnEnable()
        {
            StartCoroutine(Delay());
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(0.01f);
            GameManager.Instance.GameEnded += OnGameEnded;
            GameManager.Instance.DiamondChanged += OnDiamondChanged;
            GameManager.Instance.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.GameEnded -= OnGameEnded;
            GameManager.Instance.DiamondChanged -= OnDiamondChanged;
            GameManager.Instance.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int obj)
        {
            scoreAudioSource.Play();
        }

        private void OnDiamondChanged(int obj)
        {
            diamondAudioSource.Play();
        }

        private void OnGameEnded()
        {
            mainAudioSource.Stop();
            loseAudioSource.Play();
        }
    }
}