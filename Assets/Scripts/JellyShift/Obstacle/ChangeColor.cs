using System;
using UnityEngine;

namespace JellyShift.Obstacle
{
    public class ChangeColor : MonoBehaviour
    {
        [Header("Materials")] [SerializeField] private Material correctMat;

        private new Renderer renderer;
        private const string ColorTriggerTag = "ColorTrigger";
        [SerializeField] private CloneVisibility _cloneVisibility;

        private void Start()
        {
            renderer = GetComponentInChildren<Renderer>();
        }

        private void OnTriggerEnter(Collider other)
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
                _cloneVisibility.ReduceAlpha();
            }
        }
    }
}