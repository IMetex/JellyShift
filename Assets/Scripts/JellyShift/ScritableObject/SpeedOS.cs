using UnityEngine;

namespace JellyShift.ScritableObject
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "Speed", order = 0)]
    public class SpeedOS : ScriptableObject
    {
        private float _forwardSpeed;
        public float ForwardSpeed => _forwardSpeed;

        [SerializeField] private float speedIncreaseRate;
        [SerializeField] private float maxForwardSpeed;
        [SerializeField] private float startForwardSpeed;
        

        public void SetForwardSpeed()
        {
            _forwardSpeed += speedIncreaseRate * Time.deltaTime;
            _forwardSpeed = Mathf.Clamp(_forwardSpeed, 0f, maxForwardSpeed);
        }

        public void StartSpeedValue()
        {
            _forwardSpeed = startForwardSpeed;
        }
    }
}