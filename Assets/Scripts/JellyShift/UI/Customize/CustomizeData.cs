using System.Collections;
using TMPro;
using UnityEngine;

namespace JellyShift.UI.Customize
{
    [CreateAssetMenu(fileName = "Color", menuName = "Customize", order = 0)]
    public class CustomizeData : ScriptableObject
    {
        [Header("Unlocked Indicator")]
        [SerializeField] private GameObject unlockIndicator;
        
        
        [SerializeField] private int _unlockCost;




        
        
        public IEnumerator DisplayNotUnlockText()
        {
            unlockIndicator.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            unlockIndicator.SetActive(false);
        }
    }
}