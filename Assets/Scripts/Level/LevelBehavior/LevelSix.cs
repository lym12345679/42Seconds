using System;
using System.Collections.Generic;
using Game.Recycle;
using Game.Traps;
using MizukiTool.UIEffect;
using UnityEngine;

namespace Game.Level
{
    public class LevelSix : LevelFive
    {
        private LevelBehavior level6Behavior = new LevelBehavior();
        public Ground level6Ground;

        #region 行动

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
        }

        private void FixedUpdate()
        {
            if (LevelManager.Instance.GetGamePlayingState())
            {
                FixedUpdateAction(); // 更新关卡行为树
            }
        }

        protected override void FixedUpdateAction()
        {
            level6Behavior.OnFixedUpdate();
            base.FixedUpdateAction();
        }

        #endregion

        protected override void Init()
        {
            LevelBehavior c1 = level6Behavior.AddChild().SetDelay(0f);
            LevelBehavior c2 = c1.AddChild().SetAction(FinalAct);
            /*LevelBehavior c3 = c2.AddChild().SetDelay(42.1f);
            LevelBehavior c4 = c3.AddChild().SetCondition(() => { return LevelManager.Instance.IsGameWin(); });
            LevelBehavior c5 = c4.AddChild().SetAction(WinAct);*/
            base.Init();
        }

        private void FinalAct()
        {
            level6Ground.Move(new Vector2(0, 41.5f + 25f), 42);
        }

        private void WinAct()
        {
            level6Ground.Scale(new Vector2(2, 2), 0.5f);
        }
    }
}