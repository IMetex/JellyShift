using JellyShift.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace JellyShift.UI.Display
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        private void OnEnable()
        {
            GameManager.Instance.ScoreChanged += OnScoreChanged;
            UpdateUI();
        }

        private void OnDisable()
        {
            GameManager.Instance.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int score)
        {
            UpdateUI(score);
        }
        
        private void UpdateUI(int value)
        {
            scoreText.text = value.ToString();
        }
        private void UpdateUI()
        {
            UpdateUI(GameManager.Instance.Score);
        }
    }
}
