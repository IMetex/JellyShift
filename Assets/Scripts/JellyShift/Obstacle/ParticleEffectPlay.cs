using UnityEngine;

namespace JellyShift.Obstacle
{
    public class ParticleEffectPlay : MonoBehaviour
    {
        [Header("ParticleEffect Reference")]
        [SerializeField] private ParticleSystem effect;
        
        private const string PlayerTag = "Player";
        

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                effect.Play();
            }
        }
    }
}