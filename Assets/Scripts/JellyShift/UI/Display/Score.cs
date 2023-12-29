using JellyShift.Managers;
using TMPro;
using UnityEngine;

namespace JellyShift.UI.Display
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        private void OnEnable()
        {
            GameManager.Scored += OnScored;
        }

        private void OnDisable()
        {
            GameManager.Scored -= OnScored;
        }

        public void OnScored(int score)
        {
            scoreText.text = GameManager.Instance.Score.ToString();
        }
    }
}