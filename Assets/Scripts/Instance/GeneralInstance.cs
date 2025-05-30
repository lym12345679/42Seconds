using UnityEngine;

namespace Game.Instance
{
    public class GeneralInstance<T> where T : class
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = System.Activator.CreateInstance<T>(); // 创建单例实例
                }

                return _instance;
            }
            private set
            {
                _instance = value; // 设置单例实例
            }
        } // 单例实例
    }

    public class GeneralMonoInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; } // 单例实例

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T; // 设置单例实例
                transform.SetParent(null);
            }
            else
            {
                Destroy(gameObject); // 如果已经存在实例，则销毁当前对象
            }
        }
    }
}