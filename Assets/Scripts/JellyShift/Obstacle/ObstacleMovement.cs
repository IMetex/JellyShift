using System;
using JellyShift.Enum;
using JellyShift.Managers;
using UnityEngine;

namespace JellyShift.Movements
{
    public class ObstacleMovement : MonoBehaviour
    {
        private Vector3 _initialPosition;
        
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

        }

        private void OnGameReset()
        {
            transform.position = _initialPosition;
            GameManager.Instance.ObstacleSpeed = 18f;
        }

        private void Update()
        {
            MoveForward();
        }
        
        private void MoveForward()
        {
            if (GameManager.Instance.GameState == GameState.Playing)
            {
                transform.position += -transform.forward * (GameManager.Instance.ObstacleSpeed * Time.deltaTime);
            }
        }
    }
}