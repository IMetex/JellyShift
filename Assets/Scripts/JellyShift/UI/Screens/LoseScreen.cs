using DG.Tweening;
using JellyShift.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JellyShift.UI.Screens
{
    public class LoseScreen : MonoBehaviour
    {
        [SerializeField] private Button restartBtn;
        [SerializeField] private Transform containerTransform;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text diamondText;
        private void OnEnable()
        {
            restartBtn.onClick.AddListener(OnRestartButtonClicked);
            LoseScreenAnimation();
            LoseValuesText();
        }

        private void OnDisable()
        {
            restartBtn.onClick.RemoveListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            GameManager.Instance.RestartLevel();
        }
        
        private void LoseScreenAnimation()
        {
            canvasGroup.DOFade(1, 0.2f).From(0);
            containerTransform.DOLocalMoveY(0, 0.8f)
                .From(-300).SetEase(Ease.OutBack);
        }

        private void LoseValuesText()
        {
            scoreText.text = "Score: " + GameManager.Instance.Score;
            diamondText.text = GameManager.Instance.CollectDiamondCount.ToString();
        }
    }
}