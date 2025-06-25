using System;
using System.Collections.Generic;
using Game.Instance;
using Game.Tool;
using MizukiTool.GeneralSO;
using UnityEngine;

namespace Game.Plot
{
    public class PlotDict : GeneralInstance<PlotDict>
    {
        //用字典存储所有的剧情,格式为(枚举类型+枚举值,TextAsset)
        private Dictionary<string, TextAsset> plotDict = new Dictionary<string, TextAsset>();
        private Dictionary<string, string> ZhUIDict = new Dictionary<string, string>();
        private Dictionary<string, string> EnUIDict = new Dictionary<string, string>();
        private EnumIdentifier enumIdentifier = new EnumIdentifier();
        private string path = "SO/Plot/";

        public PlotDict()
        {
            RigisterPlot();
            SetUIDict();
        }

        //在这里注册所有的剧情SO
        public void RigisterPlot()
        {
            string finalPath = "MainPlotSO";
            switch (StaticData.CurrentLanguage)
            {
                case LanguageEnum.Chinese: finalPath = "zh_MainPlotSO"; break;
                case LanguageEnum.English: finalPath = "en_MainPlotSO"; break;
                default: break;
            }

            RigisterOnePlotSO<MainPlotEnum, MainPlotSO>(Resources.Load<MainPlotSO>(path + finalPath));
        }

        public void ResetPlotDict()
        {
            plotDict.Clear();
            RigisterPlot();
            SetUIDict();
        }

        private void SetUIDict()
        {
            ZhUIDict.Clear();
            EnUIDict.Clear();
            TextAsset text = TryGetPlot(MainPlotEnum.UI, out text) ? text : null;
            if (text != null)
            {
                string[] lines = text.text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    string[] keys = line.Split(new[] { ':' }, 3);
                    ZhUIDict.Add(keys[0], keys[1]);
                    EnUIDict.Add(keys[0], keys[2]);
                }
            }
        }

        public string GetUIDict(string text)
        {
            string ui = GetZhUIDict(text);
            switch (StaticData.CurrentLanguage)
            {
                case LanguageEnum.Chinese:
                    break;
                case LanguageEnum.English:
                    ui = GetEnUIDict(text); break;
            }

            return ui;
        }

        private string GetZhUIDict(string text)
        {
            return ZhUIDict[text];
        }

        public string GetEnUIDict(string text)
        {
            return EnUIDict[text];
        }

        public void RigisterOnePlotSO<T1, T2>(T2 plotSO) where T2 : PlotSO<T1> where T1 : Enum
        {
            List<TwoValueClass<T1, TextAsset>> plotList = plotSO.GetList<T1, TextAsset>();
            //注册So中的所有剧情,格式为(枚举类型,(枚举值,TextAsset))
            foreach (var field in plotList)
            {
                enumIdentifier.SetEnum(field.EnumValue);
                plotDict.Add(enumIdentifier.GetID(), field.Value2);
            }
        }

        /// <summary>
        /// 根据枚举类型和枚举值获取剧情
        /// </summary>
        /// <param name="plotEnum">枚举值</param>
        /// <param name="textAsset">输出文本</param>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns></returns>
        public bool TryGetPlot<T>(T plotEnum, out TextAsset textAsset) where T : Enum
        {
            enumIdentifier.SetEnum(plotEnum);
            string id = enumIdentifier.GetID();
            if (plotDict.ContainsKey(id))
            {
                textAsset = plotDict[id];
                return true;
            }

            //Debug.LogWarning("剧情字典中没有找到对应的剧情，尝试查找的剧情:" + id);
            textAsset = null;
            return false;
        }

        public bool TryGetPlot(string plotName, out TextAsset textAsset)
        {
            if (plotDict.ContainsKey(plotName))
            {
                textAsset = plotDict[plotName];
                return true;
            }

            Debug.LogWarning("剧情字典中没有找到对应的剧情，尝试查找的剧情:" + plotName);
            textAsset = null;
            return false;
        }
    }

    public class PlotContext
    {
        public string plotName;
        public string plotText;

        public PlotContext(string plotName, string plotText)
        {
            this.plotName = plotName;
            this.plotText = plotText;
        }
    }
}