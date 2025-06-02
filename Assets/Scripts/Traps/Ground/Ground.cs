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
        public GroundEffectController groundEffectController; // 控制尖刺效果的脚本
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
            if (groundEffectController != null)
            {
                groundEffectController.SetGeneralPositionEffect(vector, timeToMove, positionEffectMode,
                    persentageHanderEnum, endHandler);
                groundEffectController.StartPositionEffect();
            }
        }

        public void Rotate(float rotation, float timeToRotate,
            RotationEffectMode rotationEffectMode = RotationEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<RotationEffect> endHandler = null)
        {
            if (groundEffectController != null)
            {
                groundEffectController.SetGeneralRotationEffect(rotation, timeToRotate, rotationEffectMode,
                    persentageHanderEnum, endHandler);
                groundEffectController.StartRotationEffect();
            }
        }

        public void SpicalRotate(float rotation, Vector2 point, float timeToRotate,
            RotationEffectMode rotationEffectMode = RotationEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<RotationEffect> endHandler = null)
        {
            Transform parent = transform.parent;
            Transform emptyObj = null;
            RecyclePool.Request(RecycleItemEnum.EmptyObj, (r) =>
            {
                emptyObj = r.GetMainComponent<Transform>();
                emptyObj.position = point;
                transform.SetParent(emptyObj);
            });
            groundEffectController.SetGeneralRotationEffect(rotation, timeToRotate, rotationEffectMode,
                persentageHanderEnum, (e) =>
                {
                    endHandler?.Invoke(null);
                    transform.parent = parent;
                    RecyclePool.ReturnToPool(emptyObj.gameObject);
                });
            groundEffectController.StartRotationEffect(emptyObj);
        }


        public void Scale(Vector2 scale, float timeToScale, ScaleEffectMode scaleEffectMode = ScaleEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<ScaleEffect> endHandler = null)
        {
            if (groundEffectController != null)
            {
                groundEffectController.SetGeneralScaleEffect(scale, timeToScale, scaleEffectMode,
                    persentageHanderEnum, endHandler);
                groundEffectController.StartScaleEffect();
            }
        }

        public void Flash(Vector2 position)
        {
            transform.localPosition = position;
        }

        #endregion
    }
}