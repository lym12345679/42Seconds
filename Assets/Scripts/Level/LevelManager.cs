using Game.Instance;
using UnityEngine;

namespace Game.Level
{
    public class LevelManager : GeneralInstance<LevelManager>
    {
        [HideInInspector] public float CurrentTime = 0f; // 关卡时间
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
            CurrentTime += Time.deltaTime;
            // 检查是否超过最大时间
            if (CurrentTime >= levelMaxTime && isGamePlaying)
            {
                isGamePlaying = false; // 设置游戏为进行中
                OnlevelWin(); // 调用关卡胜利方法
            }
        }

        public void Init()
        {
            CurrentTime = 0f; // 初始化当前时间
            isGamePlaying = true; // 设置游戏为进行中状态
        }

        public void OnlevelWin()
        {
            Debug.Log("关卡胜利！"); // 这里可以添加关卡胜利的逻辑
        }

        #region 玩家相关

        public void OnPlayerDead()
        {
            isGamePlaying = false; // 设置游戏为非进行中状态
            GamePlayManager.PauseGame();
            Debug.Log("玩家死亡，游戏暂停！"); // 这里可以添加玩家死亡的逻辑
        }

        #endregion
    }
}