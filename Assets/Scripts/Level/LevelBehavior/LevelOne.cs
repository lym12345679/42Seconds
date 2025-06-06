﻿using System;
using System.Collections.Generic;
using Game.Traps;
using UnityEngine;
using Game.Recycle;


namespace Game.Level
{
    public class LevelOne : MonoBehaviour
    {
        private LevelBehavior levelBehavior;
        public List<Spike> Spikes = new List<Spike>();
        public Transform Location;

        private void Awake()
        {
            Initialize();
        }

        private void FixedUpdate()
        {
            if (LevelManager.Instance.GetGamePlayingState())
            {
                levelBehavior.OnFixedUpdate(); // 更新关卡行为树
            }
        }

        public void Initialize()
        {
            //8s
            levelBehavior = new LevelBehavior();
            LevelBehavior c1 = Stage1(levelBehavior);
            LevelBehavior c2 = Stage2(c1);
            LevelBehavior c3 = Stage3(c2);
            LevelBehavior c4 = Stage4(c3);
            LevelBehavior c5 = Stage5(c4);
            LevelBehavior c6 = Stage6(c5);
            LevelBehavior c7 = Stage7(c6);
            LevelBehavior c8 = Stage8(c7);
            LevelBehavior c9 = Stage9(c8);
        }

        private LevelBehavior Stage1(LevelBehavior l)
        {
            LevelBehavior d0 = l.AddChild().SetDelay(3f);
            LevelBehavior a0 = d0.AddChild().SetAction(Second3p5Action);
            LevelBehavior d1 = a0.AddChild().SetDelay(0.5f);
            LevelBehavior a1 = d1.AddChild().SetAction(Second4Action);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Second4p5Action);
            LevelBehavior d3 = a2.AddChild().SetDelay(0.5f);
            LevelBehavior a3 = d3.AddChild().SetAction(Second5Action);
            LevelBehavior d4 = a3.AddChild().SetDelay(0.5f);
            LevelBehavior a4 = d4.AddChild().SetAction(Second5p5Action);
            LevelBehavior d5 = a4.AddChild().SetDelay(0.5f);
            LevelBehavior a5 = d5.AddChild().SetAction(Second6Action);
            LevelBehavior d6 = a5.AddChild().SetDelay(0.5f);
            LevelBehavior a6 = d6.AddChild().SetAction(Second6p5Action);
            LevelBehavior d7 = a6.AddChild().SetDelay(0.5f);
            LevelBehavior a7 = d7.AddChild().SetAction(Second7Action);
            LevelBehavior d8 = a7.AddChild().SetDelay(1f);
            LevelBehavior a8 = d8.AddChild().SetAction(Second9Action);
            LevelBehavior d9 = a8.AddChild().SetDelay(0.5f);
            return d9;
        }

