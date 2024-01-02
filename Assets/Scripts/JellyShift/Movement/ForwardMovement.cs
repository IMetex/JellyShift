using System;
using JellyShift.Manager;
using UnityEngine;

namespace JellyShift.Movement
{
    public class ForwardMovement : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed;
        
        public float Speed
        {
            get => forwardSpeed;
            set => forwardSpeed = value;
        }

        private void Update()
        {
            if (!GameManager.Instance.IsGameStarted)
                return;
            
            transform.position += -transform.forward * (forwardSpeed * Time.deltaTime);
        }
    }
}