using System;
using JellyShift.Manager;
using UnityEngine;

namespace JellyShift.Controller
{
    public class LoseController : MonoBehaviour
    {
        private const string ObstacleTag = "Obstacle";
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ObstacleTag))
            {
                GameManager.Instance.EndGame();
            }
        }
    }
}
