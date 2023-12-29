using JellyShift.Managers;
using UnityEngine;

namespace JellyShift.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset;
        public float lerpValue;
        private bool _isFollowingPlayer = true;
        
        private void OnEnable()
        {
            GameManager.GameStarted += OnGameStart;
            GameManager.GameEnd += OnGameEnd;
        }
        private void OnDisable()
        {
            GameManager.GameStarted -= OnGameStart;
            GameManager.GameEnd -= OnGameEnd;
        }

        private void OnGameStart()
        {
            _isFollowingPlayer = true;
        }

        private void OnGameEnd(bool isGameOver)
        {
            if (isGameOver)
            {
                _isFollowingPlayer = false;
            }
            
        }
        private void LateUpdate()
        {
            if (_isFollowingPlayer)
            {
                Vector3 pos = target.position + offset;
                pos.y = 8.2f;
                transform.position = Vector3.Lerp(transform.position, pos, lerpValue);
            }
        }
    }
}
