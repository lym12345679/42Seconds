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
        public List<Transform> Masks = new List<Transform>();
        private List<Spike> level5SpikeList = new List<Spike>();

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
            LevelBehavior c2 = Level5_Stage2(c1);
            LevelBehavior c3 = Level5_Stage3(c2);
            base.Init();
        }

        #region Stage

        private LevelBehavior Level5_Stage1(LevelBehavior l)
        {
            LevelBehavior s0 = l.AddChild().SetDelay(2f);
            LevelBehavior s1 = s0.AddChild().SetAction(Level5_Stage0_0);
            LevelBehavior d0 = s1.AddChild().SetDelay(7f);
            LevelBehavior a0 = d0.AddChild().SetAction(Level5_Stage1_0);
            LevelBehavior d1 = a0.AddChild().SetDelay(9f);
            LevelBehavior a1 = d1.AddChild().SetAction(Level5_Stage1_1);
            return a1;
        }

        private LevelBehavior Level5_Stage2(LevelBehavior l)
        {
            //18s
            LevelBehavior d0 = l.AddChild().SetDelay(2f);
            LevelBehavior a0 = d0.AddChild().SetAction(Level5_Stage2_0).AddChild().SetAction(Level5_Stage2_6_0);
            LevelBehavior d1 = a0.AddChild().SetDelay(0.5f);
            LevelBehavior a1 = d1.AddChild().SetAction(Level5_Stage2_1).AddChild().SetAction(Level5_Stage2_6_1);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Level5_Stage2_2).AddChild().SetAction(Level5_Stage2_6_2);
            LevelBehavior d2_0 = a2.AddChild().SetDelay(0.5f);
            LevelBehavior a2_0 = d2_0.AddChild().SetAction(Level5_Stage2_6_3).AddChild().SetAction(Level5_Stage2_6_3);
            ;
            LevelBehavior d3 = a2_0.AddChild().SetDelay(0.5f);
            LevelBehavior a3 = d3.AddChild().SetAction(Level5_Stage2_3).AddChild().SetAction(Level5_Stage2_6_4);
            LevelBehavior d3_0 = a3.AddChild().SetDelay(0.5f);
            LevelBehavior a3_0 = d3_0.AddChild().SetAction(Level5_Stage2_6_5).AddChild().SetAction(Level5_Stage2_6_5);
            LevelBehavior d4 = a3_0.AddChild().SetDelay(0.5f);
            LevelBehavior a4 = d4.SetAction(Level5_Stage2_6_6);
            LevelBehavior d4_0 = a4.AddChild().SetDelay(1f);
            LevelBehavior a4_0 = d4_0.AddChild().SetAction(Level5_Stage2_4);
            LevelBehavior d5 = a4_0.AddChild().SetDelay(0.5f);
            LevelBehavior a5 = d5.AddChild().SetAction(Level5_Stage2_5);
            LevelBehavior d6 = a5.AddChild().SetDelay(1f);
            LevelBehavior a6 = d6.AddChild().SetAction(Level5_Stage2_6);
            //24.5
            LevelBehavior d7 = a6.AddChild().SetDelay(1.5f);
            LevelBehavior a7 = d7.AddChild().SetAction(Level5_Stage2_7);
            return a7;
        }

        private LevelBehavior Level5_Stage3(LevelBehavior l)
        {
            //27s
            LevelBehavior d0 = l.AddChild().SetDelay(2f);
            LevelBehavior a0 = d0.AddChild().SetAction(Level5_Stage3_0);
            LevelBehavior d1 = a0.AddChild().SetDelay(1f);
            LevelBehavior a1 = d1.AddChild().SetAction(Level5_Stage3_1);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Level5_Stage3_2);
            LevelBehavior d3 = a2.AddChild().SetDelay(0.5f);
            LevelBehavior a3 = d3.AddChild().SetAction(Level5_Stage3_3);
            LevelBehavior d4 = a3.AddChild().SetDelay(0.5f);
            LevelBehavior a4 = d4.AddChild().SetAction(Level5_Stage3_4);
            LevelBehavior d5 = a4.AddChild().SetDelay(0.5f);
            LevelBehavior a5 = d5.AddChild().SetAction(Level5_Stage3_5);
            LevelBehavior d6 = a5.AddChild().SetDelay(0.5f);
            LevelBehavior a6 = d6.AddChild().SetAction(Level5_Stage3_6);
            LevelBehavior d7 = a6.AddChild().SetDelay(0.5f);
            LevelBehavior a7 = d7.AddChild().SetAction(Level5_Stage3_7);
            //33s

            return d2;
        }

        #endregion

        #region operation

        protected void CreateGuidedMissile(Vector2 pos)
        {
            RecyclePool.Request(RecycleItemEnum.GuidedMissile,
                (r) => { r.GameObject.transform.position = new Vector3(pos.x, pos.y, 0) + Location.position; });
        }

        protected void CreateMultipleWeakWall(RecycleItemEnum e, Vector2 pos)
        {
            RecyclePool.Request(e,
                (r) => { r.GameObject.transform.position = new Vector3(pos.x, pos.y, 0) + Location.position; });
        }

        protected void Level5SpikeMove(int n, Vector2 v, float timeToMove = 0.5f,
            PositionEffectMode positionEffectMode = PositionEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<PositionEffect> endHandler = null)
        {
            if (level5SpikeList.Count > n)
            {
                level5SpikeList[n].Move(v, timeToMove, positionEffectMode, persentageHanderEnum,
                    endHandler);
            }
        }

        protected void Level5CreateSpike(Vector2 pos)
        {
            Spike spike = null;
            RecyclePool.Request(RecycleItemEnum.Spike0, (r) => { spike = r.GetMainComponent<Spike>(); });
            spike.transform.position = (Vector3)pos + Location.position;
            level5SpikeList.Add(spike);
        }

        protected void Level5RemoveSpike(int n)
        {
            GameObject g = level5SpikeList[n].gameObject;
            level5SpikeList.RemoveAt(n);
            RecyclePool.ReturnToPool(g);
        }

        #endregion

        #region Stage0

        private void Level5_Stage0_0()
        {
            Spikes[6].gameObject.SetActive(false);
            Spikes[7].gameObject.SetActive(false);
            Spikes[8].gameObject.SetActive(false);
        }

        #endregion

        #region Stage1

        private void Level5_Stage1_0()
        {
            CreateGuidedMissile(new Vector2(0, 14)); // 示例位置
            Spikes[0].gameObject.SetActive(false);
            Spikes[1].gameObject.SetActive(false);
            Spikes[2].gameObject.SetActive(false);
        }

        private void Level5_Stage1_1()
        {
            GroundMove(6, new Vector2(0, -3), 0.5f);
            GroundMove(7, new Vector2(0, -3), 0.5f);
            GroundMove(8, new Vector2(0, -3), 0.5f);
            Spikes[3].gameObject.SetActive(false);
            Spikes[4].gameObject.SetActive(false);
            Spikes[5].gameObject.SetActive(false);
        }

        #endregion

        #region Stage2

        private void Level5_Stage2_0()
        {
            CreateGeneratingLaser(new Vector2(12, 24));
            CreateGeneratingLaser(new Vector2(16, 24));
            CreateGeneratingLaser(new Vector2(14, 24));
            CreateGeneratingLaser1(new Vector2(-1, 9.2f));
            CreateGeneratingLaser1(new Vector2(-1, 16));
            CreateGeneratingLaser1(new Vector2(-1, 19));
            CreateGeneratingLaser1(new Vector2(-1, 22));
        }

        private void Level5_Stage2_1()
        {
            GeneralWarn(new Vector2(11, 22));
            GeneralWarn(new Vector2(12, 22));
            GeneralWarn(new Vector2(13, 22));
            GeneralWarn(new Vector2(15, 22));
            GeneralWarn(new Vector2(16, 22));
            GeneralWarn(new Vector2(17, 22));
            GeneratingLaserMove(2, new Vector2(0, -1));
            GeneratingLaserMove(3, new Vector2(0, -1));
        }

        private void Level5_Stage2_2()
        {
            generatingLaserList[2].Shot(ShotDirectionEnum.down);
            generatingLaserList[3].Shot(ShotDirectionEnum.down);
        }

        private void Level5_Stage2_3()
        {
            GeneratingLaserMove(2, new Vector2(0, 1));
            GeneratingLaserMove(3, new Vector2(0, 1));
            GeneratingLaserMove(4, new Vector2(0, -1));
            GeneratingLaserMove(5, new Vector2(1, 0));
            CreateMultipleWeakWall(RecycleItemEnum.WeakWall1, new Vector2(14, 9.2f));
            CreateMultipleWeakWall(RecycleItemEnum.WeakWall2, new Vector2(14, 9.2f));
            CreateMultipleWeakWall(RecycleItemEnum.WeakWall3, new Vector2(14, 9.2f));
            CreateGuidedMissile(new Vector2(25, 16));
        }

        private void Level5_Stage2_4()
        {
            GeneralWarn(new Vector2(13, 22));
            GeneralWarn(new Vector2(14, 22));
            GeneralWarn(new Vector2(15, 22));
            GeneralWarn(new Vector2(1, 8.2f));
            GeneralWarn(new Vector2(1, 9.2f));
            GeneralWarn(new Vector2(1, 10.2f));
        }

        private void Level5_Stage2_5()
        {
            generatingLaserList[4].Shot(ShotDirectionEnum.down);
            generatingLaserList[5].Shot(ShotDirectionEnum.right);
        }

        private void Level5_Stage2_6()
        {
            GeneratingLaserMove(4, new Vector2(0, 1));
            GeneratingLaserMove(5, new Vector2(-1, 0));
        }

        private void Level5_Stage2_6_0()
        {
            GeneralWarn(new Vector2(1, 15));
            GeneralWarn(new Vector2(1, 16));
            GeneralWarn(new Vector2(1, 17));
            GeneratingLaserMove(6, new Vector2(1, 0));
        }

        private void Level5_Stage2_6_1()
        {
            generatingLaserList[6].Shot(ShotDirectionEnum.right);
        }

        private void Level5_Stage2_6_2()
        {
            GeneralWarn(new Vector2(1, 18));
            GeneralWarn(new Vector2(1, 19));
            GeneralWarn(new Vector2(1, 20));
            GeneratingLaserMove(7, new Vector2(1, 0));
        }

        private void Level5_Stage2_6_3()
        {
            generatingLaserList[7].Shot(ShotDirectionEnum.right);
            GeneratingLaserMove(6, new Vector2(-1, 0));
        }

        private void Level5_Stage2_6_4()
        {
            GeneralWarn(new Vector2(1, 21));
            GeneralWarn(new Vector2(1, 22));
            GeneralWarn(new Vector2(1, 23));
            GeneratingLaserMove(8, new Vector2(1, 0));
        }

        private void Level5_Stage2_6_5()
        {
            generatingLaserList[8].Shot(ShotDirectionEnum.right);
            GeneratingLaserMove(7, new Vector2(-1, 0));
        }

        private void Level5_Stage2_6_6()
        {
            GeneratingLaserMove(8, new Vector2(-1, 0));
        }

        private void Level5_Stage2_7()
        {
            CreateGuidedMissile(new Vector2(5, 4));
        }

        #endregion

        #region Stage3

        private void Level5_Stage3_0()
        {
            GroundMove(9, new Vector2(0, -3), 0.5f);
            GroundMove(10, new Vector2(0, -3), 0.5f);
            GroundMove(11, new Vector2(0, -3), 0.5f);
            Spikes[9].gameObject.SetActive(false);
            Spikes[10].gameObject.SetActive(false);
            Spikes[11].gameObject.SetActive(false);
        }

        private void Level5_Stage3_1()
        {
            Level5CreateSpike(new Vector2(13, 8));
            Level5CreateSpike(new Vector2(14, 8));
            Level5CreateSpike(new Vector2(15, 8));
            Level5CreateSpike(new Vector2(19, 8));
            Level5CreateSpike(new Vector2(20, 8));
            Level5CreateSpike(new Vector2(21, 8));
            GeneralWarn(new Vector2(13, 9));
        }

        private void Level5_Stage3_2()
        {
            Level5SpikeMove(0, new Vector2(0, 1));
            GeneralWarn(new Vector2(13, 9));
        }

        private void Level5_Stage3_3()
        {
            Level5SpikeMove(1, new Vector2(0, 1));
            GeneralWarn(new Vector2(14, 9));
        }

        private void Level5_Stage3_4()
        {
            Level5SpikeMove(2, new Vector2(0, 1));
            GeneralWarn(new Vector2(15, 9));
        }

        private void Level5_Stage3_5()
        {
            Level5SpikeMove(3, new Vector2(0, 1));
            GeneralWarn(new Vector2(19, 9));
        }

        private void Level5_Stage3_6()
        {
            Level5SpikeMove(4, new Vector2(0, 1));
            GeneralWarn(new Vector2(20, 9));
        }

        private void Level5_Stage3_7()
        {
            Level5SpikeMove(5, new Vector2(0, 1));
            GeneralWarn(new Vector2(21, 9));
        }

        #endregion

        #region Level2Fixer

        protected override void Second6p5Action()
        {
            SpikeMove(5, 0.5f, 0, 1);
            SpikeMove(9, 0.5f, 0, 1);
            SpikeMove(3, 0.5f, 0, -1);
            SpikeMove(11, 0.5f, 0, -1);
        }

        protected override void Second7Action()
        {
            SpikeMove(6, 0.5f, 0, 1);
            SpikeMove(8, 0.5f, 0, 1);
            SpikeMove(4, 0.5f, 0, -1);
            SpikeMove(10, 0.5f, 0, -1);
        }

        protected override void Second10p5Action()
        {
        }

        protected override void Second11p5Action()
        {
            SpikeWarn(13, 0, 1);
            SpikeWarn(14, 0, 1);
            SpikeMove(10, 0.5f, 0, 1);
            SpikeMove(11, 0.5f, 0, 1);
            SpikeMove(3, 0.5f, 0, 1);
            SpikeMove(4, 0.5f, 0, 1);
        }

        protected override void Second14Action()
        {
            SpikeWarn(3, 0, 1);
            SpikeWarn(4, 0, 1);
            SpikeWarn(5, 0, 1);
            SpikeWarn(9, 0, 1);
            SpikeWarn(10, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeWarn(12, 0, 1);
        }

        protected override void Second20Action()
        {
            SpikeFlash1(0, 0);
            SpikeFlash1(1, 1);
            SpikeFlash1(2, 2);
            SpikeFlash1(3, 3);
            SpikeFlash1(4, 4);
            SpikeFlash1(5, 5);
            SpikeFlash1(6, 6);
            SpikeFlash1(7, 7);
            SpikeFlash1(8, 8);
            SpikeFlash1(9, 9);
            SpikeFlash1(10, 10);
            SpikeFlash1(11, 11);
            SpikeFlash1(12, 12);
            SpikeFlash1(13, 13);
            SpikeFlash1(14, 14);
            SpikeWarn(14, 0, 1);
        }

        protected override void Second20p5Action()
        {
            SpikeWarn(13, 0, 1);
            SpikeMove(0, 0.5f, 0, 1);
            SpikeMove(14, 0.5f, 0, 1);
        }

        protected override void Second21Action()
        {
            SpikeWarn(12, 0, 1);
            SpikeMove(1, 0.5f, 0, 1);
            SpikeMove(13, 0.5f, 0, 1);
        }

        protected override void Second21p5Action()
        {
            SpikeWarn(11, 0, 1);
            SpikeMove(2, 0.5f, 0, 1);
            SpikeMove(12, 0.5f, 0, 1);
        }

        protected override void Second22Action()
        {
            SpikeWarn(10, 0, 1);
            SpikeMove(3, 0.5f, 0, 1);
            SpikeMove(11, 0.5f, 0, 1);
            SpikeMove(14, 0.5f, 0, -1);
            SpikeMove(0, 0.5f, 0, -1);
        }

        protected override void Second22p5Action()
        {
            SpikeWarn(9, 0, 1);
            SpikeMove(4, 0.5f, 0, 1);
            SpikeMove(10, 0.5f, 0, 1);
            SpikeMove(13, 0.5f, 0, -1);
            SpikeMove(1, 0.5f, 0, -1);
        }

        protected override void Second23Action()
        {
            SpikeMove(5, 0.5f, 0, 1);
            SpikeMove(9, 0.5f, 0, 1);
            SpikeMove(12, 0.5f, 0, -1);
            SpikeMove(2, 0.5f, 0, -1);
        }

        protected override void Second23p5Action()
        {
            SpikeMove(6, 0.5f, 0, 1);
            SpikeMove(8, 0.5f, 0, 1);
            SpikeMove(11, 0.5f, 0, -1);
            SpikeMove(3, 0.5f, 0, -1);
        }

        protected override void Second24Action()
        {
            SpikeWarn(14, 0, 1);
            SpikeMove(7, 0.5f, 0, 1);
            SpikeMove(10, 0.5f, 0, -1);
            SpikeMove(4, 0.5f, 0, -1);
        }

        protected override void Second24p25Action()
        {
            SpikeWarn(13, 0, 1);
        }

        protected override void Second24p5Action()
        {
            SpikeWarn(12, 0, 1);
            SpikeMove(0, .5f, 0, 1);
            SpikeMove(14, .5f, 0, 1);
            SpikeMove(9, 0.5f, 0, -1);
            SpikeMove(5, 0.5f, 0, -1);
        }

        protected override void Second24p75Action()
        {
            SpikeWarn(11, 0, 1);
            SpikeMove(1, .5f, 0, 1);
            SpikeMove(13, .5f, 0, 1);
        }

        protected override void Second25Action()
        {
            SpikeWarn(10, 0, 1);
            SpikeMove(2, .5f, 0, 1);
            SpikeMove(12, .5f, 0, 1);
            SpikeMove(8, 0.5f, 0, -1);
            SpikeMove(6, 0.5f, 0, -1);
            SpikeMove(14, 0.5f, 0, -1);
        }

        protected override void Second25p25Action()
        {
            SpikeWarn(9, 0, 1);
            SpikeMove(3, .5f, 0, 1);
            SpikeMove(11, .5f, 0, 1);
        }

        protected override void Second25p5Action()
        {
            SpikeMove(4, .5f, 0, 1);
            SpikeMove(10, .5f, 0, 1);
            SpikeMove(7, 0.5f, 0, -1);
        }

        protected override void Second25p75Action()
        {
            SpikeMove(5, .5f, 0, 1);
            SpikeMove(9, .5f, 0, 1);
        }

        protected override void Second29Action()
        {
        }

        protected override void Second31Action()
        {
        }

        protected override void Second32Action()
        {
        }

        protected override void Second33Action()
        {
            SpikeWarn(12, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeWarn(14, 0, 1);
        }

        protected override void Second34Action()
        {
        }

        protected override void Second35Action()
        {
        }

        protected override void Second36Action()
        {
            SpikeWarn(12, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeWarn(14, 0, 1);
        }

        protected override void Second39p5Action()
        {
            SpikeWarn(12, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeWarn(14, 0, 1);
            SpikeFlash2(7, 0, -4);
            Spikes[7].gameObject.SetActive(true);
            SpikeScale(7, 0.5f, 2, 2);
        }

        #endregion
    }
}