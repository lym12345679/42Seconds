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
        Level1_Win,
        Level2_Win,
        Level3_Win,
        Level4_Win,
        Level5_Win,
        Level6_Win,
        Level1_Lose,
        Level2_Lose,
        Level3_Lose,
        Level4_Lose,
        Level5_Lose,
        Level6_Lose,
    }
}