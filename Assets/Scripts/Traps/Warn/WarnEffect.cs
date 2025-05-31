using System;
using System.Collections;
using System.Collections.Generic;
using MizukiTool.UIEffect;
using UnityEngine;

namespace Game.Traps
{
    public class WarnEffect : GOEffectController<SpriteRenderer>
    {
        public SpriteRenderer selfRenderer;
        private Color OriginalColor;
        private Color TargetColor;
        private FadeEffectGO<SpriteRenderer> fadeEffectGo;
        private FadeEffectGO<SpriteRenderer> currentFadeEffectGo;

        private void Awake()
        {
            OriginalColor = selfRenderer.color;
            TargetColor =
                new Color(OriginalColor.r, OriginalColor.g, OriginalColor.a, 0.2f); // Example target color (light red)
            fadeEffectGo = new FadeEffectGO<SpriteRenderer>(selfRenderer)
                .SetFadeColor(TargetColor)
                .SetFadeTime(0.5f)
                .SetPersentageHander((f) =>
                {
                    int i = (int)(f * 5);
                    return i & 1;
                });
        }

        public void Init()
        {
            selfRenderer.color = OriginalColor;
            StartWarnEffect();
        }

        public void StartWarnEffect(Action<FadeEffectGO<SpriteRenderer>> endHander = null)
        {
            currentFadeEffectGo = fadeEffectGo.Copy(fadeEffectGo)
                .SetEndHander(endHander);
            StartFade(selfRenderer, currentFadeEffectGo);
        }
    }
}