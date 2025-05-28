using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Instance
{
    public class GeneralInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; } // 单例实例

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T; // 设置单例实例
                transform.SetParent(null);
                DontDestroyOnLoad(gameObject); // 保持在场景切换时不销毁
            }
            else
            {
                Destroy(gameObject); // 如果已经存在实例，则销毁当前对象
            }
        }
    }


}
