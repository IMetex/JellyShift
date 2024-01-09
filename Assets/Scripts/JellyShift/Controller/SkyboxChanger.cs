using System;
using System.Collections;
using JellyShift.Manager;
using UnityEngine;

namespace JellyShift.Controller
{
    public class SkyboxChanger : MonoBehaviour
    {
        [SerializeField] private Material[] skyboxMaterials;
        [SerializeField] private float delay = 5f;
        private bool _isSkyChanged = false;

        [Header("Particle Effect")] [SerializeField]
        private ParticleSystem airEffect;

        private int _index = 0;

        private void OnEnable()
        {
            StartCoroutine(nameof(Delay));
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(0.01f);
            GameManager.Instance.GameStarted += OnGameStarted;
            GameManager.Instance.GameEnded += OnGameEnded;
        }

        private void OnDisable()
        {
            GameManager.Instance.GameStarted -= OnGameStarted;
            GameManager.Instance.GameEnded -= OnGameEnded;
        }

        private void OnGameEnded()
        {
            _isSkyChanged = true;
            airEffect.Stop();
            StartCoroutine(nameof(ChangeSkybox));
        }

        private void OnGameStarted()
        {
            StartCoroutine(nameof(ChangeSkybox));
            airEffect.Play();
        }

        private IEnumerator ChangeSkybox()
        {
            while (!_isSkyChanged)
            {
                yield return new WaitForSeconds(delay);
                _index = (_index + 1) % skyboxMaterials.Length;
                RenderSettings.skybox = skyboxMaterials[_index];
            }
        }
    }
}