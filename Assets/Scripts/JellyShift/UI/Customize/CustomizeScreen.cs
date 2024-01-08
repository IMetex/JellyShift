using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace JellyShift.UI.Customize
{
    public class CustomizeScreen : MonoBehaviour
    {
        [Header("Buttons References")] [SerializeField]
        private Button customizeBtn;

        [SerializeField] private Button returnMenuBtn;
        [SerializeField] private Button playBtn;

        [Header("UI Text References")] [SerializeField]
        private GameObject playText;

        [SerializeField] private GameObject playAnimationText;

        [Header("Customize References")] [SerializeField]
        private GameObject customizePanel;

        [Header("CanvasGroup References")] [SerializeField]
        private CanvasGroup canvasGroup;

        private float _duration = 0.1f;

        private void Start()
        {
            SetMenuState();
            customizeBtn.onClick.AddListener(UIChangeState);
            returnMenuBtn.onClick.AddListener(SetMenuState);
        }

        private void OnDestroy()
        {
            customizeBtn.onClick.RemoveListener(UIChangeState);
            returnMenuBtn.onClick.RemoveListener(SetMenuState);
        }

        private void SetMenuState()
        {
            SetButtonsActiveState(playBtn: true, customizeBtn: true, returnMenuBtn: false);
            SetTextActiveState(playText: true, playAnimationText: true);
            CanvasGroupChanged(0, false);
        }

        private void UIChangeState()
        {
            SetButtonsActiveState(playBtn: false, customizeBtn: false, returnMenuBtn: true);
            SetTextActiveState(playText: false, playAnimationText: false);
            CanvasGroupChanged(1, true);
            CustomizePanelAnimation();
        }

        private void SetButtonsActiveState(bool playBtn, bool customizeBtn, bool returnMenuBtn)
        {
            this.playBtn.gameObject.SetActive(playBtn);
            this.customizeBtn.gameObject.SetActive(customizeBtn);
            this.returnMenuBtn.gameObject.SetActive(returnMenuBtn);
        }

        private void SetTextActiveState(bool playText, bool playAnimationText)
        {
            this.playText.SetActive(playText);
            this.playAnimationText.SetActive(playAnimationText);
        }

        private void CustomizePanelAnimation()
        {
            customizePanel.transform.DOLocalMoveY(0, 0.7f)
                .From(-300)
                .SetEase(Ease.OutBack);
        }

        private void CanvasGroupChanged(float endValue, bool state)
        {
            canvasGroup.DOFade(endValue, _duration);
            canvasGroup.interactable = state;
        }
    }
}