using System;
using JellyShift.Manager;
using UnityEngine;

namespace JellyShift.Movement
{
    public class ForwardMovement : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float speedIncreaseRate;
        [SerializeField] private float maxForwardSpeed;

        public bool isObstacle = false;


        public float Speed
        {
            get => forwardSpeed;
            set => forwardSpeed = value;
        }

        private void Update()
        {
            if (!GameManager.Instance.IsGameStarted)
                return;

            if (CanMove())
            {
                forwardSpeed += speedIncreaseRate * Time.deltaTime;
                forwardSpeed = Mathf.Clamp(forwardSpeed, 0f, maxForwardSpeed);
                transform.position += -transform.forward * (forwardSpeed * Time.deltaTime);
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
    }
}