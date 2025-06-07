using System;
using System.Collections.Generic;
using Game.Recycle;
using Game.Traps;
using MizukiTool.UIEffect;
using UnityEngine;

namespace Game.Level
{
    public class LevelThree : LevelTwo
    {
        private LevelBehavior level3Behavior = new LevelBehavior();
        public List<Ground> groundList = new List<Ground>();
        public List<GeneratingLaser> generatingLaserList = new List<GeneratingLaser>();
        private List<Spike> level3SpikeList = new List<Spike>();
        private readonly float spikeMaxMoveLength = 40f; // 尖刺最大移动距离

        #region 行动

        private void Awake()
        {
            Init();
        }

        private void FixedUpdate()
        {
            if (LevelManager.Instance.GetGamePlayingState())
            {
                level3Behavior.OnFixedUpdate(); // 更新关卡行为树
            }
        }

        protected override void FixedUpdateAction()
        {
            base.FixedUpdateAction();
            level3Behavior.OnFixedUpdate();
        }

        #endregion

        #region Stages

        protected override void Init()
        {
            LevelBehavior c0 = Level3Stage0(level3Behavior);
            LevelBehavior c1 = Level3Stage1(c0);
            LevelBehavior c2 = Level3Stage3(c1);
            LevelBehavior c3 = Level3Stage4(c2);
            LevelBehavior c4 = Level3Stage5(c3);
            base.Init();
        }

        private LevelBehavior Level3Stage0(LevelBehavior l)
        {
            LevelBehavior d0 = l.AddChild().SetDelay(2f);
            LevelBehavior a00 = d0.AddChild().SetAction(Level3_Stage1_0_0);
            LevelBehavior d00 = a00.AddChild().SetDelay(1f);
            LevelBehavior a0 = d00.AddChild().SetAction(Level3_Stage1_0);
            LevelBehavior d1 = a0.AddChild().SetDelay(0.5f);
            LevelBehavior a1 = d1.AddChild().SetAction(Level3_Stage1_1);
            LevelBehavior d2 = a1.AddChild().SetDelay(2.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Level3_Stage1_2);
            LevelBehavior d3 = a2.AddChild().SetDelay(0.5f);
            LevelBehavior a3 = d3.AddChild().SetAction(Level3_Stage1_3);
            //6s
            LevelBehavior d4 = a3.AddChild().SetDelay(3f);
            //9s
            return d4;
        }

        private LevelBehavior Level3Stage1(LevelBehavior l)
        {
            //9s
            LevelBehavior d0 = l.AddChild().SetDelay(0f);
            LevelBehavior a0 = d0.AddChild().SetAction(Level3_Stage2_0);
            LevelBehavior d1 = a0.AddChild().SetDelay(2f);
            LevelBehavior a1 = d1.AddChild().SetAction(Level3_Stage2_1);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Level3_Stage2_2);
            LevelBehavior d3 = a2.AddChild().SetDelay(2.5f);
            //14s
            return d3;
        }

