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
                playerClone.transform.localScale = new Vector3(playerScale.x,playerScale.y,0.2f);
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
                playerClone.transform.localScale = new Vector3(1f,1f,0.2f);
            }
        }
    }
}