using System;
using System.Collections;
using JellyShift.Manager;
using JellyShift.ScriptableObject;
using UnityEngine;
using UnityEngine.Serialization;

namespace JellyShift.Movement
{
    public class ForwardMovement : MonoBehaviour
    {
        [SerializeField] private SpeedSO _speedSO;
        public bool isObstacle = false;

        private void Update()
        {
            if (!GameManager.Instance || !GameManager.Instance.IsGameStarted)
                return;

            if (CanMove())
            {
                _speedSO.SetForwardSpeed();
                transform.position += -transform.forward * (_speedSO.ForwardSpeed * Time.deltaTime);
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
            if (GameManager.Instance)
                GameManager.Instance.GameEnded += OnGameEnded;
        }

        private void OnDisable()
        {
            if (GameManager.Instance)
                GameManager.Instance.GameEnded -= OnGameEnded;
        }

        private void OnGameEnded()
        {
            if (_speedSO)
                _speedSO.StartSpeedValue();
        }
    }
}