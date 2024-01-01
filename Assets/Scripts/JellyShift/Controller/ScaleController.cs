using UnityEngine;

namespace JellyShift.Controller
{
    public class ScaleController : MonoBehaviour
    {
        [Header("X Values")]
        public float minX;
        public float maxX;
        [Header("Y Values")]
        public float minY;
        public float maxY;
        
        public void ChangeScale(float deltaY)
        {
            float scaleMultiplier = 0.002f;

            float newYScale = transform.localScale.y + deltaY * scaleMultiplier;
            float newXScale = transform.localScale.x - deltaY * scaleMultiplier;

            newYScale = Mathf.Clamp(newYScale, minY, maxY);
            newXScale = Mathf.Clamp(newXScale, minX, maxX);

            transform.localScale = new Vector3(newXScale, newYScale, transform.localScale.z);
        }
    }
}