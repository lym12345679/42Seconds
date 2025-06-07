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
        None,
        Level1_Begin,
        Level2_Begin,
        Level3_Begin,
        Level4_Begin,
        Level5_Begin,
        Level6_Begin,
    }
}