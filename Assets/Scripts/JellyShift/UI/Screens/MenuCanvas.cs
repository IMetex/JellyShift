using JellyShift.Enum;
using JellyShift.Managers;
using JellyShift.PlayerPrefs;
using TMPro;
using UnityEngine;

namespace JellyShift.UI
{
    public class MenuCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject diamondPanel;
        [SerializeField] private TMP_Text diamondScoreText;
        [SerializeField] private GameObject titlePanel;

        private void OnEnable()
        {
            GameManager.GameStarted += OnGameStart;
            GameManager.GameReset += OnGameReset;
            GameManager.DiamondScored += OnDiamondScored;
        }

        private void OnDisable()
        {
            GameManager.GameStarted -= OnGameStart;
            GameManager.GameReset -= OnGameReset;
            GameManager.DiamondScored -= OnDiamondScored;
        }
        
        private void OnGameReset()
        {
            titlePanel.SetActive(true);
            diamondPanel.SetActive(true);
        }

        private void OnGameStart()
        {
            titlePanel.SetActive(true);
            diamondPanel.SetActive(true);
            OnDiamondScored(PlayerPrefsManager.DiamondScore);
        }
        
        
        private void OnDiamondScored(int score)
        {
            diamondScoreText.text = PlayerPrefsManager.DiamondScore.ToString();
        }

        private void Update()
        {
            if (GameManager.Instance.GameState == GameState.Playing)
            {
                diamondPanel.SetActive(false);
                titlePanel.SetActive(false);
            }
        }
    }
}