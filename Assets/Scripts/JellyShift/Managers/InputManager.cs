using System.Collections.Generic;
using JellyShift.Controllers;
using JellyShift.Enum;
using JellyShift.Singleton;
using UnityEngine;
using UnityEngine.EventSystems;

namespace JellyShift.Managers
{
    public class InputManager : Singleton<InputManager>
    {
        public bool isInputEnabled { get; private set; } = true;
        private PlayerController _playerController;
        private float _firstTouchY;
        private bool _isDragging;

        public void Initialize(PlayerController playerController)
        {
            _playerController = playerController;
            _isDragging = false;
        }

        public void OnScreenTouch(PointerEventData eventData)
        {
            if (!isInputEnabled)
            {
                return;
            }

            _firstTouchY = Input.mousePosition.y;
            _isDragging = true;
        }

        public void OnScreenDrag(PointerEventData eventData)
        {
            if (!isInputEnabled || !_isDragging)
            {
                return;
            }

            if (GameManager.Instance.GameState != GameState.Playing)
            {
                return;
            }

            float _lastTouchY = Input.mousePosition.y;
            float deltaY = _firstTouchY - _lastTouchY;

            _firstTouchY = _lastTouchY;

            _playerController.ChangeScale(deltaY);
        }

        public void OnScreenUp(PointerEventData eventData)
        {
            _isDragging = false;
        }
    }
}