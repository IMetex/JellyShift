using JellyShift.Manager;
using TMPro;
using UnityEngine;

namespace JellyShift.UI.Display
{
    public class TotalDiamondDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text totalDiamondText;
        private void OnEnable()
        {
            GameManager.Instance.TotalDiamondChanged += OnTotalDiamondChanged;
            UpdateUI();
        }

        private void OnDisable()
        {
            GameManager.Instance.TotalDiamondChanged -= OnTotalDiamondChanged;
        }

        private void OnTotalDiamondChanged(int diamondScore)
        {
            UpdateUI(diamondScore);
        }
        
        private void UpdateUI(int value)
        {
            totalDiamondText.text = value.ToString();
        }
        private void UpdateUI()
        {
            UpdateUI(GameManager.Instance.TotalDiamondScore);
        }
    }
}