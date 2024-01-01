using JellyShift.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JellyShift.UI.Display
{
    public class DiamondDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text diamondText;
        private void OnEnable()
        {
            GameManager.Instance.DiamondChanged += OnDiamondChanged;
            UpdateUI();
        }

        private void OnDisable()
        {
            GameManager.Instance.DiamondChanged -= OnDiamondChanged;
        }

        private void OnDiamondChanged(int score)
        {
            UpdateUI(score);
        }
        
        private void UpdateUI(int value)
        {
            diamondText.text = value.ToString();
        }
        private void UpdateUI()
        {
            UpdateUI(GameManager.Instance.Score);
        }
    }
}