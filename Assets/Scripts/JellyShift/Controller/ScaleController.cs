using UnityEngine;

namespace JellyShift.Controller
{
    public class ScaleController : MonoBehaviour
    {
        private const float ScaleMultiplier = 0.005f;

        [Header("X Values")]
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;

        [Header("Y Values")]
        [SerializeField] private float _minY;
        [SerializeField] private float _maxY;
        
        public void ChangeScale(float deltaY)
        {
            
            Vector3 localScale = transform.localScale;
            float newYScale = localScale.y + deltaY * ScaleMultiplier;
            float newXScale = localScale.x - deltaY * ScaleMultiplier;

            newYScale = Mathf.Clamp(newYScale, _minY, _maxY);
            newXScale = Mathf.Clamp(newXScale, _minX, _maxX);

            transform.localScale = new Vector3(newXScale, newYScale, localScale.z);
        }
    }
}