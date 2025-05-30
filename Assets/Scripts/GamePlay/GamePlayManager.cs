using System.Collections;
using System.Collections.Generic;
using Game.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public static class GamePlayManager
    {
        public static void LoadSceneAsync(SceneType sceneName)
        {
            // 异步加载场景逻辑
            SceneManager.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Single);
        }

        public static void LoadScene(SceneType sceneName)
        {
            // 同步加载场景逻辑
            SceneManager.LoadScene(sceneName.ToString(), LoadSceneMode.Single);
        }

        public static void LoadSceneAdditive(SceneType sceneName)
        {
            // 异步加载场景逻辑
            SceneManager.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Additive);
        }

        public static void UnloadScene(SceneType sceneName)
        {
            // 卸载场景逻辑
            SceneManager.UnloadSceneAsync(sceneName.ToString());
        }

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

        public static void ExitGame()
        {
            // 退出游戏逻辑
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // 在编辑器中停止播放
#else
            Application.Quit(); // 在构建的应用程序中退出
#endif
        }
    }
}