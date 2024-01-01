using System;
using System.Collections;
using JellyShift.Manager;
using TMPro;
using UnityEngine;

namespace JellyShift.UI.Display
{
    public class PerfectDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text perfectText;
        [SerializeField] private TMP_Text valueText;

        private void OnEnable()
        {
            GameManager.Instance.ScoreChanged += HandleScoreChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.ScoreChanged -= HandleScoreChanged;
        }

        private void HandleScoreChanged(int newScore)
        {
            StartCoroutine(DisplayPerfectText());
        }

        private IEnumerator DisplayPerfectText()
        {
            DisplayText();
            SetTextVisibility(true);
            yield return new WaitForSeconds(0.5f);
            SetTextVisibility(false);
        }

        private void DisplayText()
        {
            perfectText.text = "Perfect";
            valueText.text = "x" + GameManager.Instance.Score;
        }
        
        private void SetTextVisibility(bool visibility)
        {
            perfectText.gameObject.SetActive(visibility);
            valueText.gameObject.SetActive(visibility);
        }
    }
}