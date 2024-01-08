using JellyShift.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace JellyShift.UI.Screens
{
    public class SettingsScreen : MonoBehaviour
    {
        [Header("Setting Panel")] [SerializeField]
        private GameObject pausedPanel;

        [Header("Buttons")] 
        [SerializeField] private Button pauseBtn;
        [SerializeField] private Button resumeBtn;
        [SerializeField] private Button mainMenuBtn;

        private void OnEnable()
        {
            pauseBtn.onClick.AddListener(OnPausesButtonClicked);
            mainMenuBtn.onClick.AddListener(OnMainButtonClicked);
            resumeBtn.onClick.AddListener(OnResumeButtonClicked);
        }

        private void OnDisable()
        {
            pauseBtn.onClick.RemoveListener(OnPausesButtonClicked);
            mainMenuBtn.onClick.RemoveListener(OnMainButtonClicked);
            resumeBtn.onClick.RemoveListener(OnResumeButtonClicked);
        }

        private void OnPausesButtonClicked()
        {
            PauseGame();
        }

        private void OnMainButtonClicked()
        {
            GameManager.Instance.RestartLevel();
            GameManager.Instance.IsGameStarted = false;
            ResumeGame();
        }

        private void OnResumeButtonClicked()
        {
            ResumeGame();
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            pausedPanel.SetActive(true);
        }

        private void ResumeGame()
        {
            Time.timeScale = 1;
            pausedPanel.SetActive(false);
        }
    }
}