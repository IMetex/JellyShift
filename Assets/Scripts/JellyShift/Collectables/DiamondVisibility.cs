using UnityEngine;

namespace JellyShift.Collectables
{
    public class DiamondVisibility : MonoBehaviour
    {
        private const string DeactivateObstacle = "Deactivate";
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag(DeactivateObstacle))
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform child = transform.GetChild(i);
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
}