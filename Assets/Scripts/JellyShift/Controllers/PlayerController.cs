using JellyShift.Managers;
using UnityEngine;

namespace JellyShift.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private Vector3 _initialPosition;
        private Vector3 _initialScale = Vector3.one;

        public float minX;
        public float maxX;
        public float minY;
        public float maxY;

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

        private void OnGameStart()
        {
            _initialPosition = transform.position;
            _initialScale = transform.localScale;
        }

        private void OnGameReset()
        {
            transform.position = _initialPosition;
            transform.localScale = _initialScale;
        }

        public void ChangeScale(float deltaY)
        {
            if (InputManager.Instance.isInputEnabled)
            {
                float newYScale = transform.localScale.y + deltaY * 0.01f;
                float newXScale = transform.localScale.x - deltaY * 0.01f;

                newXScale = transform.localScale.x + deltaY * 0.01f;
                newYScale = transform.localScale.y - deltaY * 0.01f;

                newYScale = Mathf.Clamp(newYScale, minY, maxY);
                newXScale = Mathf.Clamp(newXScale, minX, maxX);

                transform.localScale = new Vector3(newXScale, newYScale, transform.localScale.z);
            }
        }
    }
}