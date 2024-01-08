using System;
using UnityEngine;
using UnityEngine.UI;

namespace JellyShift.UI.Customize
{
    public class PlayerChangeColor : MonoBehaviour
    {
        [SerializeField] private Button colorBtn;
        [SerializeField] private Renderer playerRenderer;
        [SerializeField] private Material colorMat;

        private string colorButtonKey;
        private static string lastButtonPressed;
        private const string ColorChangePrefString = "ColorChange";
        private const string LastButtonKey = "LastButton";

        private void Start()
        {
            colorButtonKey = ColorChangePrefString + gameObject.name;
            ApplySavedColorChange();
        }

        private void OnEnable()
        {
            colorBtn.onClick.AddListener(OnColorButtonClicked);
        }

        private void OnDisable()
        {
            colorBtn.onClick.RemoveListener(OnColorButtonClicked);
        }

        private void OnColorButtonClicked()
        {
            ApplyColorChange();
            SaveColorPreference();
        }

        private void ApplyColorChange()
        {
            playerRenderer.material = colorMat;
        }

        private void SaveColorPreference()
        {
            PlayerPrefs.SetString(LastButtonKey, gameObject.name);
            PlayerPrefs.SetInt(colorButtonKey, 1);
            PlayerPrefs.Save();
        }

        private void ApplySavedColorChange()
        {
            lastButtonPressed = PlayerPrefs.GetString(LastButtonKey, "");
            int colorChangeValue = PlayerPrefs.GetInt(colorButtonKey, 0);
            
            if (colorChangeValue == 1 && lastButtonPressed == gameObject.name)
            {
                ApplyColorChange();
            }
        }
    }
}