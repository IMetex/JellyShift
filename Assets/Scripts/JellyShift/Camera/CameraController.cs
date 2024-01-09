using System;
using System.Collections;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace JellyShift.Camera
{
    public class CameraController : MonoBehaviour
    {
        private const string ScoreTag = "Score";

        [Header("Camera Referance")]
        [SerializeField] private CinemachineVirtualCamera _gameCamera;
        [SerializeField] private CinemachineVirtualCamera _scoreCamera;
       
        [Header("Shake Values")]
        [SerializeField] private float duration;
        [SerializeField] private float strength;
        [SerializeField] private int vibration;
        [SerializeField] private int randomness;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ScoreTag))
            {
                ShakeCamera();
                StartCoroutine(nameof(CameraZoom));
            }
        }

        private void ShakeCamera()
        {
            _gameCamera.transform.DOShakeRotation(duration, strength, vibration, randomness, fadeOut: false);
        }

        private IEnumerator CameraZoom()
        {
            _scoreCamera.Priority = 1;
            _gameCamera.Priority = 0;
            yield return new WaitForSeconds(0.2f);
            _scoreCamera.Priority = 0;
            _gameCamera.Priority = 1;
        }
    }
}