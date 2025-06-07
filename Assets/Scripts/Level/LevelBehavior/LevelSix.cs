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
            LevelBehavior c1 = level6Behavior.AddChild().SetDelay(0.5f);
            LevelBehavior c2 = c1.AddChild().SetAction(FinalAct);
            base.Init();
        }

        private void FinalAct()
        {
            level6Ground.Move(new Vector2(0, 36), 42);
        }
    }
}