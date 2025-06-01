using UnityEngine;

namespace Game.Plot
{
    [CreateAssetMenu(fileName = "MainPlotSO", menuName = "SO/MainPlotSO")]
    public class MainPlotSO : PlotSO<MainPlotEnum>
    {
    }

    public enum MainPlotEnum
    {
        Test1,
        Test2,
        Test3,
    }
}