using System;
using MizukiTool.UIEffect;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Traps
{
    /// <summary>
    /// 弱墙效果控制器
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class WeakWallEffectController : GOEffectController<SpriteRenderer>
    {
        private FadeEffectGO<SpriteRenderer> blinkEffectGO;
        private FadeEffectGO<SpriteRenderer> currentEffectGO;
        public SpriteRenderer SelfSprite;
        private Color originalColor; // 初始颜色
        private Color targetColor; // 目标颜色

        void Awake()
        {
            if (SelfSprite == null)
            {
                SelfSprite = GetComponent<SpriteRenderer>();
            }

            originalColor = SelfSprite.color; // 保存初始颜色
            //Debug.Log(originalColor);
            blinkEffectGO = new FadeEffectGO<SpriteRenderer>(SelfSprite)
                .SetFadeColor(Color.white)
                .SetOriginalColor(originalColor)
                .SetFadeMode(FadeMode.Once)
                .SetFadeTime(0.5f)
                .SetPersentageHander((percentage) =>
                {
                    if ((int)(percentage * 10) % 2 == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                })
                .SetEndHander((f) =>
                {
                    SelfSprite.color = originalColor; // 恢复到初始颜色
                });
        }

        public void Init()
        {
            SelfSprite.color = originalColor; // 确保初始颜色被设置
            //Debug.Log(originalColor);
        }

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        //颜色闪烁效果
        public void StartBlink(Color targetColor, Action<FadeEffectGO<SpriteRenderer>> endHander = null)
        {
            //Debug.Log("StartBlink called with targetColor: " + targetColor);
            FadeEffectGO<SpriteRenderer> target = blinkEffectGO.Copy(blinkEffectGO);
            currentEffectGO = StartFade(SelfSprite, target).SetEndHander(endHander);
        }
    }
}