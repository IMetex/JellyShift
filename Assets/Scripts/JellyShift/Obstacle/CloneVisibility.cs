using UnityEngine;

namespace JellyShift.Obstacle
{
    public class CloneVisibility : MonoBehaviour
    {
        [Header("GameObject Reference")] [SerializeField]
        private GameObject playerClone;

        [SerializeField] private Renderer cloneRenderer;

        [SerializeField] [Range(0, 1)] private float reducedAlpha = 0.5f;

        private const string PlayerTag = "Player";
        private Renderer playerRenderer;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag(PlayerTag)) return;

            playerClone.SetActive(true);
            playerRenderer = other.gameObject.GetComponentInChildren<Renderer>();

            if (playerRenderer && cloneRenderer)
            {
                ReduceAlpha();
            }

            SyncScales(other.transform.localScale);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                SyncScales(other.transform.localScale);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                ResetPlayerClone();
                ReduceAlpha();
            }
        }

        private void SyncScales(Vector3 playerScale)
        {
            playerClone.transform.localScale = playerScale;
        }

        private void ResetPlayerClone()
        {
            playerClone.SetActive(false);
            playerClone.transform.localScale = Vector3.one;
        }

        private void ReduceAlpha()
        {
            cloneRenderer.material = playerRenderer.material;
            if (cloneRenderer)
            {
                Color color = cloneRenderer.material.color;
                color.a = reducedAlpha;
                cloneRenderer.material.color = color;
            }
        }
    }
}