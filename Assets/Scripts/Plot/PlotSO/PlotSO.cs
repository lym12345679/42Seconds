using System;
using System.Collections.Generic;
using MizukiTool.GeneralSO;
using UnityEngine;

namespace Game.Plot
{
    public class PlotSO<T> : TwoValueSO<T, TextAsset> where T : Enum
    {
        public new bool TryGetValueByKey(T key, out TextAsset textAsset)
        {
            foreach (var pair in SelfList)
            {
                if (pair.EnumValue.Equals(key))
                {
                    textAsset = pair.Value2;
                    return true;
                }
            }

            textAsset = null;
            return false;
        }

        public List<TwoValueClass<T, TextAsset>> GetList<T1, T2>()
        {
            return SelfList;
        }
    }
}