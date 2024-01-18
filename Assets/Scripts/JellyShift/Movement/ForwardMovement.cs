using System;
using System.Collections;
using JellyShift.Manager;
using JellyShift.ScritableObject;
using UnityEngine;

namespace JellyShift.Movement
{
    public class ForwardMovement : MonoBehaviour
    {
        [SerializeField] private SpeedOS _speedOS;
        public bool isObstacle = false;

        private void Update()
        {
            if (!GameManager.Instance || !GameManager.Instance.IsGameStarted)
                return;

            if (CanMove())
            {
                _speedOS.SetForwardSpeed();
                transform.position += -transform.forward * (_speedOS.ForwardSpeed * Time.deltaTime);
            }
        }

        private bool CanMove()
        {
            RaycastHit hit;
            float raycastDistance = isObstacle ? 20f : 5f;
            Debug.DrawRay(transform.position, -transform.forward * raycastDistance, Color.red);

            if (Physics.Raycast(transform.position, -transform.forward, out hit, raycastDistance))
            {
                return !hit.collider.CompareTag("Obj");
            }

            return true;
        }

        private void OnEnable()
        {
            StartCoroutine(nameof(Delay));
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(0.01f);
            GameManager.Instance.GameEnded += OnGameEnded;
        }

        private void OnDisable()
        {
            GameManager.Instance.GameEnded -= OnGameEnded;
        }

        private void OnGameEnded()
        {
            if (_speedOS)
                _speedOS.StartSpeedValue();
        }
    }
}