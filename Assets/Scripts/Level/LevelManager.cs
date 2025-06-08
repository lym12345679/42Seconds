using System;
using System.Collections;
using Game.Audio;
using Game.Instance;
using Game.KeyBoard;
using Game.Plot;
using Game.Recycle;
using Game.Scene;
using Game.UI;
using MizukiTool.MiAudio;
using Unity.VisualScripting;
using UnityEngine;
using AudioUtil = Game.Audio.AudioUtil;

namespace Game.Level
{
    public class LevelManager : GeneralMonoInstance<LevelManager>
    {
        [HideInInspector] public float CurrentTime = 0f; // 关卡时间
        private float levelMaxTime = 42f; // 关卡最大时间，单位为秒
        private bool isGamePlaying = true; // 游戏是否正在进行
        private bool isGameLose = false;
        private bool isGameWin = false;
        public SceneType CurrentSceneType = SceneType.Level1; // 当前场景类型
        public SceneType NextLevel = SceneType.Level2; // 下一个关卡场景类型
        public MainPlotEnum FailedCG;
        public MainPlotEnum WinCG;
        public MainPlotEnum BeginCG;
        private Transform playerTransform;

        private void Start()
        {
            LevelUI.Open("");
            GamePlayManager.PlayBGM(BGMAudioEnum.BGM_1);
            if (BeginCG != MainPlotEnum.None && !StaticData.PlotData[BeginCG])
            {
                StaticData.PlotData[BeginCG] = true; // 设置开始剧情已播放
                isGamePlaying = false; // 设置游戏为非进行中状态
                PlotDict.Instance.TryGetPlot(BeginCG, out TextAsset t);
                TextShowUI.Open(new TextShowUIMessage(t, () =>
                    isGamePlaying = true
                ));
            }
        }

        private void Update()
        {
            Pause();
        }

        void FixedUpdate()
        {
            GamePlay();
        }

        //检测ESC键是否按下，如果按下则暂停游戏
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

//游戏运行时，时间会不断增加，直到超过最大时间
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

// 当关卡胜利时调用此方法
        public virtual void OnlevelWin()
        {
            if (isGameLose)
            {
                return;
            }

            if (CurrentSceneType == SceneType.Level6)
            {
                GamePlayManager.PlaySe(SEAudioEnum.FinalWin);
            }
            else
            {
                GamePlayManager.PlaySe(SEAudioEnum.Win); // 播放胜利音效
            }

            isGameWin = true; // 设置游戏为胜利状态
            PlotDict.Instance.TryGetPlot(WinCG, out TextAsset textAsset);
            TextShowUI.Open(new TextShowUIMessage(textAsset, () => { GamePlayManager.LoadScene(NextLevel); }));
        }

// 当关卡失败时调用此方法
        public virtual void OnlevelFailed()
        {
            if (isGameWin)
            {
                return;
            }

            AudioUtil.Play(SEAudioEnum.Lose, AMGEnum.SE, AudioPlayMod.Normal);
            isGameLose = true; // 设置游戏为失败状态
            PlotDict.Instance.TryGetPlot(FailedCG, out TextAsset textAsset);
            TextShowUI.Open(new TextShowUIMessage(textAsset, () => { StartCoroutine(PauseDelay()); }));
        }

        #region 玩家相关

        public void OnPlayerDead()
        {
            OnlevelFailed();
        }

        // 玩家死亡时调用此方法：延迟打开失败界面
        private IEnumerator PauseDelay()
        {
            yield return new WaitForSeconds(1f); // 等待1秒
            FailedUI.Open("");
        }

        // 注册玩家的Transform
        public void RigisterPlayer(Transform player)
        {
            if (player == null)
            {
                Debug.LogError("Player transform is null!");
                return;
            }

            playerTransform = player; // 注册玩家的Transform
        }

        // 获取玩家的Transform
        public Transform GetPlayerTransform()
        {
            if (ReferenceEquals(playerTransform, null))
            {
                return null;
            }

            return playerTransform; // 返回玩家的Transform
        }

        #endregion

        public bool GetGamePlayingState()
        {
            return isGamePlaying; // 返回游戏是否正在进行的状态
        }

        public bool IsGameWin()
        {
            return isGameWin;
        }
    }
}