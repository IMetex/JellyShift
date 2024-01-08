using System;
using System.Collections;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace JellyShift.Camera
{
    public class CameraShaker : MonoBehaviour
    {
        private const string ScoreTag = "Score";
        
        [SerializeField] private new CinemachineVirtualCamera _gameCamera;
        [SerializeField] private new CinemachineVirtualCamera _scoreCamera;
        [SerializeField] private float duration;
        [SerializeField] private float strength;
        [SerializeField] private int vibration;
        [SerializeField] private int randomness;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ScoreTag))
            {
                ShakeCamera();
                StartCoroutine(ZoomCamera());
            }
        }
        private void ShakeCamera()
        {
            _gameCamera.transform.DOShakeRotation(duration, strength, vibration, randomness, fadeOut: false);
        }

        private IEnumerator ZoomCamera()
        {
            _scoreCamera.Priority =  1;
            _gameCamera.Priority = 0;
            yield return new WaitForSeconds(0.2f);
            _scoreCamera.Priority =  0;
            _gameCamera.Priority = 1;
        }
    }
}