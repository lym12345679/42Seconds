using System;
using System.Collections.Generic;
using Game.Traps;
using MizukiTool.UIEffect;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Game.Level
{
    public class TestLevel0 : LevelBehaviorTree
    {
        #region bool值

        #region Stage1 3~5s

        private bool seconds3 = false; // 用于标记是否经过3秒
        private bool seconds3p25 = false; // 用于标记是否经过3.25秒
        private bool seconds3p5 = false; // 用于标记是否经过3.5秒
        private bool seconds3p75 = false; // 用于标记是否经过3.75秒
        private bool seconds4 = false; // 用于标记是否经过4秒
        private bool seconds4p25 = false; // 用于标记是否经过4.25秒
        private bool seconds4p5 = false; // 用于标记是否经过5秒
        private bool seconds4p75 = false; // 用于标记是否经过4.75秒

        #endregion

        #region Stage2 7~10s

        private bool seconds7 = false; // 用于标记是否经过7秒
        private bool seconds8 = false; // 用于标记是否经过8秒
        private bool seconds9 = false; // 用于标记是否经过9秒

        #endregion

        #region Stage3 11s~15s

        private bool seconds11 = false; // 用于标记是否经过11秒
        private bool seconds12 = false; // 用于标记是否经过12秒
        private bool seconds13 = false; // 用于标记是否经过13秒
        private bool seconds14 = false; // 用于标记是否经过14秒
        private bool seconds14p75 = false; // 用于标记是否经过14.75秒

        #endregion

        #region Stage4 15s~17s

        private bool seconds15 = false; // 用于标记是否经过15秒
        private bool seconds15p25 = false; // 用于标记是否经过15.25秒
        private bool seconds15p5 = false; // 用于标记是否经过15.5秒
        private bool seconds15p75 = false; // 用于标记是否经过15.75秒
        private bool seconds16 = false; // 用于标记是否经过16秒
        private bool seconds16p25 = false; // 用于标记是否经过16.25秒
        private bool seconds16p5 = false; // 用于标记是否经过16.5秒
        private bool seconds16p75 = false; // 用于标记是否经过16.75秒

        #endregion

        #region Stage5 17s~22s

        private bool seconds17 = false; // 用于标记是否经过17秒
        private bool seconds17p25 = false; // 用于标记是否经过17.25秒
        private bool seconds17p5 = false; // 用于标记是否经过17.5秒
        private bool seconds17p75 = false; // 用于标记是否经过17.75秒
        private bool seconds18 = false; // 用于标记是否经过18秒
        private bool seconds18p25 = false; // 用于标记是否经过18.25秒
        private bool seconds18p5 = false; // 用于标记是否经过18.5秒
        private bool seconds19 = false; // 用于标记是否经过18.75秒
        private bool seconds20p5 = false; // 用于标记是否经过20.5秒

        #endregion

        #region Stage6 22s~32s

        private bool seconds22 = false; // 用于标记是否经过22秒
        private bool seconds23 = false; // 用于标记是否经过23秒
        private bool seconds24 = false; // 用于标记是否经过24秒
        private bool seconds25 = false; // 用于标记是否经过25秒
        private bool seconds26 = false; // 用于标记是否经过26秒
        private bool seconds27 = false; // 用于标记是否经过27秒
        private bool seconds28 = false; // 用于标记是否经过28秒
        private bool seconds29 = false; // 用于标记是否经过29秒
        private bool seconds30 = false; // 用于标记是否经过30秒
        private bool seconds31 = false; // 用于标记是否经过31秒
        private bool seconds32 = false; // 用于标记是否经过32秒

        #endregion

        #region 33s~38s

        private bool seconds33 = false; // 用于标记是否经过33秒
        private bool seconds34 = false; // 用于标记是否经过34秒
        private bool seconds35 = false; // 用于标记是否经过35秒
        private bool seconds36 = false; // 用于标记是否经过36秒
        private bool seconds37 = false; // 用于标记是否经过37秒
        private bool seconds38 = false; // 用于标记是否经过38秒

        #endregion

        #region Stage7 39s~42s

        private bool seconds39 = false; // 用于标记是否经过39秒

        #endregion

        #endregion

        protected override void InitializeBehaviorTree()
        {
            base.InitializeBehaviorTree();
            Debug.Log("TestLevel0 Behavior Tree Initialized");
            // 在这里设置 TestLevel0 的特定行为树节点
        }

        protected override Action GetAction()
        {
            return Selector(
                () => Condition(currentTime >= 3f && currentTime < 5f,
                    () => Selector(
                        () => Condition(!seconds3, () => { return Second3Action(); }),
                        () => Condition(currentTime > 3.25f && seconds3 && !seconds3p25,
                            () => { return Second3p25Action(); }),
                        () => Condition(currentTime > 3.5f && seconds3p25 && !seconds3p5,
                            () => { return Second3p5Action(); }),
                        () => Condition(currentTime > 3.75f && seconds3p5 && !seconds3p75,
                            () => { return Second3p75Action(); }),
                        () => Condition(currentTime > 4f && seconds3p75 && !seconds4,
                            () => { return Second4Action(); }),
                        () => Condition(currentTime > 4.25f && seconds4 && !seconds4p25,
                            () => { return Second4p25Action(); }),
                        () => Condition(currentTime > 4.5f && seconds4p25 && !seconds4p5,
                            () => { return Second4p5Action(); }),
                        () => Condition(currentTime > 4.75f && seconds4p5 && !seconds4p75,
                            () => { return Second4p75Action(); })
                    )),
                () => Condition(currentTime >= 7f && currentTime < 10f,
                    () => Selector(
                        () => Condition(!seconds7, () => { return Second7Action(); }),
                        () => Condition(currentTime > 8f && seconds7 && !seconds8, () => { return Second8Action(); }),
                        () => Condition(currentTime > 9f && seconds8 && !seconds9, () => { return Second9Action(); })
                    )),
                () => Condition(currentTime >= 11f && currentTime < 12f,
                    () => Selector(
                        () => Condition(!seconds11, () => { return Second11Action(); })
                    )),
                () => Condition(currentTime >= 12f && currentTime < 13f,
                    () => Selector(
                        () => Condition(!seconds12, () => { return Second12Action(); })
                    )),
                () => Condition(currentTime >= 13f && currentTime < 15f,
                    () => Selector(
                        () => Condition(!seconds13, () => { return Second13Action(); }),
                        () => Condition(currentTime > 14f && seconds13 && !seconds14,
                            () => { return Second14Action(); }),
                        () => Condition(currentTime > 14.75f && seconds14 && !seconds14p75,
                            () => { return Second14p75Action(); })
                    )),
                () => Condition(currentTime >= 15f && currentTime < 17f,
                    () => Selector(
                        () => Condition(!seconds15, () => { return Second15Action(); }),
                        () => Condition(currentTime > 15.25f && seconds15 && !seconds15p25,
                            () => { return Second15p25Action(); }),
                        () => Condition(currentTime > 15.5f && seconds15p25 && !seconds15p5,
                            () => { return Second15p5Action(); }),
                        () => Condition(currentTime > 15.75f && seconds15p5 && !seconds15p75,
                            () => { return Second15p75Action(); }),
                        () => Condition(currentTime > 16f && seconds15p75 && !seconds16,
                            () => { return Second16Action(); }),
                        () => Condition(currentTime > 16.25f && seconds16 && !seconds16p25,
                            () => { return Second16p25Action(); }),
                        () => Condition(currentTime > 16.5f && seconds16p25 && !seconds16p5,
                            () => { return Second16p5Action(); }),
                        () => Condition(currentTime > 16.75f && seconds16p5 && !seconds16p75,
                            () => { return Second16p75Action(); })
                    )),
                () => Condition(currentTime >= 17f && currentTime < 22f,
                    () => Selector(
                        () => Condition(!seconds17, () => { return Second17Action(); }),
                        () => Condition(currentTime > 17.25f && seconds17 && !seconds17p25,
                            () => { return Second17p25Action(); }),
                        () => Condition(currentTime > 17.5f && seconds17p25 && !seconds17p5,
                            () => { return Second17p5Action(); }),
                        () => Condition(currentTime > 17.75f && seconds17p5 && !seconds17p75,
                            () => { return Second17p75Action(); }),
                        () => Condition(currentTime > 18f && seconds17p75 && !seconds18,
                            () => { return Second18Action(); }),
                        () => Condition(currentTime > 18.25f && seconds18 && !seconds18p25,
                            () => { return Second18p25Action(); }),
                        () => Condition(currentTime > 18.5f && seconds18p25 && !seconds18p5,
                            () => { return Second18p5Action(); }),
                        () => Condition(currentTime > 19f && seconds18p5 && !seconds19,
                            () => { return Second19Action(); }),
                        () => Condition(currentTime > 20.5f && seconds19 && !seconds20p5,
                            () => { return Second20p5Action(); })
                    )),
                () => Condition(currentTime >= 22f && currentTime < 34f,
                    () => Selector(
                        () => Condition(!seconds22, () => { return Second22Action(); }),
                        () => Condition(currentTime > 23f && seconds22 && !seconds23,
                            () => { return Second23Action(); }),
                        () => Condition(currentTime > 24f && seconds23 && !seconds24,
                            () => { return Second24Action(); }),
                        () => Condition(currentTime > 25f && seconds24 && !seconds25,
                            () => { return Second25Action(); }),
                        () => Condition(currentTime > 26f && seconds25 && !seconds26,
                            () => { return Second26Action(); }),
                        () => Condition(currentTime > 27f && seconds26 && !seconds27,
                            () => { return Second27Action(); }),
                        () => Condition(currentTime > 28f && seconds27 && !seconds28,
                            () => { return Second28Action(); }),
                        () => Condition(currentTime > 29f && seconds28 && !seconds29,
                            () => { return Second29Action(); }),
                        () => Condition(currentTime > 30f && seconds29 && !seconds30,
                            () => { return Second30Action(); }),
                        () => Condition(currentTime > 31f && seconds30 && !seconds31,
                            () => { return Second31Action(); }),
                        () => Condition(currentTime > 32f && seconds31 && !seconds32,
                            () => { return Second32Action(); })
                    )),
                () => Condition(currentTime >= 33f && currentTime < 39f,
                    () => Selector(
                        () => Condition(!seconds33, () => { return Second33Action(); }),
                        () => Condition(currentTime > 34f && seconds33 && !seconds34,
                            () => { return Second34Action(); }),
                        () => Condition(currentTime > 35f && seconds34 && !seconds35,
                            () => { return Second35Action(); }),
                        () => Condition(currentTime > 36f && seconds35 && !seconds36,
                            () => { return Second36Action(); }),
                        () => Condition(currentTime > 37f && seconds36 && !seconds37,
                            () => { return Second37Action(); }),
                        () => Condition(currentTime > 38f && seconds37 && !seconds38,
                            () => { return Second38Action(); })
                    )),
                () => Condition(currentTime >= 39f && currentTime < 43f,
                    () => Selector(
                        () => Condition(!seconds39, () => { return Second39Action(); })
                    ))
            );
        }

        #region Stage1 3~5s

        private Action Second3Action()
        {
            Debug.Log(spikeList.Count + " spikes in the list");
            Stage1Move(0); // 移动第一个尖刺
            Stage1Move(14); // 移动第16个尖刺
            seconds3 = true; // 设置经过3秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second3p25Action()
        {
            Stage1Move(1); // 移动第二个尖刺
            Stage1Move(13); // 移动第15个尖刺
            seconds3p25 = true; // 设置经过3.25秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second3p5Action()
        {
            Stage1Move(2); // 移动第三个尖刺
            Stage1Move(12); // 移动第14个尖刺
            seconds3p5 = true; // 设置经过3.5秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second3p75Action()
        {
            //Debug.Log("3.75 seconds passed");
            Stage1Move(3); // 移动第四个尖刺
            Stage1Move(11); // 移动第13个尖刺
            seconds3p75 = true; // 设置经过3.75秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second4Action()
        {
            //Debug.Log("4 seconds passed");
            Stage1Move(4); // 移动第五个尖刺
            Stage1Move(10); // 移动第12个尖刺
            seconds4 = true; // 设置经过4秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second4p25Action()
        {
            //Debug.Log("4.25 seconds passed");
            Stage1Move(5); // 移动第六个尖刺
            Stage1Move(9); // 移动第11个尖刺
            seconds4p25 = true; // 设置经过4.25秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second4p5Action()
        {
            //Debug.Log("4.5 seconds passed");
            Stage1Move(6); // 移动第七个尖刺
            Stage1Move(8); // 移动第十个尖刺
            seconds4p5 = true; // 设置经过4.5秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second4p75Action()
        {
            //Debug.Log("4.75 seconds passed");
            Stage1Move(7);
            seconds4p75 = true; // 设置经过4.75秒的标志
            return null; // 返回一个空的动作
        }

        private void Stage1Move(int n)
        {
            spikeList[n].Move(new Vector2(0, 1), 0.5f, PositionEffectMode.PingPong, SpikePersentageHanderEnum.X2,
                (e) => { e.Stop(); });
        }

        #endregion

        #region Stage2 7~10s

        private Action Second7Action()
        {
            //Debug.Log("7 seconds passed");
            Stage2Move1(6);
            Stage2Move1(7);
            Stage2Move1(8);
            seconds7 = true; // 设置经过7秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second8Action()
        {
            Stage2Move1(3);
            Stage2Move1(4);
            Stage2Move1(10);
            Stage2Move1(11);

            Stage2Move2(6);
            Stage2Move2(7);
            Stage2Move2(8);
            seconds8 = true; // 设置经过8秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second9Action()
        {
            Stage2Move1(0);
            Stage2Move1(1);
            Stage2Move1(13);
            Stage2Move1(14);
            Stage2Move2(3);
            Stage2Move2(4);
            Stage2Move2(10);
            Stage2Move2(11);
            seconds9 = true; // 设置经过9秒的标志
            return null; // 返回一个空的动作
        }

        private void Stage2Move1(int n)
        {
            spikeList[n].Move(new Vector2(0, 1), 0.5f);
        }

        private void Stage2Move2(int n)
        {
            spikeList[n].Move(new Vector2(0, -1), 0.5f);
        }

        #endregion

        #region Stage3 11s~12s

        private Action Second11Action()
        {
            Stage3Move1(0);
            Stage3Move1(1);
            Stage3Move2(13);
            Stage3Move2(14);
            seconds11 = true; // 设置经过11秒的标志
            // 在这里添加11秒时的动作
            return null; // 返回一个空的动作
        }

        private void Stage3Move1(int n)
        {
            spikeList[n].Move(new Vector2(6, 0), 0.5f);
        }

        private void Stage3Move2(int n)
        {
            spikeList[n].Move(new Vector2(-6, 0), 0.5f);
        }

        #endregion

        #region Stage4 12~13s

        private Action Second12Action()
        {
            //Debug.Log("12 seconds passed");
            Stage4Move1(2);
            Stage4Move1(3);
            Stage4Move1(4);
            Stage4Move1(5);
            Stage4Move1(9);
            Stage4Move1(10);
            Stage4Move1(11);
            Stage4Move1(12);
            seconds12 = true; // 设置经过12秒的标志

            // 在这里添加12秒时的动作
            return null; // 返回一个空的动作
        }

        private void Stage4Move1(int n)
        {
            spikeList[n].Move(new Vector2(0, 1), 0.5f);
        }

        #endregion

        #region Stage5 13s~15s

        private Action Second13Action()
        {
            //Debug.Log("13 seconds passed");

            Stage5Move1(0);
            Stage5Move1(1);
            Stage5Move1(13);
            Stage5Move1(14);
            Stage5Move2(2);
            Stage5Move2(3);
            Stage5Move2(4);
            Stage5Move2(5);
            Stage5Move3(9);
            Stage5Move3(10);
            Stage5Move3(11);
            Stage5Move3(12);

            seconds13 = true; // 设置经过13秒的标志

            // 在这里添加13秒时的动作
            return null; // 返回一个空的动作
        }

        private Action Second14Action()
        {
            //Debug.Log("14 seconds passed");
            Stage5Move1(2);
            Stage5Move1(3);
            Stage5Move1(4);
            Stage5Move1(5);
            Stage5Move1(9);
            Stage5Move1(10);
            Stage5Move1(11);
            Stage5Move1(12);
            seconds14 = true; // 设置经过14秒的标志

            // 在这里添加14秒时的动作
            return null; // 返回一个空的动作
        }

        private Action Second14p75Action()
        {
            //Debug.Log("14.75 seconds passed");
            Stage5Flash(0);
            Stage5Flash(1);
            Stage5Flash(2);
            Stage5Flash(3);
            Stage5Flash(4);
            Stage5Flash(5);
            Stage5Flash(6);
            Stage5Flash(7);
            Stage5Flash(8);
            Stage5Flash(9);
            Stage5Flash(10);
            Stage5Flash(11);
            Stage5Flash(12);
            Stage5Flash(13);
            Stage5Flash(14);
            seconds14p75 = true; // 设置经过14.75秒的标志

            // 在这里添加14.75秒时的动作
            return null; // 返回一个空的动作
        }

        private void Stage5Move1(int n)
        {
            spikeList[n].Move(new Vector2(0, -1), 0.5f);
        }

        private void Stage5Move2(int n)
        {
            spikeList[n].Move(new Vector2(-2, 0), 0.5f);
        }

        private void Stage5Move3(int n)
        {
            spikeList[n].Move(new Vector2(2, 0), 0.5f);
        }

        private void Stage5Flash(int n)
        {
            spikeList[n].Flash(new Vector2(n, 0));
        }

        #endregion

        #region Stage6 15s~17s

        private Action Second15Action()
        {
            //Debug.Log("15 seconds passed");
            Stage6Move1(0);
            Stage6Move1(14);
            seconds15 = true; // 设置经过15秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second15p25Action()
        {
            //Debug.Log("15.25 seconds passed");
            Stage6Move1(1);
            Stage6Move1(13);
            seconds15p25 = true; // 设置经过15.25秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second15p5Action()
        {
            //Debug.Log("15.5 seconds passed");
            Stage6Move1(2);
            Stage6Move1(12);
            seconds15p5 = true; // 设置经过15.5秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second15p75Action()
        {
            //Debug.Log("15.75 seconds passed");
            Stage6Move1(3);
            Stage6Move1(11);
            seconds15p75 = true; // 设置经过15.75秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second16Action()
        {
            //Debug.Log("16 seconds passed");
            Stage6Move1(4);
            Stage6Move1(10);
            seconds16 = true; // 设置经过16秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second16p25Action()
        {
            //Debug.Log("16.25 seconds passed");
            Stage6Move1(5);
            Stage6Move1(9);
            seconds16p25 = true; // 设置经过16.25秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second16p5Action()
        {
            //Debug.Log("16.5 seconds passed");
            Stage6Move2(6);
            Stage6Move2(8);
            seconds16p5 = true; // 设置经过16.5秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second16p75Action()
        {
            //Debug.Log("16.75 seconds passed");
            Stage6Move2(7);
            seconds16p75 = true; // 设置经过16.75秒的标志
            return null; // 返回一个空的动作
        }

        private void Stage6Move1(int n)
        {
            spikeList[n].Move(new Vector2(0, 1), 0.5f, PositionEffectMode.PingPong, SpikePersentageHanderEnum.X,
                (e) => { e.Stop(); });
        }

        private void Stage6Move2(int n)
        {
            spikeList[n].Move(new Vector2(0, 1), 0.5f);
        }

        #endregion

        #region Stage7 17s~22s

        private Action Second17Action()
        {
            //Debug.Log("17 seconds passed");
            Stage7Move1(0);
            Stage7Move1(14);
            seconds17 = true; // 设置经过17秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second17p25Action()
        {
            //Debug.Log("17.25 seconds passed");
            Stage7Move1(1);
            Stage7Move1(13);
            seconds17p25 = true; // 设置经过17.25秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second17p5Action()
        {
            //Debug.Log("17.5 seconds passed");
            Stage7Move1(2);
            Stage7Move1(12);
            Stage7Move2(0);
            seconds17p5 = true; // 设置经过17.5秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second17p75Action()
        {
            //Debug.Log("17.75 seconds passed");
            Stage7Move1(10);
            Stage7Move1(11);
            Stage7Move2(6);
            Stage7Move2(7);
            Stage7Move2(8);
            seconds17p75 = true; // 设置经过17.75秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second18Action()
        {
            //Debug.Log("18 seconds passed");
            Stage7Move1(3);
            Stage7Move1(4);
            seconds18 = true; // 设置经过18秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second18p25Action()
        {
            //Debug.Log("18.25 seconds passed");
            Stage7Move1(5);
            Stage7Move1(9);
            seconds18p25 = true; // 设置经过18.25秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second18p5Action()
        {
            //Debug.Log("18.5 seconds passed");
            Stage7Move1(6);
            Stage7Move1(7);
            seconds18p5 = true; // 设置经过18.5秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second19Action()
        {
            //Debug.Log("18.75 seconds passed");
            Stage7Move3(8);
            seconds19 = true; // 设置经过18.75秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second20p5Action()
        {
            //Debug.Log("20.5 seconds passed");
            Stage7Move2(1);
            Stage7Move2(2);
            Stage7Move2(3);
            Stage7Move2(4);
            Stage7Move2(5);
            Stage7Move2(6);
            Stage7Move2(7);
            Stage7Move2(8);
            Stage7Move2(9);
            Stage7Move2(10);
            Stage7Move2(11);
            Stage7Move2(12);
            Stage7Move2(13);
            Stage7Move2(14);
            seconds20p5 = true; // 设置经过20.5秒的标志
            return null; // 返回一个空的动作
        }

        private void Stage7Move1(int n)
        {
            spikeList[n].Move(new Vector2(0, 1), 0.5f);
        }

        private void Stage7Move2(int n)
        {
            spikeList[n].Move(new Vector2(0, -1), 0.5f);
        }

        private void Stage7Move3(int n)
        {
            spikeList[n].Move(new Vector2(0, 1), 1f);
        }

        #endregion

        #region Stage8 22s~34s

        private Action Second22Action()
        {
            //Debug.Log("22 seconds passed");
            Stage8Move1(5);
            Stage8Move1(6);
            Stage8Move1(7);
            Stage8Move1(8);
            Stage8Move1(9);
            seconds22 = true; // 设置经过22秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second23Action()
        {
            //Debug.Log("23 seconds passed");
            Stage8Move1(0);
            Stage8Move1(1);
            Stage8Move1(2);
            Stage8Move1(3);
            Stage8Move1(4);
            seconds23 = true; // 设置经过23秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second24Action()
        {
            //Debug.Log("24 seconds passed");
            Stage8Move2(5);
            Stage8Move2(6);
            Stage8Move2(7);
            Stage8Move2(8);
            Stage8Move2(9);
            seconds24 = true; // 设置经过24秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second25Action()
        {
            //Debug.Log("25 seconds passed");
            Stage8Move1(10);
            Stage8Move1(11);
            Stage8Move1(12);
            Stage8Move1(13);
            Stage8Move1(14);
            seconds25 = true; // 设置经过25秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second26Action()
        {
            //Debug.Log("26 seconds passed");
            Stage8Move2(0);
            Stage8Move2(1);
            Stage8Move2(2);
            Stage8Move2(3);
            Stage8Move2(4);
            seconds26 = true; // 设置经过26秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second27Action()
        {
            //Debug.Log("27 seconds passed");
            Stage8Move1(0);
            Stage8Move1(1);
            Stage8Move1(2);
            Stage8Move1(3);
            Stage8Move1(4);
            seconds27 = true; // 设置经过27秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second28Action()
        {
            //Debug.Log("28 seconds passed");
            Stage8Move2(10);
            Stage8Move2(11);
            Stage8Move2(12);
            Stage8Move2(13);
            Stage8Move2(14);
            seconds28 = true; // 设置经过28秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second29Action()
        {
            //Debug.Log("29 seconds passed");
            Stage8Move1(10);
            Stage8Move1(11);
            Stage8Move1(12);
            Stage8Move1(13);
            Stage8Move1(14);
            seconds29 = true; // 设置经过29秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second30Action()
        {
            //Debug.Log("30 seconds passed");
            Stage8Move2(0);
            Stage8Move2(1);
            Stage8Move2(2);
            Stage8Move2(3);
            Stage8Move2(4);
            seconds30 = true; // 设置经过30秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second31Action()
        {
            //Debug.Log("31 seconds passed");
            Stage8Move1(5);
            Stage8Move1(6);
            Stage8Move1(7);
            Stage8Move1(8);
            Stage8Move1(9);
            seconds31 = true; // 设置经过31秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second32Action()
        {
            //Debug.Log("32 seconds passed");
            Stage8Move2(5);
            Stage8Move2(6);
            Stage8Move2(7);
            Stage8Move2(8);
            Stage8Move2(9);
            Stage8Move2(10);
            Stage8Move2(11);
            Stage8Move2(12);
            Stage8Move2(13);
            Stage8Move2(14);
            seconds32 = true; // 设置经过32秒的标志
            return null; // 返回一个空的动作
        }

        private void Stage8Move1(int n)
        {
            spikeList[n].Move(new Vector2(0, 1), 1f);
        }

        private void Stage8Move2(int n)
        {
            spikeList[n].Move(new Vector2(0, -1), 1f);
        }

        #endregion

        #region 33s~38s

        private Action Second33Action()
        {
            //Debug.Log("33 seconds passed");
            Stage9Move1(0);
            Stage9Move1(1);
            Stage9Move1(2);
            seconds33 = true; // 设置经过33秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second34Action()
        {
            //Debug.Log("34 seconds passed");
            Stage9Move1(3);
            Stage9Move1(4);
            Stage9Move1(5);
            seconds34 = true; // 设置经过34秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second35Action()
        {
            //Debug.Log("35 seconds passed");
            Stage9Move1(6);
            Stage9Move1(7);
            Stage9Move1(8);
            Stage9Move2(0);
            Stage9Move2(1);
            Stage9Move2(2);
            seconds35 = true; // 设置经过35秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second36Action()
        {
            //Debug.Log("36 seconds passed");
            Stage9Move1(9);
            Stage9Move1(10);
            Stage9Move1(11);
            Stage9Move2(3);
            Stage9Move2(4);
            Stage9Move2(5);
            seconds36 = true; // 设置经过36秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second37Action()
        {
            //Debug.Log("37 seconds passed");
            Stage9Move1(12);
            Stage9Move1(13);
            Stage9Move1(14);
            Stage9Move2(6);
            Stage9Move2(7);
            Stage9Move2(8);
            seconds37 = true; // 设置经过37秒的标志
            return null; // 返回一个空的动作
        }

        private Action Second38Action()
        {
            //Debug.Log("38 seconds passed");
            Stage9Move2(9);
            Stage9Move2(10);
            Stage9Move2(11);
            Stage9Move2(12);
            Stage9Move2(13);
            Stage9Move2(14);
            Stage9Scale(5);
            Stage9Flash(5);
            seconds38 = true; // 设置经过38秒的标志
            return null; // 返回一个空的动作
        }

        private void Stage9Move1(int n)
        {
            spikeList[n].Move(new Vector2(0, 1), 1f);
        }

        private void Stage9Move2(int n)
        {
            spikeList[n].Move(new Vector2(0, -1), 1f);
        }

        private void Stage9Flash(int n)
        {
            spikeList[n].Flash(new Vector2(7, -6));
        }

        private void Stage9Scale(int n)
        {
            spikeList[n].Scale(new Vector2(3, 3), 1f);
        }

        #endregion

        #region 39S~42s

        private Action Second39Action()
        {
            //Debug.Log("39 seconds passed");
            Stage10Move1(0);
            Stage10Move1(1);
            Stage10Move1(2);
            Stage10Move1(3);
            Stage10Move1(4);
            Stage10Move1(10);
            Stage10Move1(11);
            Stage10Move1(12);
            Stage10Move1(13);
            Stage10Move1(14);
            Stage10Move2(5);
            seconds39 = true; // 设置经过39秒的标志
            return null; // 返回一个空的动作
        }

        private void Stage10Move1(int n)
        {
            spikeList[n].Move(new Vector2(0, 4), 1f);
        }

        private void Stage10Move2(int n)
        {
            spikeList[n].Move(new Vector2(0, 8), 1f);
        }

        #endregion
    }
}