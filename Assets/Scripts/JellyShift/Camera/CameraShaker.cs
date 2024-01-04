using System;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace JellyShift.Camera
{
    public class CameraShaker : MonoBehaviour
    {
        private const string ScoreTag = "Score";
        
        [SerializeField] private new CinemachineVirtualCamera camera;
        [SerializeField] private float duration;
        [SerializeField] private float strength;
        [SerializeField] private int vibration;
        [SerializeField] private int randomness;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ScoreTag))
            {
                ShakeCamera();
            }
        }
        private void ShakeCamera()
        {
            camera.transform.DOShakeRotation(duration, strength, vibration, randomness, fadeOut: false);
        }
    }
}