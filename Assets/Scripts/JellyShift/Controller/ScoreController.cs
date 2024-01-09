using System;
using JellyShift.Manager;
using JellyShift.ObjectPool;
using UnityEngine;
using UnityEngine.Serialization;


namespace JellyShift.Controller
{
    public class ScoreController : MonoBehaviour
    {
        private const string ScoreTag = "Score";
        private const string DiamondTag = "Diamond";
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ScoreTag))
            {
                GameManager.Instance.Score++;
            }

            if (other.gameObject.CompareTag(DiamondTag))
            {
                GameManager.Instance.DiamondScore++;
            }
        }
    }
}