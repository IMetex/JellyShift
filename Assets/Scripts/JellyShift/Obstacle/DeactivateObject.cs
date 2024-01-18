using UnityEngine;

namespace JellyShift
{
    public class DeactivateObject : MonoBehaviour
    {
        private const string DeactivateObstacle = "Deactivate";
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag(DeactivateObstacle))
            { 
                gameObject.SetActive(false);
            }
        }
    }
}