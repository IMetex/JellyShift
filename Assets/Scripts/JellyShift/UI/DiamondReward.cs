using DG.Tweening;
using UnityEngine;

namespace JellyShift.UI
{
    public class DiamondReward : MonoBehaviour
    {
        [SerializeField] private GameObject pileOfDiamond;

        [SerializeField] private Vector2[] initialPos;
        [SerializeField] private Quaternion[] initialRotation;
        [SerializeField] private int diamondAmount;
        
        private void Start()
        {
            if (diamondAmount == 0) 
                diamondAmount = 10;
            
            initialPos = new Vector2[diamondAmount];
            initialRotation = new Quaternion[diamondAmount];

            for (int i = 0; i < diamondAmount; i++)
            {
                if (i < pileOfDiamond.transform.childCount)
                {
                    initialPos[i] = pileOfDiamond.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition;
                    initialRotation[i] = pileOfDiamond.transform.GetChild(i).GetComponent<RectTransform>().rotation;
                }
            }
        }
        
        public void CountDiamond()
        {
            pileOfDiamond.SetActive(true);
            var delay = 0f;

            for (int i = 0; i < pileOfDiamond.transform.childCount; i++)
            {
                RectTransform childRectTransform = pileOfDiamond.transform.GetChild(i).GetComponent<RectTransform>();
                
                Vector2 initialPosition = initialPos[i];
                Quaternion initialRot = initialRotation[i];
                
                childRectTransform.anchoredPosition = initialPosition;
                childRectTransform.rotation = initialRot;
                
                pileOfDiamond.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

                childRectTransform.DOAnchorPos(new Vector2(465f, 840f), 0.8f)
                    .SetDelay(delay + 0.5f).SetEase(Ease.InBack);

                pileOfDiamond.transform.GetChild(i).DORotate(Vector3.zero, 0.5f).SetDelay(delay + 0.5f)
                    .SetEase(Ease.Flash);

                pileOfDiamond.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 1.5f).SetEase(Ease.OutBack);

                delay += 0.1f;
            }
        }   
    }
}