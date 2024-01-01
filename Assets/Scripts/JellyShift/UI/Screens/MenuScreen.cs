using DG.Tweening;
using JellyShift.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JellyShift.UI.Screens
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button playBtn;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Transform containerTransform;
        [SerializeField] private RectTransform highScoreTransform;
        [SerializeField] private TMP_Text highScoreText;
        [SerializeField] private TMP_Text diamondText;

        private void OnEnable()
        {
            playBtn.onClick.AddListener(OnPlayButtonClicked);
            MenuDiamondText();
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

        private void MenuDiamondText()
        {
            diamondText.text = GameManager.Instance.TotalDiamond.ToString();
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