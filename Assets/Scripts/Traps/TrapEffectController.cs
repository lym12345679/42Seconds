using System;
using System.Collections;
using System.Collections.Generic;
using Game.Level;
using MizukiTool.UIEffect;
using UnityEngine;

namespace Game.Traps
{
    public class TrapEffectController : GOEffectController<SpriteRenderer>
    {
        private PositionEffect positionEffect;
        private RotationEffect rotationEffect;
        private ScaleEffect scaleEffect;
        private PositionEffect currentPositionEffect;
        private RotationEffect currentRotationEffect;
        private ScaleEffect currentScaleEffect;

        public void Init()
        {
            positionEffect = null;
            rotationEffect = null;
            scaleEffect = null;
        }

        #region 设置机关的通常位移、旋转和缩放效果

        /// <summary>
        /// 设置机关的通常位移效果
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="timeToMove"></param>
        /// <param name="positionEffectMode"></param>
        /// <param name="persentageHanderEnum"></param>
        /// <param name="endHandler"></param>
        public void SetGeneralPositionEffect(Vector2 vector, float timeToMove,
            PositionEffectMode positionEffectMode = PositionEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<PositionEffect> endHandler = null)
        {
            Vector3 endPosition = transform.position + (Vector3)vector;
            positionEffect = new PositionEffect()
                .SetEndPosition(endPosition)
                .SetDuration(timeToMove * 2)
                .SetPercentageHandler(SpikePersentageHander.GetHandler(persentageHanderEnum))
                .SetEffectMode(positionEffectMode)
                .SetEndHandler(endHandler);
        }

        /// <summary>
        /// 设置机关的通常旋转效果
        /// </summary>
        /// <param name="rotation"></param>
        /// <param name="timeToRotate"></param>
        /// <param name="rotationEffectMode"></param>
        /// <param name="persentageHanderEnum"></param>
        /// <param name="endHandler"></param>
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

        /// <summary>
        /// 设置机关的通常缩放效果
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="timeToScale"></param>
        /// <param name="scaleEffectMode"></param>
        /// <param name="persentageHanderEnum"></param>
        /// <param name="endHandler"></param>
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
                currentPositionEffect = StartPositionEffect(transform, positionEffect);
            }
        }

        public void StartRotationEffect()
        {
            if (rotationEffect != null)
            {
                currentRotationEffect = StartRotationEffect(transform, rotationEffect);
            }
        }

        public void StartRotationEffect(Transform t)
        {
            if (rotationEffect != null)
            {
                currentRotationEffect = StartRotationEffect(t, rotationEffect);
            }
        }


        public void StartScaleEffect()
        {
            if (scaleEffect != null)
            {
                currentScaleEffect = StartScaleEffect(transform, scaleEffect);
            }
        }

        public void StopPositionEffect()
        {
            if (currentPositionEffect != null)
            {
                currentPositionEffect.FinishImmediately();
                currentPositionEffect = null;
            }
        }

        public void StopRotationEffect()
        {
            if (currentRotationEffect != null)
            {
                currentRotationEffect.FinishImmediately();
                currentRotationEffect = null;
            }
        }

        public void StopScaleEffect()
        {
            if (currentScaleEffect != null)
            {
                currentScaleEffect.FinishImmediately();
                currentScaleEffect = null;
            }
        }
    }
}