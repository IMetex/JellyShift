using System.Collections;
using DG.Tweening;
using JellyShift.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JellyShift.UI.Screens
{
    public class MenuScreen : MonoBehaviour
    {
        [Header("Button Reference")]
        [SerializeField] private Button playBtn;
        
        [Header("Transform Reference")]
        [SerializeField] private Transform containerTransform;
        [SerializeField] private RectTransform highScoreTransform;
        
        [Header("UI Text References")]
        [SerializeField] private TMP_Text highScoreText;
        [SerializeField] private TMP_Text diamondText;

        [Header("CanvasGroup Reference")]
        [SerializeField] private CanvasGroup canvasGroup;
        private void OnEnable()
        {
            playBtn.onClick.AddListener(OnPlayButtonClicked);
        }
        
        private void OnDisable()
        {
            playBtn.onClick.RemoveListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            GameManager.Instance.StartGame();
        }

        public void Open()
        {
            TotalDiamondText();
            gameObject.SetActive(true);
            canvasGroup.DOFade(1, 0.2f).From(0);
            containerTransform.DOLocalMoveY(0, 0.7f)
                .From(-300)
                .SetEase(Ease.OutBack)
                .OnComplete(DisplayHighScoreText);
        }

        public void Close()
        {
            canvasGroup.DOFade(0, .2f)
                .OnComplete(() => gameObject.SetActive(false));
        }

        private void TotalDiamondText()
        {
            diamondText.text = GameManager.Instance.TotalDiamondScore.ToString();
        }
        
        private void DisplayHighScoreText()
        {
            highScoreText.text = "HighScore " + GameManager.Instance.HighScore;
            var defaultSizeDelta = highScoreTransform.sizeDelta;
            highScoreTransform.DOSizeDelta(defaultSizeDelta, 1f)
                .From(new Vector2(50, defaultSizeDelta.y));
        }
    }
}