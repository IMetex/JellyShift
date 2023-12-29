using JellyShift.PlayerPrefs;
using UnityEngine;
using UnityEngine.UI;

namespace JellyShift.UI
{
    public class SettingsCanvas : MonoBehaviour
    {
        
        [SerializeField] private GameObject settingPanel;
        
        [Header("Button")]
        [SerializeField] private Button backButton;
        [SerializeField] private Button hapticButton;
        [SerializeField] private Button soundButton;

        [Header("Haptic")]
        [SerializeField] private GameObject onHapticImage;
        [SerializeField] private GameObject offHapticImage;

        [Header("Sound")] 
        [SerializeField] private GameObject onSoundImage;
        [SerializeField] private GameObject offSoundImage;

        public void Initialize()
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
            hapticButton.onClick.AddListener(OnHapticButton);
            soundButton.onClick.AddListener(OnSoundButton);
        }

        private void Start()
        {
            UpdateHapticImages();
            UpdateSoundImages();
        }

        public void SettingPanel()
        {
            settingPanel.SetActive(true);
        }

        public void OnBackButtonClicked()
        {
            settingPanel.SetActive(false);
        }

        public void OnHapticButton()
        {
            PlayerPrefsManager.IsHapticOn = !PlayerPrefsManager.IsHapticOn;
            UpdateHapticImages();
        }


        private void OnSoundButton()
        {
            PlayerPrefsManager.IsSoundOn = !PlayerPrefsManager.IsSoundOn;
            UpdateSoundImages();
        }


        private void UpdateHapticImages()
        {
            onHapticImage.SetActive(PlayerPrefsManager.IsHapticOn);
            offHapticImage.SetActive(!PlayerPrefsManager.IsHapticOn);
        }

        private void UpdateSoundImages()
        {
            onSoundImage.SetActive(PlayerPrefsManager.IsSoundOn);
            offSoundImage.SetActive(!PlayerPrefsManager.IsSoundOn);
        }
    }
}