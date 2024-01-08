using System;
using System.Collections;
using DG.Tweening;
using JellyShift.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace JellyShift.UI.Customize
{
    public class UnlockObject : MonoBehaviour
    {
        [Header("Unlocked Indicator")]
        [SerializeField] private GameObject unlockIndicator;
        
        [Header("UI Text References")] 
        [SerializeField] private TMP_Text unlockCostText;
        [SerializeField] private TMP_Text totalDiamondsText;

        [Header("Unlock Parameters")]
        [SerializeField] private int unlockCost;

        [Header("Button References")] 
        [SerializeField] private Button unlockButton;
        [SerializeField] private Button intractableStatusBtn;

        private string colorIntractableButtonKey;
        private string gameObjectKey;

        private void Start()
        {
            colorIntractableButtonKey = "ColorButtonIntractable_" + gameObject.name;
            gameObjectKey = "GameObjectActiveState_" + gameObject.name;
            
            unlockCostText.text = unlockCost.ToString();
            unlockIndicator.SetActive(false);

            int colorButtonIntractable = PlayerPrefs.GetInt(colorIntractableButtonKey, 0);
            intractableStatusBtn.interactable = colorButtonIntractable == 1;

            int gameObjectActiveState = PlayerPrefs.GetInt(gameObjectKey, 1);
            gameObject.SetActive(gameObjectActiveState == 1);
        }
        
        private void OnEnable()
        {
            unlockButton.onClick.AddListener(HandleUnlockButtonClick);
        }

        private void OnDisable()
        {
            unlockButton.onClick.RemoveListener(HandleUnlockButtonClick);
        }

        private void HandleUnlockButtonClick()
        {
            if (GameManager.Instance.TotalDiamondScore > unlockCost)
            {
                var startValue = GameManager.Instance.TotalDiamondScore;
                var endValue = GameManager.Instance.TotalDiamondScore - unlockCost;

                DOTween.To(() => startValue,
                    x =>
                    {
                        GameManager.Instance.TotalDiamondScore = x;
                        totalDiamondsText.text = x.ToString();
                    },
                    endValue, 1f);

                UnlockObjectForChange();
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(DisplayNotUnlockText());
            }
        }

        private void UnlockObjectForChange()
        {
            intractableStatusBtn.interactable = true;
            PlayerPrefs.SetInt(colorIntractableButtonKey, 1);
            PlayerPrefs.SetInt(gameObjectKey, 0);
            PlayerPrefs.Save();
        }

        private IEnumerator DisplayNotUnlockText()
        {
            unlockIndicator.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            unlockIndicator.SetActive(false);
        }
    }
}