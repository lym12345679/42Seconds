using System;
using System.Collections.Generic;
using Game.Recycle;
using Game.Traps;
using MizukiTool.UIEffect;
using UnityEngine;

namespace Game.Level
{
    public class LevelFive : LevelFour
    {
        private LevelBehavior level5Behavior = new LevelBehavior();

        #region 行动

        private void Awake()
        {
            Init();
        }

        private void FixedUpdate()
        {
            FixedUpdateAction();
        }

        protected override void FixedUpdateAction()
        {
            level5Behavior.OnFixedUpdate();
            base.FixedUpdateAction();
        }

        #endregion

        protected override void Init()
        {
            LevelBehavior c1 = Level5_Stage1(level5Behavior);
            base.Init();
        }

        #region Stage

        private LevelBehavior Level5_Stage1(LevelBehavior l)
        {
            LevelBehavior d0 = l.AddChild().SetDelay(33f);
            LevelBehavior a0 = d0.AddChild().SetAction(Level5_Stage1_0);
            return a0;
        }

        #endregion

        #region operation

        protected void CreateGuidedMissile(Vector2 pos)
        {
            RecyclePool.Request(RecycleItemEnum.GuidedMissile,
                (r) => { r.GameObject.transform.position = new Vector3(pos.x, pos.y, 0) + Location.position; });
        }

        #endregion

        #region Stage1

        private void Level5_Stage1_0()
        {
            CreateGuidedMissile(new Vector2(0, 14)); // 示例位置
        }

        #endregion
    }
}