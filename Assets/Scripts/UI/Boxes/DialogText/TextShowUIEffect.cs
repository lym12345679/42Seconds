using System;
using MizukiTool.UIEffect;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class TextShowUIEffect : UIEffectController<Image>
    {
        private FadeEffect<Image> fadeInEffect;
        private FadeEffect<Image> fadeOutEffect;

        void Awake()
        {
            fadeInEffect = new FadeEffect<Image>()
                .SetFadeColor(new Color(1, 1, 1, 1))
                .SetFadeTime(1);
            fadeOutEffect = new FadeEffect<Image>()
                .SetFadeColor(new Color(1, 1, 1, 0))
                .SetFadeTime(1);
        }

        private void StartFadeIn(Image targetImage, Action<FadeEffect<Image>> endHander = null)
        {
            FadeEffect<Image> fadeEffect = fadeInEffect.SetEndHander(endHander);
            StartFade(targetImage, fadeEffect);
        }

        private void StartFadeOut(Image targetImage, Action<FadeEffect<Image>> endHander = null)
        {
            FadeEffect<Image> fadeEffect = fadeOutEffect.SetEndHander(endHander);
            StartFade(targetImage, fadeEffect);
        }

        public void QuicklyFadeIn(Image targetImage, Action<FadeEffect<Image>> endHander = null)
        {
            targetImage.color = new Color(1, 1, 1, 1f);
            FadeEffect<Image> fadeEffect = fadeInEffect.SetFadeTime(0.1f).SetEndHander(endHander);
            StartFade(targetImage, fadeEffect);
        }

        #region 隐藏或显示图片或文本

        public void HideImg(Image image)
        {
            StartFadeOut(image, (hander) => { image.gameObject.SetActive(false); });
        }

        public void ShowImg(Image image, Action<FadeEffect<Image>> endHander = null)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            image.gameObject.SetActive(true);
            StartFadeIn(image, endHander);
        }

        #endregion
    }

    public enum FadeActionEnum
    {
        None,
        FadeIn,
        FadeOut,
        NormalIn,
        NormalOut,
        CoverIn
    }
}