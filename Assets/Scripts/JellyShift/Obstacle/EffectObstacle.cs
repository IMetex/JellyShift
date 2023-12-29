using System;
using DG.Tweening;
using JellyShift.Managers;
using UnityEngine;

namespace JellyShift.Obstacle
{
    public class EffectObstacle : MonoBehaviour
    {
        [SerializeField] private GameObject effect;

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                effect.SetActive(true);
                TweenAnimation(effect);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                StartCoroutine(GameManager.Instance.SetObstacleSpeed(-7f,0.2f));
            }
        }

        private void TweenAnimation(GameObject obj)
        {
            var scale = Vector3.one;
            Vector3 doScale = new Vector3(1.08f, 1, 1);

            DOTween.Sequence()
                .Append(obj.transform.DOScale(doScale, 0.2f))
                .Join(obj.transform.DOMoveY(0.4f, 0.2f))
                .Append(obj.transform.DOMoveY(0f, 0.2f))
                .OnComplete(() =>
                {
                    obj.transform.DOScale(scale, 0.2f);
                    effect.SetActive(false);
                });
        }
    }
}