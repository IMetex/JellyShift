using System;
using JellyShift.Movement;
using UnityEngine;

namespace JellyShift
{
    public class DeactivateObject : MonoBehaviour
    {
        private const string DeactivateObstacle = "Deactivate";

        private ForwardMovement _movement;

        private void Awake()
        {
            _movement = GetComponent<ForwardMovement>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag(DeactivateObstacle))
            { 
                gameObject.SetActive(false);
                _movement.Speed += 0.5f;
            }
        }
    }
}