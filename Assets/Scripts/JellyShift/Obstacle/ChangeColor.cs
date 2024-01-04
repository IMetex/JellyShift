using UnityEngine;

namespace JellyShift.Obstacle
{
    public class ChangeColor : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private new Renderer renderer;
        
        [Header("Materials")]
        [SerializeField] private Material correctMat;
        [SerializeField] private Material incorrectMat;
        
        private const string ColorTriggerTag = "ColorTrigger";
        
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag(ColorTriggerTag))
            {
                renderer.material = correctMat;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(ColorTriggerTag))
            {
                renderer.material = incorrectMat;
            }
        }

        public void InCorrectMat()
        {
            renderer.material = incorrectMat;
        }
    }
}