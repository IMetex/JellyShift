using JellyShift.Controllers;
using JellyShift.Enum;
using JellyShift.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace JellyShift.UI
{
    public class GameCanvas : MonoBehaviour
    {
        private SettingsCanvas _settingsCanvas;
        private PlayerController _playerController;

        [SerializeField] private GameObject scorePanel;
        [SerializeField] private GameObject starPanel;
 
        
        [Header("Panel")] 
        [SerializeField] private GameObject pausedPanel;
        
        [Header("Buttons")] 
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button mainMenuButton;


        public void Initialize(SettingsCanvas settingsCanvas, PlayerController player)
        {
            _settingsCanvas = settingsCanvas;
            _playerController = player;

            settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            pauseButton.onClick.AddListener(OnPausedButton);
            resumeButton.onClick.AddListener(OnResumeButton);
            mainMenuButton.onClick.AddListener(OnMainMenuButton);
        }

        private void OnEnable()
        {
            GameManager.GameStarted += OnGameStart;
            GameManager.GameReset += OnGameReset;
            GameManager.GameEnd += OnGameEnd;
        }

        private void OnDisable()
        {
            GameManager.GameStarted -= OnGameStart;
            GameManager.GameReset -= OnGameReset;
            GameManager.GameEnd -= OnGameEnd;
        }

        private void OnGameStart()
        {
            playButton.onClick.AddListener(OnPlayButtonClick);
            
            settingsButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
           
            
            Time.timeScale = 1;
        }

        private void OnGameReset()
        {
            playButton.gameObject.SetActive(true);
            scorePanel.SetActive(false);
            starPanel.SetActive(false);
        }

        private void OnGameEnd(bool isGameOver)
        {
            if (isGameOver)
            {
                pauseButton.gameObject.SetActive(false);
            }
        }

        private void OnPlayButtonClick()
        {
            GameManager.Instance.ChangeState(GameState.Playing);
            playButton.gameObject.SetActive(false);
            
            scorePanel.SetActive(true);
            starPanel.SetActive(true);
        }

        private void OnSettingsButtonClicked()
        {
            _settingsCanvas.SettingPanel();
        }

        private void OnPausedButton()
        {
            PauseGame();
        }

        private void OnResumeButton()
        {
            ResumeGame();
        }

        private void OnMainMenuButton()
        {
            GameManager.Instance.ResetGame();
            pausedPanel.SetActive(false);
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            pausedPanel.SetActive(true);
            pauseButton.gameObject.SetActive(false);
        }

        private void ResumeGame()
        {
            Time.timeScale = 1;
            pausedPanel.SetActive(false);
            pauseButton.gameObject.SetActive(true);
        }
        
        private void Update()
        {
            if (GameManager.Instance.GameState == GameState.Playing)
            {
                settingsButton.gameObject.SetActive(false);
                pauseButton.gameObject.SetActive(true);
               
            }
        }
    }
}