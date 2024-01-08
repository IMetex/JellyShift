using System;
using UnityEngine;

namespace JellyShift.Obstacle
{
    public class ChangeColor : MonoBehaviour
    {
        [Header("Materials")] [SerializeField] private Material correctMat;

        private new Renderer renderer;
        private const string ColorTriggerTag = "ColorTrigger";

        private void Start()
        {
            renderer = GetComponentInChildren<Renderer>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag(ColorTriggerTag))
            {
                renderer.material = correctMat;
            }
        }
    }
}