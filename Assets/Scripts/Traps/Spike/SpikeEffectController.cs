using System.Collections;
using System.Collections.Generic;
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

        public void SetGeneralPositionEffect(Vector2 vector, float timeToMove)
        {
            Vector3 endPosition = transform.position + (Vector3)vector;
            positionEffect = new PositionEffect()
                .SetEndPosition(endPosition)
                .SetDuration(timeToMove);
        }

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
