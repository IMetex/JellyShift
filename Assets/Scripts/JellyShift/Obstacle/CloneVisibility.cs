using System;
using UnityEngine;

namespace JellyShift.Obstacle
{
    public class CloneVisibility : MonoBehaviour
    {
        [Header("GameObject Reference")]
        [SerializeField] private GameObject playerClone;
        private const string PlayerTag = "Player";

        [SerializeField] private ChangeColor changeColor;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                playerClone.SetActive(true);
                
                Vector3 playerScale = other.transform.localScale;
                playerClone.transform.localScale = playerScale;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                Vector3 playerScale = other.transform.localScale;
                playerClone.transform.localScale = playerScale;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                playerClone.SetActive(false);
                changeColor.InCorrectMat();
                playerClone.transform.localScale = Vector3.one;
            }
        }
    }
}