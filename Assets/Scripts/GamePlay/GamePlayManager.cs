using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{

    public static class GamePlayManager
    {
        public static void PauseGame()
        {
            // 暂停游戏逻辑
            Time.timeScale = 0f; // 将时间缩放设置为0，暂停游戏
        }
        public static void ResumeGame()
        {
            // 恢复游戏逻辑
            Time.timeScale = 1f; // 将时间缩放设置为1，恢复游戏
        }
    }

}