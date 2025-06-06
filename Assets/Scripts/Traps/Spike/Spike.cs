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
        public SpikeEffectController spikeEffectController; // 控制尖刺效果的脚本
        private Vector3 currentPosition;

        private float currentTime
        {
            get { return LevelManager.Instance.CurrentTime; } // 获取当前时间
        } // 当前时间

        public override void OnPlayerEnter(PlayerController playerController, Vector2 position)
        {
            playerController.OnPlayerDeath();
        }

        public override void OnPlayerSprintInToTrap(PlayerController playerController, Vector2 position)
        {
            playerController.OnPlayerDeath();
        }

        #region 行动脚本

        public void Move(Vector2 vector, float timeToMove,
            PositionEffectMode positionEffectMode = PositionEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<PositionEffect> endHandler = null)
        {
            if (spikeEffectController != null)
            {
                spikeEffectController.SetGeneralPositionEffect(vector, timeToMove, positionEffectMode,
                    persentageHanderEnum, endHandler);
                spikeEffectController.StartPositionEffect();
            }
        }

        public void Rotate(float rotation, float timeToRotate,
            RotationEffectMode rotationEffectMode = RotationEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<RotationEffect> endHandler = null)
        {
            if (spikeEffectController != null)
            {
                spikeEffectController.SetGeneralRotationEffect(rotation, timeToRotate, rotationEffectMode,
                    persentageHanderEnum, endHandler);
                spikeEffectController.StartRotationEffect();
            }
        }

        public void Scale(Vector2 scale, float timeToScale, ScaleEffectMode scaleEffectMode = ScaleEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<ScaleEffect> endHandler = null)
        {
            if (spikeEffectController != null)
            {
                spikeEffectController.SetGeneralScaleEffect(scale, timeToScale, scaleEffectMode,
                    persentageHanderEnum, endHandler);
                spikeEffectController.StartScaleEffect();
            }
        }

        public void Flash(Vector2 position)
        {
            transform.localPosition = position;
        }

        #endregion
    }
}