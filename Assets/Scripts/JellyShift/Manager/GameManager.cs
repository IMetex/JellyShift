using System;
using System.Collections;
using System.Collections.Generic;
using JellyShift.Animation;
using UnityEngine.SceneManagement;
using JellyShift.Singleton;
using UnityEngine;

namespace JellyShift.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public bool IsGameStarted { get; private set; }

        public event Action GameStarted;
        public event Action GameEnded;
        public event Action<int> DiamondChanged;
        public event Action<int> ScoreChanged;

        public int HighScore { get; set; }

        private int _diamondScore;

        public int DiamondScore
        {
            get => _diamondScore;
            set
            {
                _diamondScore = value;
                DiamondChanged?.Invoke(_diamondScore);
            }
        }

        private int _score;

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                ScoreChanged?.Invoke(_score);
            }
        }

        public void StartGame()
        {
            IsGameStarted = true;
            SetValues();
            GameStarted?.Invoke();
        }

        public void EndGame()
        {
            IsGameStarted = false;
            GameEnded?.Invoke();
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(0);
        }
        
        private void SetValues()
        {
            _score = 0;
            _diamondScore = 0;
        }
    }
}