using System;
using DG.Tweening;
using JellyShift.Enum;
using JellyShift.Managers;
using UnityEngine;

namespace JellyShift.Obstacle
{
    public class DeactivateObstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Deactive"))
            {
                gameObject.SetActive(false);
                Debug.Log("1111");
            }
        }

        private void Update()
        {
            if (GameManager.Instance.GameState == GameState.Reset)
            {
                gameObject.SetActive(false);
            }
        }
    }
}