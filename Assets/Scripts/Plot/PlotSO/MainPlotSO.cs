using UnityEngine;
namespace Game.Plot
{
    [CreateAssetMenu(fileName = "MainPlotSO", menuName = "SO/MainPlotSO")]
    public class MainPlotSO : PlotSO<MainPlotEnum>
    {

    }

    public enum MainPlotEnum
    {
        Main1,
        Main2,
        Test3,
    }
}
