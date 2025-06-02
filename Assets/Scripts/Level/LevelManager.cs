using System;
using System.Collections;
using Game.Instance;
using Game.KeyBoard;
using Game.Plot;
using Game.Scene;
using Game.UI;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Level
{
    public class LevelManager : GeneralMonoInstance<LevelManager>
    {
        [HideInInspector] public float CurrentTime = 0f; // 关卡时间
        private float levelMaxTime = 42f; // 关卡最大时间，单位为秒
        private bool isGamePlaying = true; // 游戏是否正在进行
        private bool isGameLose = false;
        public SceneType CurrentSceneType = SceneType.Level1; // 当前场景类型
        public SceneType NextLevel = SceneType.Level2; // 下一个关卡场景类型
        public MainPlotEnum FailedCG;
        public MainPlotEnum WinCG;

        private void Start()
        {
            LevelUI.Open("");
        }

        private void Update()
        {
            Pause();
        }

        void FixedUpdate()
        {
            GamePlay();
        }

        private void Pause()
        {
            if (KeyboardSet.IsKeyDown(KeyEnum.ESC))
            {
                if (PauseUI.Instance)
                {
                    if (PauseUI.Instance.IsOpen)
                    {
                        isGamePlaying = true; // 设置游戏为非进行中状态
                        PauseUI.Instance.Close(); // 如果暂停界面已经打开，则关闭它
                    }
                    else
                    {
                        isGamePlaying = false; // 设置游戏为进行中状态
                        PauseUI.Instance.PauseGame(); // 如果暂停界面没有打开，则打开它
                    }
                }
                else
                {
                    isGamePlaying = false;
                    PauseUI.Open("");
                }
            }
        }


        private void GamePlay()
        {
            if (!isGamePlaying)
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

        public virtual void OnlevelWin()
        {
            if (isGameLose)
            {
                return;
            }

            PlotDict.Instance.TryGetPlot(WinCG, out TextAsset textAsset);
            TextShowUI.Open(new TextShowUIMessage(textAsset, () => { GamePlayManager.LoadScene(NextLevel); }));
        }

        public virtual void OnlevelFailed()
        {
            PlotDict.Instance.TryGetPlot(FailedCG, out TextAsset textAsset);
            TextShowUI.Open(new TextShowUIMessage(textAsset, () => { StartCoroutine(PauseDelay()); }));
        }

        #region 玩家相关

        public void OnPlayerDead()
        {
            OnlevelFailed();
            isGameLose = true; // 设置游戏为失败状态
            Debug.Log("玩家死亡，游戏暂停！"); // 这里可以添加玩家死亡的逻辑
        }

        private IEnumerator PauseDelay()
        {
            yield return new WaitForSeconds(1f); // 等待1秒
            FailedUI.Open("");
        }

        #endregion
    }
}