using DG.Tweening;
using UnityEngine;

namespace JellyShift.Animation
{
    public class PlayAnimation : MonoBehaviour
    {
        [Header("BackGround Ref")] [SerializeField]
        private RectTransform playBackGround;

        [Header("Hand Ref")] [SerializeField] private Transform playHand;

        [SerializeField] private float handEndValue;
        
        [Header("BackGround Size Value")] [SerializeField]
        private Vector2 endSize;

        [Header("Duration")] [SerializeField] private float loopDuration;

        void Start()
        {
            PlayAnimationLoop();
        }

        private void PlayAnimationLoop()
        {
            Sequence loopSequence = DOTween.Sequence();

            loopSequence
                .Append(playBackGround.DOSizeDelta(endSize, loopDuration)
                    .SetEase(Ease.Linear))
                .Join(playHand.DOLocalMoveY(handEndValue, loopDuration)
                    .SetEase(Ease.Linear))
                .SetLoops(-1, LoopType.Yoyo)
                .AppendInterval(0.1f);

            loopSequence.Play();
        }
    }
}