using UnityEngine;

namespace UtilScripts
{
    public class SingleMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        [Header("SingleMono")]
        [SerializeField] private bool canBeDestroy;

        public static T Instance
        {
            get
            {
                if (_instance || (_instance = FindAnyObjectByType<T>())) return _instance;
                return _instance = new GameObject(nameof(T)).AddComponent<T>();
            }
        }

        protected virtual void Awake()
        {
            if (!canBeDestroy && _instance)
            {
                _instance.transform.position = transform.position;
                Destroy(gameObject);
                return;
            }
            _instance = this as T;
            if (!canBeDestroy) DontDestroyOnLoad(gameObject);
        }
    }
}
