using UnityEngine;
using JellyShift.Controller;
using JellyShift.Manager;

namespace JellyShift.Input
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private ScaleController _scaleController;

        private Vector3 _startDragPosition;
        private float _firstTouchY;
        private bool _isDragging;

        void Update()
        {
            if (!GameManager.Instance.IsGameStarted)
                return;

            HandleInput();
        }


        private void HandleInput()
        {
            if (UnityEngine.Input.touchCount > 0)
            {
                HandleTouchInput();
            }
            else
            {
                HandleMouseInput();
            }
        }

        private void HandleTouchInput()
        {
            Touch touch = UnityEngine.Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartDrag(touch.position);
                    break;

                case TouchPhase.Moved:
                    if (_isDragging)
                    {
                        UpdateScale(touch.position.y - _firstTouchY);
                        _firstTouchY = touch.position.y;
                    }

                    break;

                case TouchPhase.Ended:
                    EndDrag();
                    break;
            }
        }

        private void HandleMouseInput()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                StartDrag(UnityEngine.Input.mousePosition);
            }
            else if (UnityEngine.Input.GetMouseButton(0))
            {
                UpdateScale(UnityEngine.Input.mousePosition.y - _startDragPosition.y);
                _startDragPosition = UnityEngine.Input.mousePosition;
            }
            else if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                EndDrag();
            }
        }

        private void StartDrag(Vector3 dragPosition)
        {
            _startDragPosition = dragPosition;
            _isDragging = true;
        }

        private void UpdateScale(float deltaPositionY)
        {
            _scaleController.ChangeScale(deltaPositionY);
        }

        private void EndDrag()
        {
            _isDragging = false;
        }
    }
}