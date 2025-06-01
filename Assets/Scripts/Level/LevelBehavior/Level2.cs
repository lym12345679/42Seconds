using System;
using Game.Recycle;
using Game.Traps;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Level
{
    public class Level2 : LevelBehaviorTree
    {
        [FormerlySerializedAs("LocalPosition")]
        public Transform LocalTransform;

        protected override Action GetAction()
        {
            return Selector(
                () => Condition(currentTime > 3f && currentTime < 10f,
                    () => Selector(
                        () => Condition(currentTime > 3.5f && !targetTime[3.5f], Second3p5Action),
                        () => Condition(currentTime > 4f && !targetTime[4f], Second4Action),
                        () => Condition(currentTime > 4.5f && !targetTime[4.5f], Second4p5Action),
                        () => Condition(currentTime > 5f && !targetTime[5f], Second5Action),
                        () => Condition(currentTime > 5.5f && !targetTime[5.5f], Second5p5Action),
                        () => Condition(currentTime > 6f && !targetTime[6f], Second6Action),
                        () => Condition(currentTime > 6.5f && !targetTime[6.5f], Second6p5Action),
                        () => Condition(currentTime > 7f && !targetTime[7f], Second7Action),
                        () => Condition(currentTime > 7.5f && !targetTime[7.5f], Second7p5Action),
                        () => Condition(currentTime > 8f && !targetTime[8f], Second8Action),
                        () => Condition(currentTime > 8.5f && !targetTime[8.5f], Second8p5Action)
                    )),
                () => Condition(currentTime > 10f && currentTime < 14f,
                    () => Selector(
                        () => Condition(currentTime > 10.5f && !targetTime[10.5f], Second10p5Action),
                        () => Condition(currentTime > 11f && !targetTime[11f], Second11Action),
                        () => Condition(currentTime > 11.5f && !targetTime[11.5f], Second11p5Action),
                        () => Condition(currentTime > 12f && !targetTime[12f], Second12Action),
                        () => Condition(currentTime > 13f && !targetTime[13f], Second13Action)
                    )),
                () => Condition(currentTime > 14f && currentTime < 19f,
                    () => Selector(
                        () => Condition(currentTime > 14f && !targetTime[14f], Second14Action),
                        () => Condition(currentTime > 14.5f && !targetTime[14.5f], Second14p5Action),
                        () => Condition(currentTime > 16f && !targetTime[16f], Second16Action),
                        () => Condition(currentTime > 16.5f && !targetTime[16.5f], Second16p5Action),
                        () => Condition(currentTime > 17f && !targetTime[17f], Second17Action),
                        () => Condition(currentTime > 17.5f && !targetTime[17.5f], Second17p5Action),
                        () => Condition(currentTime > 18.5f && !targetTime[18.5f], Second18p5Action)
                    )),
                () => Condition(currentTime > 20f && currentTime < 26f,
                    () => Selector(
                        () => Condition(currentTime > 20f && !targetTime[20f], Second20Action),
                        () => Condition(currentTime > 20.5f && !targetTime[20.5f], Second20p5Action),
                        () => Condition(currentTime > 21f && !targetTime[21f], Second21Action),
                        () => Condition(currentTime > 21.5f && !targetTime[21.5f], Second21p5Action),
                        () => Condition(currentTime > 22f && !targetTime[22f], Second22Action),
                        () => Condition(currentTime > 22.5f && !targetTime[22.5f], Second22p5Action),
                        () => Condition(currentTime > 23f && !targetTime[23f], Second23Action),
                        () => Condition(currentTime > 23.5f && !targetTime[23.5f], Second23p5Action),
                        () => Condition(currentTime > 24f && !targetTime[24f], Second24Action),
                        () => Condition(currentTime > 24.5f && !targetTime[24.5f], Second24p5Action),
                        () => Condition(currentTime > 25f && !targetTime[25f], Second25Action),
                        () => Condition(currentTime > 25.5f && !targetTime[25.5f], Second25p5Action)
                    )),
                () => Condition(currentTime > 26f && currentTime < 31f,
                    () => Selector(
                        () => Condition(currentTime > 26f && !targetTime[26f], Second26Action),
                        () => Condition(currentTime > 26.5f && !targetTime[26.5f], Second26p5Action),
                        () => Condition(currentTime > 27f && !targetTime[27f], Second27Action),
                        () => Condition(currentTime > 27.5f && !targetTime[27.5f], Second27p5Action),
                        () => Condition(currentTime > 28f && !targetTime[28f], Second28Action),
                        () => Condition(currentTime > 28.5f && !targetTime[28.5f], Second28p5Action),
                        () => Condition(currentTime > 29f && !targetTime[29f], Second29Action),
                        () => Condition(currentTime > 29.5f && !targetTime[29.5f], Second29p5Action),
                        () => Condition(currentTime > 30.5f && !targetTime[30.5f], Second30p5Action)
                    )),
                () => Condition(currentTime > 31f && currentTime < 38f,
                    () => Selector(
                        () => Condition(currentTime > 31f && !targetTime[31f], Second31Action),
                        () => Condition(currentTime > 31.5f && !targetTime[31.5f], Second31p5Action),
                        () => Condition(currentTime > 32f && !targetTime[32f], Second32Action),
                        () => Condition(currentTime > 32.5f && !targetTime[32.5f], Second32p5Action),
                        () => Condition(currentTime > 33f && !targetTime[33f], Second33Action),
                        () => Condition(currentTime > 33.5f && !targetTime[33.5f], Second33p5Action),
                        () => Condition(currentTime > 34f && !targetTime[34f], Second34Action),
                        () => Condition(currentTime > 34.5f && !targetTime[34.5f], Second34p5Action),
                        () => Condition(currentTime > 35f && !targetTime[35f], Second35Action),
                        () => Condition(currentTime > 35.5f && !targetTime[35.5f], Second35p5Action),
                        () => Condition(currentTime > 36f && !targetTime[36f], Second36Action),
                        () => Condition(currentTime > 36.5f && !targetTime[36.5f], Second36p5Action),
                        () => Condition(currentTime > 37.5f && !targetTime[37.5f], Second37p5Action)
                    )),
                () => Condition(currentTime > 38f && currentTime < 42f,
                    () => Selector(
                        () => Condition(currentTime > 39.5f && !targetTime[39.5f], Second39p5Action),
                        () => Condition(currentTime > 40f && !targetTime[40f], Second40Action)
                    ))
            );
        }

        #region Operation

        private void SpikeMove(int n, float t = 0f, float x = 0f, float y = 0f)
        {
            spikeList[n].Move(
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
            spikeList[n].Flash(
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
            spikeList[n].Flash(
                new Vector3(spikeList[n].transform.position.x + x, spikeList[n].transform.position.y + y, 0));
        }

        private void SpikeWarn(int n, float x = 0f, float y = 0f)
        {
            RecyclePool.Request(RecycleItemEnum.Warn, r =>
            {
                r.GameObject.transform.position =
                    new Vector3(x + n + 10f, y + 11f, 0);
            });
        }

        private void SpikeScale(int n, float t, float x = 1f, float y = 1f)
        {
            spikeList[n].Scale(
                new Vector3(x, y, 1),
                t);
        }

        #endregion


        #region 3.5~9s

        private Action Second3p5Action()
        {
            targetTime[3.5f] = true;
            SpikeWarn(0, 0, 1);
            SpikeWarn(14, 0, 1);
            return null;
        }

        private Action Second4Action()
        {
            targetTime[4f] = true;
            SpikeWarn(1, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeMove(0, 1f, 0, 1);
            SpikeMove(14, 1f, 0, 1);
            return null;
        }

        private Action Second4p5Action()
        {
            targetTime[4.5f] = true;
            SpikeWarn(2, 0, 1);
            SpikeWarn(12, 0, 1);
            SpikeMove(1, 1f, 0, 1);
            SpikeMove(13, 1f, 0, 1);
            return null;
        }

        private Action Second5Action()
        {
            targetTime[5f] = true;
            SpikeWarn(3, 0, 1);
            SpikeWarn(11, 0, 1);

            SpikeMove(2, 1f, 0, 1);
            SpikeMove(12, 1f, 0, 1);
            SpikeMove(0, 1f, 0, -1);
            SpikeMove(14, 1f, 0, -1);
            return null;
        }

        private Action Second5p5Action()
        {
            targetTime[5.5f] = true;
            SpikeWarn(4, 0, 1);
            SpikeWarn(10, 0, 1);

            SpikeMove(3, 1f, 0, 1);
            SpikeMove(11, 1f, 0, 1);
            SpikeMove(1, 1f, 0, -1);
            SpikeMove(13, 1f, 0, -1);
            return null;
        }

        private Action Second6Action()
        {
            targetTime[6f] = true;
            SpikeWarn(5, 0, 1);
            SpikeWarn(9, 0, 1);
            SpikeMove(2, 1f, 0, -1);
            SpikeMove(12, 1f, 0, -1);
            SpikeMove(4, 1f, 0, 1);
            SpikeMove(10, 1f, 0, 1);
            return null;
        }

        private Action Second6p5Action()
        {
            targetTime[6.5f] = true;
            SpikeWarn(6, 0, 1);
            SpikeWarn(8, 0, 1);

            SpikeMove(5, 1f, 0, 1);
            SpikeMove(9, 1f, 0, 1);
            SpikeMove(3, 1f, 0, -1);
            SpikeMove(11, 1f, 0, -1);
            return null;
        }

        private Action Second7Action()
        {
            targetTime[7f] = true;
            SpikeWarn(7, 0, 1);
            SpikeMove(6, 1f, 0, 1);
            SpikeMove(8, 1f, 0, 1);
            SpikeMove(4, 1f, 0, -1);
            SpikeMove(10, 1f, 0, -1);

            return null;
        }

        private Action Second7p5Action()
        {
            targetTime[7.5f] = true;
            SpikeMove(7, 1f, 0, 1);
            SpikeMove(5, 1f, 0, -1);
            SpikeMove(9, 1f, 0, -1);
            return null;
        }

        private Action Second8Action()
        {
            targetTime[8f] = true;
            SpikeMove(6, 1f, 0, -1);
            SpikeMove(8, 1f, 0, -1);
            return null;
        }

        private Action Second8p5Action()
        {
            targetTime[8.5f] = true;
            SpikeMove(7, 1f, 0, -1);
            return null;
        }

        #endregion

        #region 10~13.5s

        private Action Second10p5Action()
        {
            targetTime[10.5f] = true;
            SpikeWarn(6, 0, 1);
            SpikeWarn(7, 0, 1);
            SpikeWarn(8, 0, 1);
            return null;
        }

        private Action Second11Action()
        {
            targetTime[11f] = true;
            SpikeWarn(3, 0, 1);
            SpikeWarn(4, 0, 1);
            SpikeWarn(10, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeMove(6, 1f, 0, 1);
            SpikeMove(7, 1f, 0, 1);
            SpikeMove(8, 1f, 0, 1);

            return null;
        }

        private Action Second11p5Action()
        {
            targetTime[11.5f] = true;

            SpikeWarn(0, 0, 1);
            SpikeWarn(1, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeWarn(14, 0, 1);

            SpikeMove(10, 1f, 0, 1);
            SpikeMove(11, 1f, 0, 1);
            SpikeMove(3, 1f, 0, 1);
            SpikeMove(4, 1f, 0, 1);

            return null;
        }

        private Action Second12Action()
        {
            targetTime[12f] = true;
            SpikeMove(0, 1f, 0, 1);
            SpikeMove(1, 1f, 0, 1);
            SpikeMove(13, 1f, 0, 1);
            SpikeMove(14, 1f, 0, 1);
            return null;
        }


        private Action Second13Action()
        {
            targetTime[13f] = true;
            SpikeMove(0, 1f, 6, 0);
            SpikeMove(1, 1f, 6, 0);
            SpikeMove(3, 1f, 0, -1);
            SpikeMove(4, 1f, 0, -1);
            SpikeMove(6, 1f, 0, -1);
            SpikeMove(7, 1f, 0, -1);
            SpikeMove(8, 1f, 0, -1);
            SpikeMove(10, 1f, 0, -1);
            SpikeMove(11, 1f, 0, -1);
            SpikeMove(13, 1f, -6, 0);
            SpikeMove(14, 1f, 0 - 6, 0);
            return null;
        }

        #endregion

        #region 14~19s

        private Action Second14Action()
        {
            targetTime[14f] = true;
            SpikeWarn(2, 0, 1);
            SpikeWarn(3, 0, 1);
            SpikeWarn(4, 0, 1);
            SpikeWarn(5, 0, 1);
            SpikeWarn(9, 0, 1);
            SpikeWarn(10, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeWarn(12, 0, 1);
            return null;
        }

        private Action Second14p5Action()
        {
            targetTime[14.5f] = true;
            SpikeMove(2, 1f, 0, 1);
            SpikeMove(3, 1f, 0, 1);
            SpikeMove(4, 1f, 0, 1);
            SpikeMove(5, 1f, 0, 1);
            SpikeMove(9, 1f, 0, 1);
            SpikeMove(10, 1f, 0, 1);
            SpikeMove(11, 1f, 0, 1);
            SpikeMove(12, 1f, 0, 1);
            return null;
        }

        private Action Second16Action()
        {
            targetTime[16f] = true;

            return null;
        }

        private Action Second16p5Action()
        {
            targetTime[16.5f] = true;
            SpikeMove(2, 1f, -2, 0);
            SpikeMove(3, 1f, -2, 0);
            SpikeMove(4, 1f, -2, 0);
            SpikeMove(5, 1f, -2, 0);
            SpikeMove(9, 1f, 2, 0);
            SpikeMove(10, 1f, 2, 0);
            SpikeMove(11, 1f, 2, 0);
            SpikeMove(12, 1f, 2, 0);
            SpikeMove(0, 1f, 0, -1);
            SpikeMove(1, 1f, 0, -1);
            SpikeMove(13, 1f, 0, -1);
            SpikeMove(14, 1f, 0, -1);
            return null;
        }

        private Action Second17Action()
        {
            targetTime[17f] = true;

            return null;
        }

        private Action Second17p5Action()
        {
            targetTime[17.5f] = true;

            return null;
        }

        private Action Second18p5Action()
        {
            targetTime[18.5f] = true;
            SpikeMove(2, 1f, 0, -1);
            SpikeMove(3, 1f, 0, -1);
            SpikeMove(4, 1f, 0, -1);
            SpikeMove(5, 1f, 0, -1);

            SpikeMove(9, 1f, 0, -1);
            SpikeMove(10, 1f, 0, -1);
            SpikeMove(11, 1f, 0, -1);
            SpikeMove(12, 1f, 0, -1);

            return null;
        }

        #endregion


        #region 20~31s

        private Action Second20Action()
        {
            targetTime[20f] = true;
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
            SpikeWarn(0, 0, 1);
            SpikeWarn(14, 0, 1);
            return null;
        }

        private Action Second20p5Action()
        {
            targetTime[20.5f] = true;
            SpikeWarn(1, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeMove(0, 1f, 0, 1);
            SpikeMove(14, 1f, 0, 1);

            return null;
        }

        private Action Second21Action()
        {
            targetTime[21f] = true;
            SpikeWarn(2, 0, 1);
            SpikeWarn(12, 0, 1);
            SpikeMove(1, 1f, 0, 1);
            SpikeMove(13, 1f, 0, 1);
            return null;
        }

        private Action Second21p5Action()
        {
            targetTime[21.5f] = true;
            SpikeWarn(3, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeMove(2, 1f, 0, 1);
            SpikeMove(12, 1f, 0, 1);
            return null;
        }

        private Action Second22Action()
        {
            targetTime[22f] = true;
            SpikeWarn(4, 0, 1);
            SpikeWarn(10, 0, 1);
            SpikeMove(3, 1f, 0, 1);
            SpikeMove(11, 1f, 0, 1);
            SpikeMove(14, 1f, 0, -1);
            SpikeMove(0, 1f, 0, -1);
            return null;
        }

        private Action Second22p5Action()
        {
            targetTime[22.5f] = true;
            SpikeWarn(5, 0, 1);
            SpikeWarn(9, 0, 1);
            SpikeMove(4, 1f, 0, 1);
            SpikeMove(10, 1f, 0, 1);
            SpikeMove(13, 1f, 0, -1);
            SpikeMove(1, 1f, 0, -1);
            return null;
        }

        private Action Second23Action()
        {
            targetTime[23f] = true;
            SpikeWarn(6, 0, 1);
            SpikeWarn(8, 0, 1);
            SpikeMove(5, 1f, 0, 1);
            SpikeMove(9, 1f, 0, 1);
            SpikeMove(12, 1f, 0, -1);
            SpikeMove(2, 1f, 0, -1);
            return null;
        }

        private Action Second23p5Action()
        {
            targetTime[23.5f] = true;
            SpikeWarn(7, 0, 1);
            SpikeMove(6, 1f, 0, 1);
            SpikeMove(8, 1f, 0, 1);
            SpikeMove(11, 1f, 0, -1);
            SpikeMove(3, 1f, 0, -1);
            return null;
        }

        private Action Second24Action()
        {
            targetTime[24f] = true;
            SpikeWarn(0, 0, 1);
            SpikeWarn(14, 0, 1);

            SpikeMove(7, 1f, 0, 1);
            SpikeMove(10, 1f, 0, -1);
            SpikeMove(4, 1f, 0, -1);
            return null;
        }

        private Action Second24p25Action()
        {
            targetTime[24.25f] = true;
            SpikeWarn(1, 0, 1);
            SpikeWarn(13, 0, 1);
            return null;
        }

        private Action Second24p5Action()
        {
            targetTime[24.5f] = true;
            SpikeWarn(2, 0, 1);
            SpikeWarn(12, 0, 1);

            SpikeMove(0, .5f, 0, 1);
            SpikeMove(14, .5f, 0, 1);

            SpikeMove(9, 1f, 0, -1);
            SpikeMove(5, 1f, 0, -1);
            return null;
        }

        private Action Second24p75Action()
        {
            targetTime[24.75f] = true;
            SpikeWarn(3, 0, 1);
            SpikeWarn(11, 0, 1);

            SpikeMove(1, .5f, 0, 1);
            SpikeMove(13, .5f, 0, 1);
            return null;
        }

        private Action Second25Action()
        {
            targetTime[25f] = true;
            SpikeWarn(4, 0, 1);
            SpikeWarn(10, 0, 1);

            SpikeMove(2, .5f, 0, 1);
            SpikeMove(12, .5f, 0, 1);

            SpikeMove(8, 1f, 0, -1);
            SpikeMove(6, 1f, 0, -1);
            return null;
        }

        private Action Second25p25Action()
        {
            targetTime[25.25f] = true;
            SpikeWarn(5, 0, 1);
            SpikeWarn(9, 0, 1);

            SpikeMove(3, .5f, 0, 1);
            SpikeMove(11, .5f, 0, 1);
            return null;
        }

        private Action Second25p5Action()
        {
            targetTime[25.5f] = true;
            SpikeWarn(6, 0, 1);

            SpikeMove(4, .5f, 0, 1);
            SpikeMove(10, .5f, 0, 1);
            SpikeMove(7, 1f, 0, -1);
            return null;
        }

        private Action Second25p75Action()
        {
            targetTime[25.75f] = true;
            SpikeWarn(7, 0, 1);

            SpikeMove(5, .5f, 0, 1);
            SpikeMove(9, .5f, 0, 1);
            return null;
        }

        private Action Second26Action()
        {
            targetTime[26f] = true;

            SpikeWarn(1, 0, 1);
            SpikeWarn(13, 0, 1);

            return null;
        }

        private Action Second26p5Action()
        {
            targetTime[26.5f] = true;
            SpikeWarn(2, 0, 1);
            SpikeWarn(3, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeWarn(12, 0, 1);
            SpikeMove(0, 1f, 0, 1);
            SpikeMove(1, 1f, 0, 1);
            SpikeMove(13, 1f, 0, 1);
            SpikeMove(14, 1f, 0, 1);
            return null;
        }

        private Action Second27Action()
        {
            targetTime[27f] = true;
            SpikeWarn(4, 0, 1);
            SpikeWarn(5, 0, 1);
            SpikeWarn(9, 0, 1);
            SpikeWarn(10, 0, 1);
            SpikeMove(2, 1f, 0, 1);
            SpikeMove(3, 1f, 0, 1);
            SpikeMove(11, 1f, 0, 1);
            SpikeMove(12, 1f, 0, 1);
            return null;
        }

        private Action Second27p5Action()
        {
            targetTime[27.5f] = true;
            SpikeWarn(6, 0, 1);
            SpikeWarn(7, 0, 1);
            SpikeMove(4, 1f, 0, 1);
            SpikeMove(5, 1f, 0, 1);
            SpikeMove(9, 1f, 0, 1);
            SpikeMove(10, 1f, 0, 1);
            return null;
        }

        private Action Second28Action()
        {
            targetTime[28f] = true;
            SpikeMove(6, 1f, 0, 1);
            SpikeMove(7, 1f, 0, 1);
            SpikeMove(0, 1f, 0, -1);
            return null;
        }

        private Action Second28p5Action()
        {
            targetTime[28.5f] = true;

            return null;
        }

        private Action Second29Action()
        {
            targetTime[29f] = true;
            SpikeWarn(8, 0, 1);
            return null;
        }

        private Action Second29p5Action()
        {
            targetTime[29.5f] = true;
            SpikeMove(8, 1f, 0, 1);
            return null;
        }

        private Action Second30p5Action()
        {
            targetTime[30.5f] = true;
            SpikeMove(8, 1f, 0, -1);
            SpikeMove(1, 1f, 0, -1);
            SpikeMove(2, 1f, 0, -1);
            SpikeMove(3, 1f, 0, -1);
            SpikeMove(4, 1f, 0, -1);
            SpikeMove(5, 1f, 0, -1);
            SpikeMove(6, 1f, 0, -1);
            SpikeMove(7, 1f, 0, -1);
            SpikeMove(9, 1f, 0, -1);
            SpikeMove(10, 1f, 0, -1);
            SpikeMove(11, 1f, 0, -1);
            SpikeMove(12, 1f, 0, -1);
            SpikeMove(13, 1f, 0, -1);
            SpikeMove(14, 1f, 0, -1);
            return null;
        }

        #endregion

        #region 31~38s

        private Action Second31Action()
        {
            targetTime[31f] = true;
            SpikeWarn(5, 0, 1);
            SpikeWarn(6, 0, 1);
            SpikeWarn(7, 0, 1);
            SpikeWarn(8, 0, 1);
            SpikeWarn(9, 0, 1);
            return null;
        }

        private Action Second31p5Action()
        {
            targetTime[31.5f] = true;

            SpikeMove(5, 1f, 0, 1);
            SpikeMove(6, 1f, 0, 1);
            SpikeMove(7, 1f, 0, 1);
            SpikeMove(8, 1f, 0, 1);
            SpikeMove(9, 1f, 0, 1);
            return null;
        }

        private Action Second32Action()
        {
            targetTime[32f] = true;
            SpikeWarn(0, 0, 1);
            SpikeWarn(1, 0, 1);
            SpikeWarn(2, 0, 1);
            SpikeWarn(3, 0, 1);
            SpikeWarn(4, 0, 1);
            return null;
        }

        private Action Second32p5Action()
        {
            targetTime[32.5f] = true;

            SpikeMove(0, 1f, 0, 1);
            SpikeMove(1, 1f, 0, 1);
            SpikeMove(2, 1f, 0, 1);
            SpikeMove(3, 1f, 0, 1);
            SpikeMove(4, 1f, 0, 1);
            SpikeMove(5, 1f, 0, -1);
            SpikeMove(6, 1f, 0, -1);
            SpikeMove(7, 1f, 0, -1);
            SpikeMove(8, 1f, 0, -1);
            SpikeMove(9, 1f, 0, -1);
            return null;
        }

        private Action Second33Action()
        {
            targetTime[33f] = true;
            SpikeWarn(10, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeWarn(12, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeWarn(14, 0, 1);
            return null;
        }

        private Action Second33p5Action()
        {
            targetTime[33.5f] = true;

            SpikeMove(10, 1, 0, 1);
            SpikeMove(11, 1, 0, 1);
            SpikeMove(12, 1, 0, 1);
            SpikeMove(13, 1, 0, 1);
            SpikeMove(14, 1, 0, 1);
            SpikeMove(0, 1, 0, -1);
            SpikeMove(1, 1, 0, -1);
            SpikeMove(2, 1, 0, -1);
            SpikeMove(3, 1, 0, -1);
            SpikeMove(4, 1, 0, -1);
            return null;
        }

        private Action Second34Action()
        {
            targetTime[34f] = true;
            SpikeWarn(5, 0, 1);
            SpikeWarn(6, 0, 1);
            SpikeWarn(7, 0, 1);
            SpikeWarn(8, 0, 1);
            SpikeWarn(9, 0, 1);
            return null;
        }

        private Action Second34p5Action()
        {
            targetTime[34.5f] = true;

            SpikeMove(5, 1f, 0, 1);
            SpikeMove(6, 1f, 0, 1);
            SpikeMove(7, 1f, 0, 1);
            SpikeMove(8, 1f, 0, 1);
            SpikeMove(9, 1f, 0, 1);
            SpikeMove(10, 1f, 0, -1);
            SpikeMove(11, 1f, 0, -1);
            SpikeMove(12, 1f, 0, -1);
            SpikeMove(13, 1f, 0, -1);
            SpikeMove(14, 1f, 0, -1);
            return null;
        }

        private Action Second35Action()
        {
            targetTime[35f] = true;
            SpikeWarn(0, 0, 1);
            SpikeWarn(1, 0, 1);
            SpikeWarn(2, 0, 1);
            SpikeWarn(3, 0, 1);
            SpikeWarn(4, 0, 1);
            return null;
        }

        private Action Second35p5Action()
        {
            targetTime[35.5f] = true;

            SpikeMove(0, 1f, 0, 1);
            SpikeMove(1, 1f, 0, 1);
            SpikeMove(2, 1f, 0, 1);
            SpikeMove(3, 1f, 0, 1);
            SpikeMove(4, 1f, 0, 1);
            SpikeMove(5, 1f, 0, -1);
            SpikeMove(6, 1f, 0, -1);
            SpikeMove(7, 1f, 0, -1);
            SpikeMove(8, 1f, 0, -1);
            SpikeMove(9, 1f, 0, -1);
            return null;
        }

        private Action Second36Action()
        {
            targetTime[36f] = true;
            SpikeWarn(10, 0, 1);
            SpikeWarn(11, 0, 1);
            SpikeWarn(12, 0, 1);
            SpikeWarn(13, 0, 1);
            SpikeWarn(14, 0, 1);
            return null;
        }

        private Action Second36p5Action()
        {
            targetTime[36.5f] = true;

            SpikeMove(10, 1f, 0, 1);
            SpikeMove(11, 1f, 0, 1);
            SpikeMove(12, 1f, 0, 1);
            SpikeMove(13, 1f, 0, 1);
            SpikeMove(14, 1f, 0, 1);
            SpikeMove(0, 1f, 0, -1);
            SpikeMove(1, 1f, 0, -1);
            SpikeMove(2, 1f, 0, -1);
            SpikeMove(3, 1f, 0, -1);
            SpikeMove(4, 1f, 0, -1);
            return null;
        }

        private Action Second37p5Action()
        {
            targetTime[37.5f] = true;

            SpikeMove(10, 1f, 0, -1);
            SpikeMove(11, 1f, 0, -1);
            SpikeMove(12, 1f, 0, -1);
            SpikeMove(13, 1f, 0, -1);
            SpikeMove(14, 1f, 0, -1);
            return null;
        }

        #endregion

        #region 38~42s

        private Action Second39p5Action()
        {
            targetTime[39.5f] = true;
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
            SpikeFlash2(7, 0, -4);
            SpikeScale(7, 0.5f, 2, 2);
            return null;
        }

        private Action Second40Action()
        {
            targetTime[40f] = true;
            SpikeMove(0, 2f, 0, 6);
            SpikeMove(1, 2f, 0, 6);
            SpikeMove(2, 2f, 0, 6);
            SpikeMove(3, 2f, 0, 6);
            SpikeMove(4, 2f, 0, 6);
            SpikeMove(7, 2f, 0, 10);
            SpikeMove(10, 2f, 0, 6);
            SpikeMove(11, 2f, 0, 6);
            SpikeMove(12, 2f, 0, 6);
            SpikeMove(13, 2f, 0, 6);
            SpikeMove(14, 2f, 0, 6);
            return null;
        }

        #endregion
    }
}