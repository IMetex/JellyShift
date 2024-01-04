using UnityEngine;
using JellyShift.Controller;
using JellyShift.Manager;

namespace JellyShift.Input
{
    public class InputManager : MonoBehaviour
    {
        private ScaleController _scaleController;
        private Vector3 _startDragPosition;
        private float _firstTouchY;
        private bool _isDragging;

        private void Awake()
        {
            _scaleController = GetComponent<ScaleController>();
        }

        void Update()
        {
            if(!GameManager.Instance.IsGameStarted)
                return;
            
            if (UnityEngine.Input.touchCount > 0)
            {
                TouchInput();
            }
            else if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                StartDrag(UnityEngine.Input.mousePosition);
            }
            else if (UnityEngine.Input.GetMouseButton(0))
            {
                Vector3 deltaPosition = UnityEngine.Input.mousePosition - _startDragPosition;
                _scaleController.ChangeScale(deltaPosition.y);
                _startDragPosition = UnityEngine.Input.mousePosition;
            }
            else if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                EndDrag();
            }
        }

        private void TouchInput()
        {
            Touch touch = UnityEngine.Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _firstTouchY = touch.position.y;
                    _isDragging = true;
                    break;

                case TouchPhase.Moved:
                    if (_isDragging)
                    {
                        float deltaPositionY = touch.position.y - _firstTouchY;
                        _scaleController.ChangeScale(deltaPositionY);
                        _firstTouchY = touch.position.y;
                    }

                    break;

                case TouchPhase.Ended:
                    _isDragging = false;
                    break;
            }
        }

        private void StartDrag(Vector3 dragPosition)
        {
            _startDragPosition = dragPosition;
            _isDragging = true;
        }

        private void EndDrag()
        {
            _isDragging = false;
        }
    }
}