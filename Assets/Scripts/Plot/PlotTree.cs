using System;
using Game.Instance;
using UnityEngine;

namespace Game.Plot
{
    public delegate TextAsset ConditionDelegate();

    public class PlotTree<T> : GeneralInstance<T> where T : PlotTree<T>, new()
    {
        public virtual TextAsset GetPlot()
        {
            return null;
        }

        protected TextAsset Condition(bool condition, ConditionDelegate hander)
        {
            if (condition)
            {
                return hander();
            }

            return null;
        }

        protected TextAsset Selector(params ConditionDelegate[] handers)
        {
            foreach (var hander in handers)
            {
                TextAsset textAsset = hander();
                if (textAsset != null)
                {
                    return textAsset;
                }
            }

            return null;
        }

        protected TextAsset GetTextAsset<T1>(T1 plotEnum) where T1 : Enum
        {
            TextAsset textAsset;
            if (PlotDict.Instance.TryGetPlot(plotEnum, out textAsset))
            {
                return textAsset;
            }

            return null;
        }
    }
}