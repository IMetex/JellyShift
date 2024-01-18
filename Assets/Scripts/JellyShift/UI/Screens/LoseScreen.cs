using System.Collections;
using DG.Tweening;
using JellyShift.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JellyShift.UI.Screens
{
    public class LoseScreen : MonoBehaviour
    {
        [Header("Button Reference")] [SerializeField]
        private Button _restartBtn;

        [Header("Transform Reference")] [SerializeField]
        private Transform _containerTransform;

        [Header("UI Text References")] [SerializeField]
        private TMP_Text _scoreText;

        [SerializeField] private TMP_Text _diamondText;

        [Header("CanvasGroup Reference")] [SerializeField]
        private CanvasGroup _canvasGroup;

        [Header("Behavior Reference")] [SerializeField]
        private DiamondReward _diamondReward;

        private const float DiamondCountDuration = 1f;

        private void OnEnable()
        {
            StartCoroutine(Delay());
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(0.01f);
            _restartBtn.onClick.AddListener(OnRestartButtonClicked);
            PlayLoseScreenAnimation();
            UpdateLoseValuesText();
        }


        private void OnDisable()
        {
            _restartBtn.onClick.RemoveListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            GameManager.Instance.RestartLevel();
        }

        private void PlayLoseScreenAnimation()
        {
            _canvasGroup.DOFade(1, 0.2f).From(0);
            _containerTransform.DOLocalMoveY(0, 0.8f)
                .From(-300).SetEase(Ease.OutBack)
                .OnComplete(PlayDiamondIncreaseUIIfAvailable);
        }

        private void PlayDiamondIncreaseUIIfAvailable()
        {
            if (GameManager.Instance.CollectDiamondCount <= 0) return;
            StartCoroutine(PlayDiamondIncreaseUI());
            _diamondReward.CountDiamond();
        }

        private void UpdateLoseValuesText()
        {
            _scoreText.text = "Score: " + GameManager.Instance.Score;
            _diamondText.text = GameManager.Instance.TotalDiamondScore.ToString();
        }


        private IEnumerator PlayDiamondIncreaseUI()
        {
            yield return new WaitForSeconds(1f);
            var startValue = GameManager.Instance.TotalDiamondScore;
            var endValue = startValue + GameManager.Instance.CollectDiamondCount;

            DOTween.To(
                () => startValue,
                x => UpdateTotalDiamondScore(x),
                endValue,
                DiamondCountDuration);
        }

        private void UpdateTotalDiamondScore(int newScore)
        {
            GameManager.Instance.TotalDiamondScore = newScore;
            _diamondText.text = newScore.ToString();
        }
    }
}