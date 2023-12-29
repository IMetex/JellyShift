using JellyShift.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace JellyShift.UI
{
    public class EndCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject endPanel;
        [SerializeField] private Button restartButton;

        public void Initialize()
        {

        }
        private void OnEnable()
        {
            GameManager.GameEnd += OnGameEnd;
        }

        private void OnDisable()
        {
            GameManager.GameEnd -= OnGameEnd;
        }


        private void OnGameEnd(bool isGameOver)
        {
            Debug.Log("111");
            if (isGameOver)
            {
                Debug.Log("222");
                endPanel.SetActive(true);
                restartButton.onClick.AddListener(RestartButtonClick);
            }
        }

        private void RestartButtonClick()
        {
            endPanel.SetActive(false);
            GameManager.Instance.ResetGame();
        }
    }
}