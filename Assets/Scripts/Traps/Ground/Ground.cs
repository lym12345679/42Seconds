using System;
using System.Collections;
using System.Collections.Generic;
using Game.Level;
using Game.Recycle;
using MizukiTool.UIEffect;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Traps
{
    public class Ground : Trap
    {
        public GroundEffectController controller; // 控制尖刺效果的脚本
        private Vector3 currentPosition;

        private float currentTime
        {
            get { return LevelManager.Instance.CurrentTime; } // 获取当前时间
        } // 当前时间

        public override void OnPlayerEnter(PlayerController playerController, Vector2 position)
        {
        }

        public override void OnPlayerSprintInToTrap(PlayerController playerController, Vector2 position)
        {
        }

        #region 行动脚本

        public void Move(Vector2 vector, float timeToMove,
            PositionEffectMode positionEffectMode = PositionEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<PositionEffect> endHandler = null)
        {
            if (controller != null)
            {
                controller.SetGeneralPositionEffect(vector, timeToMove, positionEffectMode,
                    persentageHanderEnum, endHandler);
                controller.StartPositionEffect();
            }
        }

        public void Rotate(float rotation, float timeToRotate,
            RotationEffectMode rotationEffectMode = RotationEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<RotationEffect> endHandler = null)
        {
            if (controller != null)
            {
                controller.SetGeneralRotationEffect(rotation, timeToRotate, rotationEffectMode,
                    persentageHanderEnum, endHandler);
                controller.StartRotationEffect();
            }
        }

        public void Rotate(float rotation, float timeToRotate, Vector2 point,
            RotationEffectMode rotationEffectMode = RotationEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X)
        {
            if (controller != null)
            {
                controller.SetGeneralRotationEffect(rotation, timeToRotate, rotationEffectMode,
                    persentageHanderEnum, (r) =>
                    {
                        Vector3 endChildPos = controller.child.position;
                        transform.position = endChildPos;
                        controller.child.position = endChildPos;
                    });
                controller.StartRotationEffect(point);
            }
        }


        public void Scale(Vector2 scale, float timeToScale, ScaleEffectMode scaleEffectMode = ScaleEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<ScaleEffect> endHandler = null)
        {
            if (controller != null)
            {
                controller.SetGeneralScaleEffect(scale, timeToScale, scaleEffectMode,
                    persentageHanderEnum, endHandler);
                controller.StartScaleEffect();
            }
        }

        public void Flash(Vector2 position)
        {
            transform.localPosition = position;
        }

        #endregion
    }
}