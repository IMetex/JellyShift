using System;
using UnityEngine;

namespace JellyShift.Collectables
{
    public class Diamond : MonoBehaviour
    {
        private const string PlayerTag = "Player";
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                
            }
        }
    }
}