using System;
using JellyShift.Remaining;
using UnityEngine;
using UnityEngine.UI;

namespace JellyShift.UI.Display
{
    public class RemainingBar : MonoBehaviour
    {
        [SerializeField] private RemainingChances remaining;
        [SerializeField] private Image currentLivesBar;

        private void Update()
        {
            currentLivesBar.fillAmount = remaining.CurrentLives / 3;
        }
    }
}