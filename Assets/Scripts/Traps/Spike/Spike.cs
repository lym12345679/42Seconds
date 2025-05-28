using System;
using System.Collections;
using System.Collections.Generic;
using Game.Level;
using MizukiTool.UIEffect;
using UnityEngine;
namespace Game.Traps
{
    public class Spike : Trap
    {
        public SpikeMessageListSO spikeMessageListSO; // 存储尖刺的位移、旋转和缩放信息
        public SpikeEffectController spikeEffectController; // 控制尖刺效果的脚本
        private List<SpikeMessageSOWithTime> spikeMessages = new List<SpikeMessageSOWithTime>(); // 存储尖刺的位移、旋转和缩放信息列表
        private Vector3 currentPosition;
        private float currentTime
        {
            get { return LevelManager.Instance.currentTime; } // 获取当前时间
        } // 当前时间
        void Awake()
        {
            if (spikeMessageListSO != null)
            {
                spikeMessages = spikeMessageListSO.SpikeMessages.ConvertAll(message => new SpikeMessageSOWithTime
                {
                    StartTime = message.StartTime,
                    SpikeMessage = new SpikeMessageSO
                    {
                        Name = message.Name,
                        IsMove = message.SpikeMessage.IsMove,
                        IsRotate = message.SpikeMessage.IsRotate,
                        IsScale = message.SpikeMessage.IsScale,
                        IsFlash = message.SpikeMessage.IsFlash,
                        Vector = message.SpikeMessage.Vector,
                        Rotation = message.SpikeMessage.Rotation,
                        Scale = message.SpikeMessage.Scale,
                        Flash = message.SpikeMessage.Flash,
                    },
                }); // 将SO中的消息转换为列表
            }
            if (spikeEffectController != null)
            {
                spikeEffectController.Init(); // 初始化尖刺效果控制器
            }
            else
            {
                Debug.LogError("SpikeEffectController is not assigned in Spike script.");
            }
        }
        void Update()
        {
            for (int i = 0; i < spikeMessages.Count; i++)
            {
                SpikeMessageSOWithTime spikeMessage = spikeMessages[i];
                if (spikeMessage.StartTime <= currentTime)
                {
                    // 如果时间到了，就开始执行效果
                    StartEffect(spikeMessage.SpikeMessage);
                    Debug.Log("启动:" + spikeMessage.Name + "效果，应开始时间：" + spikeMessage.StartTime + " 当前时间：" + currentTime);
                    // 从列表中移除已执行的消息
                    spikeMessages.RemoveAt(i);
                    i--; // 调整索引以避免跳过下一个元素
                }
            }
        }
        private void StartEffect(SpikeMessageSO spikeMessage)
        {
            // 设置尖刺的闪现效果
            if (spikeMessage.IsFlash)
            {
                this.transform.position = spikeMessage.Flash.Position; // 直接设置位置
            }
            if (spikeEffectController != null)
            {
                // 设置尖刺的位移效果
                if (spikeMessage.IsMove)
                {
                    /*Action<PositionEffect> endHandler = (e) =>
                    {
                        Debug.Log("尖刺效果结束: " + spikeMessage.Name + " 当前时间 " + currentTime);
                    };*/
                    spikeEffectController.SetGeneralPositionEffect(spikeMessage.Vector.Vector, spikeMessage.Vector.Duration);
                }
                if (spikeMessage.IsRotate)
                {
                    // 设置尖刺的旋转效果
                    spikeEffectController.SetGeneralRotationEffect(spikeMessage.Rotation.Rotation, spikeMessage.Rotation.Duration);
                }
                if (spikeMessage.IsScale)
                {
                    // 设置尖刺的缩放效果
                    spikeEffectController.SetGeneralScaleEffect(spikeMessage.Scale.Scale, spikeMessage.Scale.Duration);
                }
                // 启动效果
                spikeEffectController.StartEffect();
            }
            else
            {
                Debug.LogError("SpikeEffectController is not assigned in Spike script.");
            }
        }
    }
}
