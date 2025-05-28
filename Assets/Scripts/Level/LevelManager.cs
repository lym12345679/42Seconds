using Game.Instance;
using UnityEngine;
namespace Game.Level
{

    public class LevelManager : GeneralInstance<LevelManager>
    {
        public float currentTime = 0f; // 关卡时间
        private float levelMaxTime = 42f; // 关卡最大时间，单位为秒
        private bool isGamePlaying = false; // 游戏是否正在进行
        void FixedUpdate()
        {
            GamePlay();
        }

        private void GamePlay()
        {
            if (isGamePlaying)
            {
                return; // 如果游戏已经在进行中，则不执行任何操作
            }
            // 更新当前时间
            currentTime += Time.deltaTime;
            // 检查是否超过最大时间
            if (currentTime >= levelMaxTime)
            {
                OnlevelWin(); // 调用关卡胜利方法
            }

        }
        private void Init()
        {
            currentTime = 0f; // 初始化当前时间
        }
        public void OnlevelWin()
        {
            Debug.Log("关卡胜利！"); // 这里可以添加关卡胜利的逻辑
        }
    }
}
