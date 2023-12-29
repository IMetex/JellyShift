using JellyShift.Controllers;
using JellyShift.Singleton;
using JellyShift.UI;
using UnityEngine;

namespace JellyShift.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private InputCanvas inputCanvas;
        [SerializeField] private GameCanvas gameCanvas;
        [SerializeField] private SettingsCanvas settingsCanvas;
        [SerializeField] private EndCanvas endCanvas;
        
        public void Initialize(InputManager inputManager,PlayerController playerController)
		{
            inputCanvas.Initialize(inputManager);
            gameCanvas.Initialize(settingsCanvas,playerController);
            settingsCanvas.Initialize();
            endCanvas.Initialize();
        }
    }
}