        private LevelBehavior Level3Stage3(LevelBehavior l)
        {
            //14s
            LevelBehavior d0 = l.AddChild().SetDelay(0f);
            //平台旋转
            LevelBehavior a0 = d0.AddChild().SetAction(Level3_Stage3_0);
            LevelBehavior d00 = a0.AddChild().SetDelay(0.5f);
            LevelBehavior a00 = d00.AddChild().SetAction(LevelLevel3_Stage3_0_0);
            LevelBehavior d01 = a00.AddChild().SetDelay(0.5f);
            LevelBehavior a01 = d01.AddChild().SetAction(LevelLevel3_Stage3_0_1);
            LevelBehavior d02 = a01.AddChild().SetDelay(0.5f);
            LevelBehavior a02 = d02.AddChild().SetAction(LevelLevel3_Stage3_0_2);
            //15s
            LevelBehavior d1 = a02.AddChild().SetDelay(2.5f);
            LevelBehavior a1 = d1.AddChild().SetAction(Level3_Stage3_1);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Level3_Stage3_2);
            LevelBehavior d3 = a2.AddChild().SetDelay(0.5f);
            LevelBehavior a3 = d3.AddChild().SetAction(Level3_Stage3_3);
            LevelBehavior d4 = a3.AddChild().SetDelay(1f);
            LevelBehavior a4 = d4.AddChild().SetAction(Level3_Stage3_4);
            LevelBehavior d5 = a4.AddChild().SetDelay(0f);
            //20s
            return d5;
        }

        private LevelBehavior Level3Stage4(LevelBehavior l)
        {
            //20s
            LevelBehavior d0 = l.AddChild().SetDelay(1f);
            LevelBehavior a0 = d0.AddChild().SetAction(Level3_Stage4_0);
            LevelBehavior d1 = a0.AddChild().SetDelay(0.5f);
            LevelBehavior a1 = d1.AddChild().SetAction(Level3_Stage4_1);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Level3_Stage4_2);
            LevelBehavior d3 = a2.AddChild().SetDelay(0.5f);
            LevelBehavior a3 = d3.AddChild().SetAction(Level3_Stage4_3);
            LevelBehavior d4 = a3.AddChild().SetDelay(1f);
            LevelBehavior a4 = d4.AddChild().SetAction(Level3_Stage4_4);
            LevelBehavior d5 = a4.AddChild().SetDelay(0.5f);
            LevelBehavior a5 = d5.AddChild().SetAction(Level3_Stage4_5);
            LevelBehavior d6 = a5.AddChild().SetDelay(0.5f);
            LevelBehavior a6 = d6.AddChild().SetAction(Level3_Stage4_6);
            LevelBehavior d7 = a6.AddChild().SetDelay(0.5f);
            LevelBehavior a7 = d7.AddChild().SetAction(Level3_Stage4_7);
            LevelBehavior d8 = a7.AddChild().SetDelay(3.5f);
            LevelBehavior a8 = d8.AddChild().SetAction(Level3_Stage4_8);
            //29s
            return d8;
        }

        private LevelBehavior Level3Stage5(LevelBehavior l)
        {
            //29s
            LevelBehavior d0 = l.AddChild().SetDelay(1f);
            LevelBehavior a0 = d0.AddChild().SetAction(Level3_Stage5_0);
            LevelBehavior d1 = a0.AddChild().SetDelay(0.5f);
            LevelBehavior a1 = d1.AddChild().SetAction(Level3_Stage5_1);
            LevelBehavior d1_0 = a1.AddChild().SetDelay(3f);
            LevelBehavior a1_0 = d1_0.AddChild().SetAction(Level3_Stage5_1_0);
            LevelBehavior d1_1 = a1_0.AddChild().SetDelay(0.5f);
            LevelBehavior a1_1 = d1_1.AddChild().SetAction(Level3_Stage5_1_1);
            LevelBehavior d1_2 = a1_1.AddChild().SetDelay(0.5f);
            LevelBehavior a1_2 = d1_2.AddChild().SetAction(Level3_Stage5_1_2);
            LevelBehavior d1_3 = a1_2.AddChild().SetDelay(0.5f);
            LevelBehavior a1_3 = d1_3.AddChild().SetAction(Level3_Stage5_1_3);
            //35s

            LevelBehavior d2 = a1_3.AddChild().SetDelay(2f);
            LevelBehavior a2 = d2.AddChild().SetAction(Level3_Stage5_2);
            LevelBehavior d3 = a2.AddChild().SetDelay(.5f);
            LevelBehavior a3 = d3.AddChild().SetAction(Level3_Stage5_3);
            return a3;
        }

        #endregion

        #region operation

        /// <summary>
        /// 平台移动
        /// </summary>
        /// <param name="n"></param>
        /// <param name="vector"></param>
        /// <param name="timeToMove"></param>
        /// <param name="positionEffectMode"></param>
        /// <param name="persentageHanderEnum"></param>
        /// <param name="endHandler"></param>
        protected void GroundMove(int n, Vector2 vector, float timeToMove,
            PositionEffectMode positionEffectMode = PositionEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<PositionEffect> endHandler = null)
        {
            if (n < groundList.Count)
            {
                groundList[n].Move(vector, timeToMove, positionEffectMode, persentageHanderEnum, endHandler);
            }
        }

        /// <summary>
        /// 平台以某一点为圆心进行旋转
        /// </summary>
        /// <param name="n"></param>
        /// <param name="rotation"></param>
        /// <param name="timeToRotate"></param>
        /// <param name="point"></param>
        /// <param name="rotationEffectMode"></param>
        /// <param name="persentageHanderEnum"></param>
        /// <param name="endHandler"></param>
        protected void GroundRotate(int n, float rotation, float timeToRotate, Vector2 point,
            RotationEffectMode rotationEffectMode = RotationEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X)
        {
            if (n < groundList.Count)
            {
                groundList[n].Rotate(rotation, timeToRotate, point + (Vector2)Location.position, rotationEffectMode,
                    persentageHanderEnum);
            }
        }

        /// <summary>
        /// 从对象池中获取尖刺，并使其移动到指定位置
        /// </summary>
        /// <param name="originPos"></param>
        /// <param name="v">方向</param>
        /// <param name="timeToMove"></param>
        /// <param name="positionEffectMode"></param>
        /// <param name="persentageHanderEnum"></param>
        /// <param name="endHandler"></param>
        protected void RecycleSpikeMove(Vector2 originPos, Vector2 v, float timeToMove = 5f,
            PositionEffectMode positionEffectMode = PositionEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<PositionEffect> endHandler = null)
        {
            Spike spike = null;
            if (v.x < 0)
            {
                RecyclePool.Request(RecycleItemEnum.Spike2, (r) => { spike = r.GetMainComponent<Spike>(); });
            }
            else
            {
                RecyclePool.Request(RecycleItemEnum.Spike1, (r) => { spike = r.GetMainComponent<Spike>(); });
            }

            spike.transform.position = (Vector3)originPos + Location.position;
            spike.Move(v * spikeMaxMoveLength, timeToMove, positionEffectMode, persentageHanderEnum,
                endHandler);
        }

        protected void Level3SpikeMove(int n, Vector2 v, float timeToMove = 0.5f,
            PositionEffectMode positionEffectMode = PositionEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<PositionEffect> endHandler = null)
        {
            if (level3SpikeList.Count > n)
            {
                level3SpikeList[n].Move(v, timeToMove, positionEffectMode, persentageHanderEnum,
                    endHandler);
            }
        }

        protected void CreateSpike(Vector2 pos)
        {
            Spike spike = null;
            RecyclePool.Request(RecycleItemEnum.Spike0, (r) => { spike = r.GetMainComponent<Spike>(); });
            spike.transform.position = (Vector3)pos + Location.position;
            level3SpikeList.Add(spike);
        }

        protected void RemoveSpike(int n)
        {
            GameObject g = level3SpikeList[n].gameObject;
            level3SpikeList.RemoveAt(n);
            RecyclePool.ReturnToPool(g);
        }

        /// <summary>
        /// 在指定位置创建一个弱墙
        /// </summary>
        /// <param name="pos"></param>
        protected void CreateWeakWall(Vector2 pos)
        {
            RecyclePool.Request(RecycleItemEnum.WeakWall, (r) =>
            {
                WeakWall weakWall = r.GetMainComponent<WeakWall>();
                weakWall.transform.position = pos;
            });
        }

        /// <summary>
        /// 在指定位置创建一个生成激光器
        /// </summary>
        /// <param name="pos"></param>
        protected GeneratingLaser CreateGeneratingLaser(Vector2 pos)
        {
            GeneratingLaser l = null;
            RecyclePool.Request(RecycleItemEnum.GeneratingLaser, (r) =>
            {
                GeneratingLaser generatingLaser = r.GetMainComponent<GeneratingLaser>();
                l = generatingLaser;
                generatingLaser.transform.position = pos;
            });
            generatingLaserList.Add(l);
            return l;
        }

        /// <summary>
        /// 在指定位置创建一个生成激光器（类型1横版）
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        protected GeneratingLaser CreateGeneratingLaser1(Vector2 pos)
        {
            GeneratingLaser l = null;
            RecyclePool.Request(RecycleItemEnum.GeneratingLaser1, (r) =>
            {
                GeneratingLaser generatingLaser = r.GetMainComponent<GeneratingLaser>();
                l = generatingLaser;
                generatingLaser.transform.position = pos;
            });
            generatingLaserList.Add(l);
            return l;
        }

        /// <summary>
        /// 指定生成激光器列表中的第n个激光器移动到指定位移
        /// </summary>
        /// <param name="n"></param>
        /// <param name="v"></param>
        /// <param name="timeToMove"></param>
        /// <param name="positionEffectMode"></param>
        /// <param name="persentageHanderEnum"></param>
        /// <param name="endHandler"></param>
        protected void GeneratingLaserMove(int n, Vector2 v, float timeToMove = 0.5f,
            PositionEffectMode positionEffectMode = PositionEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<PositionEffect> endHandler = null)
        {
            if (n < groundList.Count)
            {
                generatingLaserList[n].Move(v, timeToMove, positionEffectMode, persentageHanderEnum, endHandler);
            }
        }

        /// <summary>
        /// 在指定位置生成一个警告提示
        /// </summary>
        /// <param name="pos"></param>
        protected void GeneralWarn(Vector2 pos)
        {
            RecyclePool.Request(RecycleItemEnum.Warn, r =>
            {
                r.GameObject.transform.position =
                    new Vector3(Location.position.x + pos.x, Location.position.y + pos.y, 0);
            });
        }

        #endregion

        #region Stage1

        private void Level3_Stage1_0_0()
        {
            GroundMove(3, new Vector2(9, 3), 1f);
            GroundMove(4, new Vector2(9, 3), 1f);
            GroundMove(5, new Vector2(9, 3), 1f);
        }

        private void Level3_Stage1_0()
        {
            GeneralWarn(new Vector2(10, 12));
            GeneralWarn(new Vector2(10, 13));
            GeneralWarn(new Vector2(10, 14));
            //GeneralWarn(new Vector2(10, 15));
            CreateWeakWall(new Vector2(25, 19));
        }

        private void Level3_Stage1_1()
        {
            RecycleSpikeMove(new Vector2(10, 12), new Vector2(1, 0));
            RecycleSpikeMove(new Vector2(10, 13), new Vector2(1, 0));
            RecycleSpikeMove(new Vector2(10, 14), new Vector2(1, 0));
            //RecycleSpikeMove(new Vector2(10, 15), new Vector2(1, 0));
        }

        private void Level3_Stage1_2()
        {
            GeneralWarn(new Vector2(28, 15));
            GeneralWarn(new Vector2(28, 16));
            GeneralWarn(new Vector2(28, 17));
        }

        private void Level3_Stage1_3()
        {
            RecycleSpikeMove(new Vector2(28, 15), new Vector2(-1, 0));
            RecycleSpikeMove(new Vector2(28, 16), new Vector2(-1, 0));
            RecycleSpikeMove(new Vector2(28, 17), new Vector2(-1, 0));
        }

        #endregion

        #region Stage2

        private void Level3_Stage2_0()
        {
            GroundMove(0, new Vector2(6, 6), 2f);
            GroundMove(1, new Vector2(6, 6), 2f);
            GroundMove(2, new Vector2(6, 6), 2f);
        }

        private void Level3_Stage2_1()
        {
            /*GeneralWarn(new Vector2(10, 12));
            GeneralWarn(new Vector2(10, 13));
            GeneralWarn(new Vector2(10, 14));
            GeneralWarn(new Vector2(28, 15));
            GeneralWarn(new Vector2(28, 16));
            GeneralWarn(new Vector2(28, 17));
            GeneralWarn(new Vector2(28, 19));
            GeneralWarn(new Vector2(28, 20));
            GeneralWarn(new Vector2(28, 21));*/
        }

        private void Level3_Stage2_2()
        {
            /*RecycleSpikeMove(new Vector2(10, 12), new Vector2(1, 0));
            RecycleSpikeMove(new Vector2(10, 13), new Vector2(1, 0));
            RecycleSpikeMove(new Vector2(10, 14), new Vector2(1, 0));
            RecycleSpikeMove(new Vector2(28, 15), new Vector2(-1, 0));
            RecycleSpikeMove(new Vector2(28, 16), new Vector2(-1, 0));
            RecycleSpikeMove(new Vector2(28, 17), new Vector2(-1, 0));
            RecycleSpikeMove(new Vector2(28, 19), new Vector2(-1, 0));
            RecycleSpikeMove(new Vector2(28, 20), new Vector2(-1, 0));
            RecycleSpikeMove(new Vector2(28, 21), new Vector2(-1, 0));*/
        }

        #endregion

        #region Stage3

        private void Level3_Stage3_0()
        {
            /*GroundRotate(0, -90f, 0.5f, new Vector2(17, 17));
            GroundRotate(1, -90f, 0.5f, new Vector2(17, 17));
            GroundRotate(2, -90f, 0.5f, new Vector2(17, 17));*/

            //CreateGeneratingLaser(new Vector2(26, 24));
            //CreateGeneratingLaser1(new Vector2(-1, 13));
            CreateWeakWall(new Vector2(25, 19));
        }

        private void LevelLevel3_Stage3_0_0()
        {
            //CreateSpike(new Vector2(16.8f, 18));
        }

        private void LevelLevel3_Stage3_0_1()
        {
            //GeneralWarn(new Vector2(17, 19));
        }

        private void LevelLevel3_Stage3_0_2()
        {
            //Level3SpikeMove(0, new Vector2(0, 1), 0.5f);
        }

        private void Level3_Stage3_1()
        {
            //GeneratingLaserMove(0, new Vector2(0, -1), 0.5f);
            //GeneratingLaserMove(1, new Vector2(1, 0));
        }

        private void Level3_Stage3_2()
        {
            /*GeneralWarn(new Vector2(26, 22));
            GeneralWarn(new Vector2(25, 22));
            GeneralWarn(new Vector2(27, 22));
            GeneralWarn(new Vector2(1, 12));
            GeneralWarn(new Vector2(1, 13));
            GeneralWarn(new Vector2(1, 14));*/
        }

        private void Level3_Stage3_3()
        {
            //Level3SpikeMove(0, new Vector2(0, -1));
            //generatingLaserList[0].Shot(ShotDirectionEnum.down);
            //generatingLaserList[1].Shot(ShotDirectionEnum.right);
        }

        private void Level3_Stage3_4()
        {
            //RemoveSpike(0);
            //GeneratingLaserMove(0, new Vector2(0, 1), 0.5f);
            //GeneratingLaserMove(1, new Vector2(-1, 0));
            /*GroundRotate(0, 90f, 0.5f, new Vector2(17, 17));
            GroundRotate(1, 90f, 0.5f, new Vector2(17, 17));
            GroundRotate(2, 90f, 0.5f, new Vector2(17, 17));*/
        }

        #endregion

        #region Stage4

        private void Level3_Stage4_0()
        {
            Debug.Log("Level3_Stage4_0");
            CreateSpike(new Vector2(16, 17));
            CreateSpike(new Vector2(17, 17));
            CreateSpike(new Vector2(18, 17));
            CreateSpike(new Vector2(25, 14));
            CreateSpike(new Vector2(26, 14));
            CreateSpike(new Vector2(27, 14));
            GeneralWarn(new Vector2(16, 18));
        }

        private void Level3_Stage4_1()
        {
            GeneralWarn(new Vector2(17, 18));
            Level3SpikeMove(0, new Vector2(0, 1), 0.5f);
        }

        private void Level3_Stage4_2()
        {
            GeneralWarn(new Vector2(18, 18));
            Level3SpikeMove(1, new Vector2(0, 1), 0.5f);
        }

        private void Level3_Stage4_3()
        {
            Level3SpikeMove(2, new Vector2(0, 1), 0.5f);
        }

        private void Level3_Stage4_4()
        {
            //GeneralWarn(new Vector2(25, 15));
            GeneralWarn(new Vector2(10, 12));
            GeneralWarn(new Vector2(10, 13));
            GeneralWarn(new Vector2(10, 14));
            //GeneralWarn(new Vector2(10, 15));
        }

        private void Level3_Stage4_5()
        {
            //GeneralWarn(new Vector2(26, 15));
            //Level3SpikeMove(3, new Vector2(0, 1), 0.5f);
            RecycleSpikeMove(new Vector2(10, 12), new Vector2(1, 0));
            RecycleSpikeMove(new Vector2(10, 13), new Vector2(1, 0));
            RecycleSpikeMove(new Vector2(10, 14), new Vector2(1, 0));
            //RecycleSpikeMove(new Vector2(10, 15), new Vector2(1, 0));
        }

        private void Level3_Stage4_6()
        {
            //GeneralWarn(new Vector2(27, 15));
            //Level3SpikeMove(4, new Vector2(0, 1), 0.5f);
        }

        private void Level3_Stage4_7()
        {
            //Level3SpikeMove(5, new Vector2(0, 1), 0.5f);
        }

        private void Level3_Stage4_8()
        {
            Level3SpikeMove(0, new Vector2(0, -1), 0.5f);
            Level3SpikeMove(1, new Vector2(0, -1), 0.5f);
            Level3SpikeMove(2, new Vector2(0, -1), 0.5f);
            //Level3SpikeMove(3, new Vector2(0, -1), 0.5f);
            //Level3SpikeMove(4, new Vector2(0, -1), 0.5f);
            //Level3SpikeMove(5, new Vector2(0, -1), 0.5f);
        }

        #endregion

        #region Stage5

        private void Level3_Stage5_0()
        {
            GeneralWarn(new Vector2(10, 12));
            GeneralWarn(new Vector2(10, 13));
            GeneralWarn(new Vector2(10, 14));
            GeneralWarn(new Vector2(10, 17));
            GeneralWarn(new Vector2(10, 19));
            GeneralWarn(new Vector2(10, 20));
            GeneralWarn(new Vector2(10, 21));
            //CreateWeakWall(new Vector2(18, 22));
            RemoveSpike(2);
            RemoveSpike(1);
            RemoveSpike(0);
        }

        private void Level3_Stage5_1_0()
        {
            GeneralWarn(new Vector2(27, 15));
        }

        private void Level3_Stage5_1_1()
        {
            GeneralWarn(new Vector2(26, 15));
            Level3SpikeMove(2, new Vector2(0, 1), 0.5f);
        }

        private void Level3_Stage5_1_2()
        {
            GeneralWarn(new Vector2(25, 15));
            Level3SpikeMove(1, new Vector2(0, 1), 0.5f);
        }

        private void Level3_Stage5_1_3()
        {
            Level3SpikeMove(0, new Vector2(0, 1), 0.5f);
        }

        private void Level3_Stage5_1()
        {
            RecycleSpikeMove(new Vector2(10, 12), new Vector2(1, 0));
            RecycleSpikeMove(new Vector2(10, 13), new Vector2(1, 0));
            RecycleSpikeMove(new Vector2(10, 14), new Vector2(1, 0));
            RecycleSpikeMove(new Vector2(10, 17), new Vector2(1, 0));
            RecycleSpikeMove(new Vector2(10, 19), new Vector2(1, 0));
            RecycleSpikeMove(new Vector2(10, 20), new Vector2(1, 0));
            RecycleSpikeMove(new Vector2(10, 21), new Vector2(1, 0));
        }

        private void Level3_Stage5_2()
        {
            GeneralWarn(new Vector2(28, 12));
            GeneralWarn(new Vector2(28, 13));
            GeneralWarn(new Vector2(28, 14));
            GeneralWarn(new Vector2(28, 15));
            GeneralWarn(new Vector2(28, 16));
            GeneralWarn(new Vector2(28, 17));
        }

        private void Level3_Stage5_3()
        {
            RecycleSpikeMove(new Vector2(28, 12), new Vector2(-1, 0));
            RecycleSpikeMove(new Vector2(28, 13), new Vector2(-1, 0));
            RecycleSpikeMove(new Vector2(28, 14), new Vector2(-1, 0));
            RecycleSpikeMove(new Vector2(28, 15), new Vector2(-1, 0));
            RecycleSpikeMove(new Vector2(28, 16), new Vector2(-1, 0));
            RecycleSpikeMove(new Vector2(28, 17), new Vector2(-1, 0));
        }

        #endregion
    }
}