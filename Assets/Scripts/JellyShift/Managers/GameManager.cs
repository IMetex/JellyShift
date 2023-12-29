using System;
using System.Collections;
using JellyShift.Controllers;
using JellyShift.Enum;
using JellyShift.PlayerPrefs;
using JellyShift.Singleton;
using UnityEngine;
namespace JellyShift.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public GameState GameState { get; set; }

        public static Action GameStarted;
        public static Action<bool> GameEnd;
        public static Action GameReset;
        public static Action<int> Scored;
        public static Action<int> DiamondScored;

        [SerializeField] private InputManager inputManager;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private UIManager uiManager;

        private bool _isGameOver;
        private int _scoreCount = 0;
        private float _obstacleSpeed = 18f;

        public float ObstacleSpeed
        {
            get => _obstacleSpeed;
            set => _obstacleSpeed = value;
        }

        public int Score
        {
            get => _scoreCount;
            set
            {
                _scoreCount = value;
                Scored?.Invoke(_scoreCount);
            }
        }

        void Start()
        {
            GameInitialize();
        }
        
        
        private void GameInitialize()
        {
            inputManager.Initialize(playerController);
            uiManager.Initialize(inputManager, playerController);
            OnGameStart();
        }

        private void OnGameStart()
        {
            ChangeState(GameState.Start);
        }

        public void ResetGame()
        {
            ChangeState(GameState.Reset);
            OnGameStart();
        }

        public void EndGame(bool isGameOver)
        {
            _isGameOver = isGameOver;
            ChangeState(GameState.End);
        }

        public void ChangeState(GameState gameState)
        {
            GameState = gameState;

            switch (gameState)
            {
                case GameState.Start:
                    GameStarted?.Invoke();
                    break;

                case GameState.Playing:
                    break;

                case GameState.End:
                    GameEnd?.Invoke(_isGameOver);
                    if (_isGameOver)
                    {
                        DiamondScoreAdd(_scoreCount);
                    }

                    break;

                case GameState.Reset:
                    GameReset?.Invoke();
                    ResetScore();
                    break;
            }
        }

        public void DiamondScoreAdd(int score)
        {
            PlayerPrefsManager.DiamondScore += score;
            DiamondScored?.Invoke(PlayerPrefsManager.DiamondScore);
        }

        private void ResetScore()
        {
            _scoreCount = 0;
            Scored?.Invoke(_scoreCount);
        }

        public IEnumerator SetObstacleSpeed(float speed, float duration)
        {
            _obstacleSpeed -= speed;
            yield return new WaitForSeconds(duration);
            _obstacleSpeed += speed;
        }

        public float IncreaseObstacleSpeed()
        {
            _obstacleSpeed += 0.5f;
            return _obstacleSpeed;
        }
    }
}