using System;
using JellyShift.Manager;
using JellyShift.UI.Screens;
using UnityEngine;

namespace JellyShift.UI
{
    public class UIPageController : MonoBehaviour
    {
        [Header("Game Screens")]
        [SerializeField] private MenuScreen menuScreen;
        [SerializeField] private GameObject gameScreen;
        [SerializeField] private GameObject loseScreen;

        private void Start()
        {
            ResetUIState();
        }

        private void OnEnable()
        {
            GameManager.Instance.GameStarted += OnGameStarted;
            GameManager.Instance.GameEnded += OnGameEnded;
        }

        private void OnDisable()
        {
            GameManager.Instance.GameStarted -= OnGameStarted;
            GameManager.Instance.GameEnded -= OnGameEnded;
        }

        private void OnGameStarted()
        {
            menuScreen.Close();
            gameScreen.SetActive(true);
        }

        private void OnGameEnded()
        {
            gameScreen.SetActive(false);
            loseScreen.SetActive(true);
        }
        
        public void ResetUIState()
        {
            menuScreen.Open();
            gameScreen.SetActive(false);
            loseScreen.SetActive(false);
        }
    }
}