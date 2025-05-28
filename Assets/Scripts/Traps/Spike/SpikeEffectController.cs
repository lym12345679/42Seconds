using System;
using System.Collections;
using System.Collections.Generic;
using Game.Level;
using MizukiTool.UIEffect;
using UnityEngine;
namespace Game.Traps
{
    public class SpikeEffectController : GOEffectController<SpriteRenderer>
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
            SpikePersentageHanderEnum spikePersentageHanderEnum = SpikePersentageHanderEnum.X,
            Action<PositionEffect> endHander = null)
        {
            Vector3 endPosition = transform.position + (Vector3)vector;
            positionEffect = new PositionEffect()
                .SetEndPosition(endPosition)
                .SetDuration(timeToMove * 2)
                .SetPercentageHandler(SpikePersentageHander.GetHandler(spikePersentageHanderEnum))
                .SetEndHandler(endHander);
            /*.SetPercentageHandler((t) =>
            {
                Debug.Log(t * 100 + "%" + " " + LevelManager.Instance.currentTime);
                return t; // 返回线性插值
            }); // 默认使用线性插值*/
        }
        public void SetGeneralRotationEffect(float rotation, float timeToRotate,
            SpikePersentageHanderEnum spikePersentageHanderEnum = SpikePersentageHanderEnum.X,
            Action<RotationEffect> endHandler = null)
        {
            // 计算结束时的旋转角度
            Vector3 endRotation = transform.rotation.eulerAngles + new Vector3(0, 0, rotation);
            rotationEffect = new RotationEffect()
                .SetEndRotation(endRotation)
                .SetDuration(timeToRotate * 2)
                .SetPercentageHandler(SpikePersentageHander.GetHandler(spikePersentageHanderEnum))
                .SetEndHandler(endHandler);
        }

        public void SetGeneralScaleEffect(Vector2 scale, float timeToScale,
            SpikePersentageHanderEnum spikePersentageHanderEnum = SpikePersentageHanderEnum.X,
            Action<ScaleEffect> endHandler = null)
        {
            Vector3 endScale = transform.localScale + (Vector3)scale;
            scaleEffect = new ScaleEffect()
                .SetEndScale(endScale)
                .SetDuration(timeToScale * 2)
                .SetPercentageHandler(SpikePersentageHander.GetHandler(spikePersentageHanderEnum))
                .SetEndHandler(endHandler);
        }

        public void SetFlashEffect(Vector2 position)
        {
            Vector3 endPosition = transform.position + (Vector3)position;
            transform.position = endPosition;
        }
        #endregion
        public void StartEffect()
        {
            if (positionEffect != null)
            {
                StartPositionEffect(transform, positionEffect);
            }
            if (rotationEffect != null)
            {
                StartRotationEffect(transform, rotationEffect);
            }
            if (scaleEffect != null)
            {
                StartScaleEffect(transform, scaleEffect);
            }
        }
    }

}
