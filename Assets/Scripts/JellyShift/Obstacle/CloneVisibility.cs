using UnityEngine;

namespace JellyShift.Obstacle
{
    public class CloneVisibility : MonoBehaviour
    {
        [Header("GameObject Reference")]
        [SerializeField] private GameObject playerClone;
        private const string PlayerTag = "Player";

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                playerClone.SetActive(true);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                playerClone.SetActive(false);
            }
        }
    }
}