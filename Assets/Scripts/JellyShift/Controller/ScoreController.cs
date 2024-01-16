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
        [SerializeField] private ParticleSystem _scoreEffect;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ScoreTag))
            {
                GameManager.Instance.Score++;
                _scoreEffect.Play();
            }

            if (other.gameObject.CompareTag(DiamondTag))
            {
                GameManager.Instance.DiamondScore++;
            }
        }
    }
}