using UnityEngine;

namespace JellyShift.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
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