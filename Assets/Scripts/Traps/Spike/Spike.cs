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
            get { return LevelManager.Instance.CurrentTime; } // 获取当前时间
        } // 当前时间

        public void Move(Vector2 vector, float timeToMove, PositionEffectMode positionEffectMode = PositionEffectMode.Once, SpikePersentageHanderEnum spikePersentageHanderEnum = SpikePersentageHanderEnum.X, Action<PositionEffect> endHandler = null)
        {
            if (spikeEffectController != null)
            {
                spikeEffectController.SetGeneralPositionEffect(vector, timeToMove, positionEffectMode, spikePersentageHanderEnum, endHandler);
                spikeEffectController.StartPositionEffect();
            }

        }
        public void Rotate(float rotation, float timeToRotate, RotationEffectMode rotationEffectMode = RotationEffectMode.Once, SpikePersentageHanderEnum spikePersentageHanderEnum = SpikePersentageHanderEnum.X, Action<RotationEffect> endHandler = null)
        {
            if (spikeEffectController != null)
            {
                spikeEffectController.SetGeneralRotationEffect(rotation, timeToRotate, rotationEffectMode, spikePersentageHanderEnum, endHandler);
                spikeEffectController.StartRotationEffect();
            }
        }
        public void Scale(Vector2 scale, float timeToScale, ScaleEffectMode scaleEffectMode = ScaleEffectMode.Once, SpikePersentageHanderEnum spikePersentageHanderEnum = SpikePersentageHanderEnum.X, Action<ScaleEffect> endHandler = null)
        {
            if (spikeEffectController != null)
            {
                spikeEffectController.SetGeneralScaleEffect(scale, timeToScale, scaleEffectMode, spikePersentageHanderEnum, endHandler);
                spikeEffectController.StartScaleEffect();
            }
        }
        public void Flash(Vector2 position)
        {
            transform.position = position;
        }
    }
}