        private LevelBehavior Stage2(LevelBehavior l)
        {
            LevelBehavior d0 = l.AddChild().SetDelay(0.5f);
            LevelBehavior a0 = d0.AddChild().SetAction(Second10p5Action);
            LevelBehavior d1 = a0.AddChild().SetDelay(0.5f);
            LevelBehavior a1 = d1.AddChild().SetAction(Second11Action);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Second11p5Action);
            LevelBehavior d3 = a2.AddChild().SetDelay(0.5f);
            LevelBehavior a3 = d3.AddChild().SetAction(Second12Action);
            LevelBehavior d4 = a3.AddChild().SetDelay(1f);
            LevelBehavior a4 = d4.AddChild().SetAction(Second13Action);
            LevelBehavior d5 = a4.AddChild().SetDelay(1f);
            LevelBehavior a5 = d5.AddChild().SetAction(Second14Action);
            LevelBehavior d6 = a5.AddChild().SetDelay(0.5f);
            LevelBehavior a6 = d6.AddChild().SetAction(Second14p5Action);
            LevelBehavior d7 = a6.AddChild().SetDelay(0.5f);
            return d7;
        }

        private LevelBehavior Stage3(LevelBehavior l)
        {
            LevelBehavior d0 = l.AddChild().SetDelay(0.5f);
            LevelBehavior a0 = d0.AddChild().SetAction(Second16Action);
            LevelBehavior d1 = a0.AddChild().SetDelay(1f);
            LevelBehavior a1 = d1.AddChild().SetAction(Second17Action);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Second17p5Action);
            LevelBehavior d3 = a2.AddChild().SetDelay(1f);
            LevelBehavior a3 = d3.AddChild().SetAction(Second18p5Action);
            LevelBehavior d4 = a3.AddChild().SetDelay(1.5f);
            LevelBehavior a4 = d4.AddChild().SetAction(Second20Action);
            LevelBehavior d5 = a4.AddChild().SetDelay(0f);
            return d5;
        }

        private LevelBehavior Stage4(LevelBehavior l)
        {
            LevelBehavior d0 = l.AddChild().SetDelay(0.5f);
            LevelBehavior a0 = d0.AddChild().SetAction(Second20p5Action);
            LevelBehavior d1 = a0.AddChild().SetDelay(0.5f);
            LevelBehavior a1 = d1.AddChild().SetAction(Second21Action);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Second21p5Action);
            LevelBehavior d3 = a2.AddChild().SetDelay(0.5f);
            LevelBehavior a3 = d3.AddChild().SetAction(Second22Action);
            LevelBehavior d4 = a3.AddChild().SetDelay(0.5f);
            LevelBehavior a4 = d4.AddChild().SetAction(Second22p5Action);
            LevelBehavior d5 = a4.AddChild().SetDelay(0f);
            return d5;
        }

        private LevelBehavior Stage5(LevelBehavior l)
        {
            LevelBehavior d0 = l.AddChild().SetDelay(0.5f);
            LevelBehavior a0 = d0.AddChild().SetAction(Second23Action);
            LevelBehavior d1 = a0.AddChild().SetDelay(0.5f);
            LevelBehavior a1 = d1.AddChild().SetAction(Second23p5Action);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Second24Action);
            LevelBehavior d3 = a2.AddChild().SetDelay(0.5f);
            LevelBehavior a3 = d3.AddChild().SetAction(Second24p5Action);
            LevelBehavior d4 = a3.AddChild().SetDelay(0);
            return d4;
        }

        private LevelBehavior Stage6(LevelBehavior l)
        {
            LevelBehavior d0 = l.AddChild().SetDelay(0.5f);
            LevelBehavior a0 = d0.AddChild().SetAction(Second25Action);
            LevelBehavior d1 = a0.AddChild().SetDelay(0.5f);
            LevelBehavior a1 = d1.AddChild().SetAction(Second25p5Action);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Second26Action);
            LevelBehavior d3 = a2.AddChild().SetDelay(0.5f);
            LevelBehavior a3 = d3.AddChild().SetAction(Second26p5Action);
            LevelBehavior d4 = a3.AddChild().SetDelay(0f);
            return d4;
        }

        private LevelBehavior Stage7(LevelBehavior l)
        {
            LevelBehavior d0 = l.AddChild().SetDelay(0.5f);
            LevelBehavior a0 = d0.AddChild().SetAction(Second27Action);
            LevelBehavior d1 = a0.AddChild().SetDelay(0.5f);
            LevelBehavior a1 = d1.AddChild().SetAction(Second27p5Action);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Second28Action);
            LevelBehavior d3 = a2.AddChild().SetDelay(0.5f);
            LevelBehavior a3 = d3.AddChild().SetAction(Second28p5Action);
            LevelBehavior d4 = a3.AddChild().SetDelay(0.5f);
            LevelBehavior a4 = d4.AddChild().SetAction(Second29Action);
            LevelBehavior d5 = a4.AddChild().SetDelay(0.5f);
            LevelBehavior a5 = d5.AddChild().SetAction(Second29p5Action);
            LevelBehavior d6 = a5.AddChild().SetDelay(1f);
            LevelBehavior a6 = d6.AddChild().SetAction(Second30p5Action);
            LevelBehavior d7 = a6.AddChild().SetDelay(0f);
            return d7;
        }

        private LevelBehavior Stage8(LevelBehavior l)
        {
            LevelBehavior d0 = l.AddChild().SetDelay(0.5f);
            LevelBehavior a0 = d0.AddChild().SetAction(Second31Action);
            LevelBehavior d1 = a0.AddChild().SetDelay(0.5f);
            LevelBehavior a1 = d1.AddChild().SetAction(Second31p5Action);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            LevelBehavior a2 = d2.AddChild().SetAction(Second32Action);
            LevelBehavior d3 = a2.AddChild().SetDelay(0.5f);
            LevelBehavior a3 = d3.AddChild().SetAction(Second32p5Action);
            LevelBehavior d4 = a3.AddChild().SetDelay(0.5f);
            LevelBehavior a4 = d4.AddChild().SetAction(Second33Action);
            LevelBehavior d5 = a4.AddChild().SetDelay(0.5f);
            LevelBehavior a5 = d5.AddChild().SetAction(Second33p5Action);
            LevelBehavior d6 = a5.AddChild().SetDelay(0.5f);
            LevelBehavior a6 = d6.AddChild().SetAction(Second34Action);
            LevelBehavior d7 = a6.AddChild().SetDelay(0.5f);
            LevelBehavior a7 = d7.AddChild().SetAction(Second34p5Action);
            LevelBehavior d8 = a7.AddChild().SetDelay(0.5f);
            LevelBehavior a8 = d8.AddChild().SetAction(Second35Action);
            LevelBehavior d9 = a8.AddChild().SetDelay(0.5f);
            LevelBehavior a9 = d9.AddChild().SetAction(Second35p5Action);
            LevelBehavior d10 = a9.AddChild().SetDelay(0.5f);
            LevelBehavior a10 = d10.AddChild().SetAction(Second36Action);
            LevelBehavior d11 = a10.AddChild().SetDelay(0.5f);
            LevelBehavior a11 = d11.AddChild().SetAction(Second36p5Action);
            LevelBehavior d12 = a11.AddChild().SetDelay(1f);
            LevelBehavior a12 = d12.AddChild().SetAction(Second37p5Action);
            LevelBehavior d13 = a12.AddChild().SetDelay(.5f);
            return d13;
        }

        private LevelBehavior Stage9(LevelBehavior l)
        {
            LevelBehavior d0 = l.AddChild().SetDelay(0.5f);
            LevelBehavior a0 = d0.AddChild().SetAction(Second39p5Action);
            LevelBehavior d1 = a0.AddChild().SetDelay(0.5f);
            LevelBehavior a1 = d1.AddChild().SetAction(Second40Action);
            LevelBehavior d2 = a1.AddChild().SetDelay(0.5f);
            return d2;
        }

        #region Operation

        private void SpikeMove(int n, float t = 0f, float x = 0f, float y = 0f)
        {
            Spikes[n].Move(
                new Vector3(x, y, 0),
                t);
        }

        /// <summary>
        /// 闪现到指定坐标
        /// </summary>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SpikeFlash1(int n, float x = 0f, float y = 0f)
        {
            Spikes[n].Flash(
                new Vector3(x + 10, y + 11, 0));
        }

        /// <summary>
        /// 根据向量进行闪现
        /// </summary>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SpikeFlash2(int n, float x = 0f, float y = 0f)
        {
            Spikes[n].Flash(
                new Vector3(Spikes[n].transform.position.x + x, Spikes[n].transform.position.y + y, 0));
        }

        private void SpikeWarn(int n, float x = 0f, float y = 0f)
        {
            RecyclePool.Request(RecycleItemEnum.Warn, r =>
            {
                r.GameObject.transform.position =
                    new Vector3(x + n + 10f, y + 11f, 0);
            });
        }

        #endregion


        #region 3.5~9s

        private void Second3p5Action()
        {
            SpikeWarn(0, 0, 1);
            SpikeWarn(14, 0, 1);
        }

        private void Second4Action()
        {
            SpikeMove(0, 0.5f, 0, 1);
            SpikeMove(14, 0.5f, 0, 1);
        }

        private void Second4p5Action()
        {
            SpikeWarn(2, 0, 1);
            SpikeWarn(12, 0, 1);
        }

        private void Second5Action()
        {
            SpikeMove(0, 0.5f, 0, -1);
            SpikeMove(14, 0.5f, 0, -1);
            SpikeMove(2, 0.5f, 0, 1);
            SpikeMove(12, 0.5f, 0, 1);
        }

        private void Second5p5Action()
        {
            SpikeWarn(4, 0, 1);
            SpikeWarn(10, 0, 1);
        }

        private void Second6Action()
        {
            SpikeMove(2, 0.5f, 0, -1);
            SpikeMove(12, 0.5f, 0, -1);
            SpikeMove(4, 0.5f, 0, 1);
            SpikeMove(10, 0.5f, 0, 1);
        }

        private void Second6p5Action()
        {
            SpikeWarn(6, 0, 1);
            SpikeWarn(8, 0, 1);
        }

        private void Second7Action()
        {
            SpikeMove(4, 0.5f, 0, -1);
            SpikeMove(10, 0.5f, 0, -1);
            SpikeMove(6, 0.5f, 0, 1);
            SpikeMove(8, 0.5f, 0, 1);
        }

        private void Second9Action()
        {
            SpikeMove(6, 0.5f, 0, -1);
            SpikeMove(8, 0.5f, 0, -1);
        }

        #endregion

        #region 10~13.5s

        private void Second10p5Action()
        {
            SpikeWarn(6, 0, 1);
            SpikeWarn(7, 0, 1);
            SpikeWarn(8, 0, 1);
        }

        private void Second11Action()
        {
            SpikeWarn(3, 0, 1);
            SpikeWarn(4, 0, 1);
            SpikeWarn(10, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeMove(6, 0.5f, 0, 1);
            SpikeMove(7, 0.5f, 0, 1);
            SpikeMove(8, 0.5f, 0, 1);
        }

        private void Second11p5Action()
        {
            SpikeWarn(0, 0, 1);
            SpikeWarn(1, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeWarn(14, 0, 1);

            SpikeMove(10, 0.5f, 0, 1);
            SpikeMove(11, 0.5f, 0, 1);
            SpikeMove(3, 0.5f, 0, 1);
            SpikeMove(4, 0.5f, 0, 1);
        }

        private void Second12Action()
        {
            SpikeMove(0, 0.5f, 0, 1);
            SpikeMove(1, 0.5f, 0, 1);
            SpikeMove(13, 0.5f, 0, 1);
            SpikeMove(14, 0.5f, 0, 1);
        }

        private void Second13Action()
        {
            SpikeMove(0, 0.5f, 0, -1);
            SpikeMove(1, 0.5f, 0, -1);
            SpikeMove(3, 0.5f, 0, -1);
            SpikeMove(4, 0.5f, 0, -1);
            SpikeMove(6, 0.5f, 0, -1);
            SpikeMove(7, 0.5f, 0, -1);
            SpikeMove(8, 0.5f, 0, -1);
            SpikeMove(10, 0.5f, 0, -1);
            SpikeMove(11, 0.5f, 0, -1);
            SpikeMove(13, 0.5f, 0, -1);
            SpikeMove(14, 0.5f, 0, -1);
        }

        #endregion

        #region 14~19s

        private void Second14Action()
        {
            SpikeWarn(0, 0, 1);
            SpikeWarn(1, 0, 1);
            SpikeWarn(6, 0, 1);
            SpikeWarn(7, 0, 1);
            SpikeWarn(8, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeWarn(14, 0, 1);
        }

        private void Second14p5Action()
        {
            SpikeMove(0, 0.5f, 0, 1);
            SpikeMove(1, 0.5f, 0, 1);
            SpikeMove(6, 0.5f, 0, 1);
            SpikeMove(7, 0.5f, 0, 1);
            SpikeMove(8, 0.5f, 0, 1);
            SpikeMove(13, 0.5f, 0, 1);
            SpikeMove(14, 0.5f, 0, 1);
        }

        private void Second16Action()
        {
            SpikeMove(0, 0.5f, 0, -1);
            SpikeMove(1, 0.5f, 0, -1);
            SpikeMove(13, 0.5f, 0, -1);
            SpikeMove(14, 0.5f, 0, -1);
        }

        private void Second17Action()
        {
            SpikeWarn(2, 0, 1);
            SpikeWarn(3, 0, 1);
            SpikeWarn(4, 0, 1);
            SpikeWarn(5, 0, 1);
            SpikeWarn(9, 0, 1);
            SpikeWarn(10, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeWarn(12, 0, 1);
        }

        private void Second17p5Action()
        {
            SpikeMove(2, 0.5f, 0, 1);
            SpikeMove(3, 0.5f, 0, 1);
            SpikeMove(4, 0.5f, 0, 1);
            SpikeMove(5, 0.5f, 0, 1);
            SpikeMove(9, 0.5f, 0, 1);
            SpikeMove(10, 0.5f, 0, 1);
            SpikeMove(11, 0.5f, 0, 1);
            SpikeMove(12, 0.5f, 0, 1);
        }

        private void Second18p5Action()
        {
            SpikeMove(2, 0.5f, 0, -1);
            SpikeMove(3, 0.5f, 0, -1);
            SpikeMove(4, 0.5f, 0, -1);
            SpikeMove(5, 0.5f, 0, -1);
            SpikeMove(6, 0.5f, 0, -1);
            SpikeMove(7, 0.5f, 0, -1);
            SpikeMove(8, 0.5f, 0, -1);
            SpikeMove(9, 0.5f, 0, -1);
            SpikeMove(10, 0.5f, 0, -1);
            SpikeMove(11, 0.5f, 0, -1);
            SpikeMove(12, 0.5f, 0, -1);
        }

        #endregion

        #region 20~26s

        private void Second20Action()
        {
            SpikeWarn(0, 0, 1);
            SpikeWarn(14, 0, 1);
        }

        private void Second20p5Action()
        {
            SpikeWarn(1, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeMove(0, 0.5f, 0, 1);
            SpikeMove(14, 0.5f, 0, 1);
        }

        private void Second21Action()
        {
            SpikeWarn(2, 0, 1);
            SpikeWarn(12, 0, 1);
            SpikeMove(1, 0.5f, 0, 1);
            SpikeMove(13, 0.5f, 0, 1);
        }

        private void Second21p5Action()
        {
            SpikeWarn(3, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeMove(2, 0.5f, 0, 1);
            SpikeMove(12, 0.5f, 0, 1);
        }

        private void Second22Action()
        {
            SpikeWarn(4, 0, 1);
            SpikeWarn(10, 0, 1);
            SpikeMove(3, 0.5f, 0, 1);
            SpikeMove(11, 0.5f, 0, 1);
            SpikeMove(14, 0.5f, 0, -1);
            SpikeMove(0, 0.5f, 0, -1);
        }

        private void Second22p5Action()
        {
            SpikeWarn(5, 0, 1);
            SpikeWarn(9, 0, 1);
            SpikeMove(4, 0.5f, 0, 1);
            SpikeMove(10, 0.5f, 0, 1);
            SpikeMove(13, 0.5f, 0, -1);
            SpikeMove(1, 0.5f, 0, -1);
        }

        private void Second23Action()
        {
            SpikeWarn(6, 0, 1);
            SpikeWarn(8, 0, 1);
            SpikeMove(5, 0.5f, 0, 1);
            SpikeMove(9, 0.5f, 0, 1);
            SpikeMove(12, 0.5f, 0, -1);
            SpikeMove(2, 0.5f, 0, -1);
        }

        private void Second23p5Action()
        {
            SpikeWarn(7, 0, 1);
            SpikeMove(6, 0.5f, 0, 1);
            SpikeMove(8, 0.5f, 0, 1);
            SpikeMove(11, 0.5f, 0, -1);
            SpikeMove(3, 0.5f, 0, -1);
        }

        private void Second24Action()
        {
            SpikeMove(7, 0.5f, 0, 1);
            SpikeMove(10, 0.5f, 0, -1);
            SpikeMove(4, 0.5f, 0, -1);
        }

        private void Second24p5Action()
        {
            SpikeMove(9, 0.5f, 0, -1);
            SpikeMove(5, 0.5f, 0, -1);
        }

        private void Second25Action()
        {
            SpikeMove(8, 0.5f, 0, -1);
            SpikeMove(6, 0.5f, 0, -1);
        }

        private void Second25p5Action()
        {
            SpikeMove(7, 0.5f, 0, -1);
        }

        #endregion

        #region 26~31s

        private void Second26Action()
        {
            SpikeWarn(0, 0, 1);
            SpikeWarn(1, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeWarn(14, 0, 1);
        }

        private void Second26p5Action()
        {
            SpikeMove(0, 0.5f, 0, 1);
            SpikeMove(1, 0.5f, 0, 1);
            SpikeMove(13, 0.5f, 0, 1);
            SpikeMove(14, 0.5f, 0, 1);
        }

        private void Second27Action()
        {
            SpikeWarn(2, 0, 1);
            SpikeWarn(3, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeWarn(12, 0, 1);
        }

        private void Second27p5Action()
        {
            SpikeMove(2, 0.5f, 0, 1);
            SpikeMove(3, 0.5f, 0, 1);
            SpikeMove(11, 0.5f, 0, 1);
            SpikeMove(12, 0.5f, 0, 1);
        }

        private void Second28Action()
        {
            SpikeWarn(4, 0, 1);
            SpikeWarn(5, 0, 1);
            SpikeWarn(9, 0, 1);
            SpikeWarn(10, 0, 1);
        }

        private void Second28p5Action()
        {
            SpikeMove(4, 0.5f, 0, 1);
            SpikeMove(5, 0.5f, 0, 1);
            SpikeMove(9, 0.5f, 0, 1);
            SpikeMove(10, 0.5f, 0, 1);
        }

        private void Second29Action()
        {
            SpikeWarn(6, 0, 1);
            SpikeWarn(7, 0, 1);
        }

        private void Second29p5Action()
        {
            SpikeMove(6, 0.5f, 0, 1);
            SpikeMove(7, 0.5f, 0, 1);
        }

        private void Second30p5Action()
        {
            SpikeMove(0, 0.5f, 0, -1);
            SpikeMove(1, 0.5f, 0, -1);
            SpikeMove(2, 0.5f, 0, -1);
            SpikeMove(3, 0.5f, 0, -1);
            SpikeMove(4, 0.5f, 0, -1);
            SpikeMove(5, 0.5f, 0, -1);
            SpikeMove(6, 0.5f, 0, -1);
            SpikeMove(7, 0.5f, 0, -1);
            SpikeMove(9, 0.5f, 0, -1);
            SpikeMove(10, 0.5f, 0, -1);
            SpikeMove(11, 0.5f, 0, -1);
            SpikeMove(12, 0.5f, 0, -1);
            SpikeMove(13, 0.5f, 0, -1);
            SpikeMove(14, 0.5f, 0, -1);
        }

        #endregion

        #region 31~38s

        private void Second31Action()
        {
            SpikeWarn(5, 0, 1);
            SpikeWarn(6, 0, 1);
            SpikeWarn(7, 0, 1);
            SpikeWarn(8, 0, 1);
            SpikeWarn(9, 0, 1);
        }

        private void Second31p5Action()
        {
            SpikeMove(5, 0.5f, 0, 1);
            SpikeMove(6, 0.5f, 0, 1);
            SpikeMove(7, 0.5f, 0, 1);
            SpikeMove(8, 0.5f, 0, 1);
            SpikeMove(9, 0.5f, 0, 1);
        }

        private void Second32Action()
        {
            SpikeWarn(0, 0, 1);
            SpikeWarn(1, 0, 1);
            SpikeWarn(2, 0, 1);
            SpikeWarn(3, 0, 1);
            SpikeWarn(4, 0, 1);
        }

        private void Second32p5Action()
        {
            SpikeMove(0, 0.5f, 0, 1);
            SpikeMove(1, 0.5f, 0, 1);
            SpikeMove(2, 0.5f, 0, 1);
            SpikeMove(3, 0.5f, 0, 1);
            SpikeMove(4, 0.5f, 0, 1);
            SpikeMove(5, 0.5f, 0, -1);
            SpikeMove(6, 0.5f, 0, -1);
            SpikeMove(7, 0.5f, 0, -1);
            SpikeMove(8, 0.5f, 0, -1);
            SpikeMove(9, 0.5f, 0, -1);
        }

        private void Second33Action()
        {
            SpikeWarn(10, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeWarn(12, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeWarn(14, 0, 1);
        }

        private void Second33p5Action()
        {
            SpikeMove(10, 0.5f, 0, 1);
            SpikeMove(11, 0.5f, 0, 1);
            SpikeMove(12, 0.5f, 0, 1);
            SpikeMove(13, 0.5f, 0, 1);
            SpikeMove(14, 0.5f, 0, 1);
            SpikeMove(0, 0.5f, 0, -1);
            SpikeMove(1, 0.5f, 0, -1);
            SpikeMove(2, 0.5f, 0, -1);
            SpikeMove(3, 0.5f, 0, -1);
            SpikeMove(4, 0.5f, 0, -1);
        }

        private void Second34Action()
        {
            SpikeWarn(5, 0, 1);
            SpikeWarn(6, 0, 1);
            SpikeWarn(7, 0, 1);
            SpikeWarn(8, 0, 1);
            SpikeWarn(9, 0, 1);
        }

        private void Second34p5Action()
        {
            SpikeMove(5, 0.5f, 0, 1);
            SpikeMove(6, 0.5f, 0, 1);
            SpikeMove(7, 0.5f, 0, 1);
            SpikeMove(8, 0.5f, 0, 1);
            SpikeMove(9, 0.5f, 0, 1);
            SpikeMove(10, 0.5f, 0, -1);
            SpikeMove(11, 0.5f, 0, -1);
            SpikeMove(12, 0.5f, 0, -1);
            SpikeMove(13, 0.5f, 0, -1);
            SpikeMove(14, 0.5f, 0, -1);
        }

        private void Second35Action()
        {
            SpikeWarn(0, 0, 1);
            SpikeWarn(1, 0, 1);
            SpikeWarn(2, 0, 1);
            SpikeWarn(3, 0, 1);
            SpikeWarn(4, 0, 1);
        }

        private void Second35p5Action()
        {
            SpikeMove(0, 0.5f, 0, 1);
            SpikeMove(1, 0.5f, 0, 1);
            SpikeMove(2, 0.5f, 0, 1);
            SpikeMove(3, 0.5f, 0, 1);
            SpikeMove(4, 0.5f, 0, 1);
            SpikeMove(5, 0.5f, 0, -1);
            SpikeMove(6, 0.5f, 0, -1);
            SpikeMove(7, 0.5f, 0, -1);
            SpikeMove(8, 0.5f, 0, -1);
            SpikeMove(9, 0.5f, 0, -1);
        }

        private void Second36Action()
        {
            SpikeWarn(10, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeWarn(12, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeWarn(14, 0, 1);
        }

        private void Second36p5Action()
        {
            SpikeMove(10, 0.5f, 0, 1);
            SpikeMove(11, 0.5f, 0, 1);
            SpikeMove(12, 0.5f, 0, 1);
            SpikeMove(13, 0.5f, 0, 1);
            SpikeMove(14, 0.5f, 0, 1);
            SpikeMove(0, 0.5f, 0, -1);
            SpikeMove(1, 0.5f, 0, -1);
            SpikeMove(2, 0.5f, 0, -1);
            SpikeMove(3, 0.5f, 0, -1);
            SpikeMove(4, 0.5f, 0, -1);
        }

        private void Second37p5Action()
        {
            SpikeMove(10, 0.5f, 0, -1);
            SpikeMove(11, 0.5f, 0, -1);
            SpikeMove(12, 0.5f, 0, -1);
            SpikeMove(13, 0.5f, 0, -1);
            SpikeMove(14, 0.5f, 0, -1);
        }

        #endregion

        #region 38~42s

        private void Second39p5Action()
        {
            SpikeWarn(0, 0, 1);
            SpikeWarn(1, 0, 1);
            SpikeWarn(2, 0, 1);
            SpikeWarn(3, 0, 1);
            SpikeWarn(4, 0, 1);
            SpikeWarn(10, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeWarn(12, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeWarn(14, 0, 1);
        }

        private void Second40Action()
        {
            SpikeMove(0, 2f, 0, 6);
            SpikeMove(1, 2f, 0, 6);
            SpikeMove(2, 2f, 0, 6);
            SpikeMove(3, 2f, 0, 6);
            SpikeMove(4, 2f, 0, 6);
            SpikeMove(10, 2f, 0, 6);
            SpikeMove(11, 2f, 0, 6);
            SpikeMove(12, 2f, 0, 6);
            SpikeMove(13, 2f, 0, 6);
            SpikeMove(14, 2f, 0, 6);
        }

        #endregion
    }
}