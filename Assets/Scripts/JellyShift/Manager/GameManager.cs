using System;
using UnityEngine.SceneManagement;
using JellyShift.Singleton;
using UnityEngine;

namespace JellyShift.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        #region Private Int Values

        private int _score;
        private int _diamondScore;

        #endregion

        #region Events

        public event Action GameStarted;
        public event Action GameEnded;
        public event Action<int> DiamondChanged;
        public event Action<int> ScoreChanged;

        #endregion

        #region String Hash

        private const string HighScorePrefsString = "HighScore";
        private const string TotalDiamondPrefsString = "TotalDiamond";

        #endregion

        public bool IsGameStarted { get; set; }
        public int CollectDiamondCount { get; private set; }

        public int HighScore
        {
            get => PlayerPrefs.GetInt(HighScorePrefsString, 0);
        }

        public int TotalDiamondScore
        {
            get => PlayerPrefs.GetInt(TotalDiamondPrefsString, 0);
        }


        public int DiamondScore
        {
            get => _diamondScore;
            set
            {
                _diamondScore = value;
                DiamondChanged?.Invoke(_diamondScore);
            }
        }

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
            SaveHighScore();
            SaveTotalDiamondScore();
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

        private void SaveHighScore()
        {
            if (_score > PlayerPrefs.GetInt(HighScorePrefsString))
            {
                PlayerPrefs.SetInt(HighScorePrefsString, _score);
            }
        }

        private void SaveTotalDiamondScore()
        {
            PlayerPrefs.SetInt(TotalDiamondPrefsString, TotalDiamondScore + _diamondScore);
            CollectDiamondCount = _diamondScore;
            _diamondScore = 0;
            DiamondChanged?.Invoke(_diamondScore);
        }
    }
}