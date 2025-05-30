using UnityEngine;

namespace Game.Plot
{
    public class PlotTreeTest : PlotTree<PlotTreeTest>
    {
        public override TextAsset GetPlot()
        {
            return Selector(
                () => Condition(true, () => GetTextAsset(MainPlotEnum.Test3)),
                () => Condition(true, () => GetTextAsset(MainPlotEnum.Main2))
            );
        }
    }
}