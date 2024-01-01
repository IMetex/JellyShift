using UnityEngine;

namespace JellyShift.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; protected set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}