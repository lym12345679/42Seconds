using System;
using Game.UI;
using UnityEngine;

namespace Game.UI
{
    public class TextShowUI : UIGeneralBox<TextShowUI, TextShowUIMessage, string>
    {
        public static TextShowUI Instance;

        public TextShowController controller;

        public override void Close()
        {
            if (param.EndHander != null)
            {
                param.EndHander();
            }

            base.Close();
        }

        public override void GetParams(TextShowUIMessage param)
        {
            if (Instance == null)
            {
                Instance = this;
            }

            Init();
            base.GetParams(param);
            controller.SetEndHander(Close);
            controller.GetTextAsset(param.TextAsset);
        }

        public void Skip()
        {
            if (param.SkipHander != null)
            {
                param.SkipHander();
            }

            Close();
        }

        public void Init()
        {
            controller.Init();
        }

        public void AddText(string text)
        {
            controller.GetText(text);
        }
    }

    public class TextShowUIMessage
    {
        public TextAsset TextAsset;
        public Action EndHander;
        public Action SkipHander;

        public TextShowUIMessage(TextAsset textAsset, Action endHander = null, Action skipHander = null)
        {
            TextAsset = textAsset;
            EndHander = endHander;
            SkipHander = skipHander;
        }
    }
}