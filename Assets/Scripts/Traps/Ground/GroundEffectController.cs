using System;
using System.Collections;
using System.Collections.Generic;
using Game.Level;
using MizukiTool.UIEffect;
using UnityEngine;

namespace Game.Traps
{
    public class GroundEffectController : GOEffectController<SpriteRenderer>
    {
        private PositionEffect positionEffect;
        private RotationEffect rotationEffect;
        private ScaleEffect scaleEffect;

        public void Init()
        {
            positionEffect = null;
            rotationEffect = null;
            scaleEffect = null;
        }

        #region 设置尖刺的通常位移、旋转和缩放效果

        public void SetGeneralPositionEffect(Vector2 vector, float timeToMove,
            PositionEffectMode positionEffectMode = PositionEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<PositionEffect> endHander = null)
        {
            Vector3 endPosition = transform.position + (Vector3)vector;
            positionEffect = new PositionEffect()
                .SetEndPosition(endPosition)
                .SetDuration(timeToMove * 2)
                .SetPercentageHandler(SpikePersentageHander.GetHandler(persentageHanderEnum))
                .SetEffectMode(positionEffectMode)
                .SetEndHandler(endHander);
            /*.SetPercentageHandler((t) =>
            {
                Debug.Log(t * 100 + "%" + " " + LevelManager.Instance.currentTime);
                return t; // 返回线性插值
            }); // 默认使用线性插值*/
        }

        public void SetGeneralRotationEffect(float rotation, float timeToRotate,
            RotationEffectMode rotationEffectMode = RotationEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<RotationEffect> endHandler = null)
        {
            // 计算结束时的旋转角度
            Vector3 endRotation = transform.rotation.eulerAngles + new Vector3(0, 0, rotation);
            rotationEffect = new RotationEffect()
                .SetEndRotation(endRotation)
                .SetDuration(timeToRotate * 2)
                .SetEffectMode(rotationEffectMode)
                .SetPercentageHandler(SpikePersentageHander.GetHandler(persentageHanderEnum))
                .SetEndHandler(endHandler);
        }

        public void SetGeneralScaleEffect(Vector2 scale, float timeToScale,
            ScaleEffectMode scaleEffectMode = ScaleEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<ScaleEffect> endHandler = null)
        {
            Vector3 endScale = transform.localScale + (Vector3)scale;
            scaleEffect = new ScaleEffect()
                .SetEndScale(endScale)
                .SetDuration(timeToScale * 2)
                .SetEffectMode(scaleEffectMode)
                .SetPercentageHandler(SpikePersentageHander.GetHandler(persentageHanderEnum))
                .SetEndHandler(endHandler);
        }

        #endregion

        public void StartPositionEffect()
        {
            if (positionEffect != null)
            {
                StartPositionEffect(transform, positionEffect);
            }
        }

        public void StartRotationEffect()
        {
            if (rotationEffect != null)
            {
                StartRotationEffect(transform, rotationEffect);
            }
        }

        public void StartRotationEffect(Transform t)
        {
            if (rotationEffect != null)
            {
                StartRotationEffect(t, rotationEffect);
            }
        }


        public void StartScaleEffect()
        {
            if (scaleEffect != null)
            {
                StartScaleEffect(transform, scaleEffect);
            }
        }
    }
}