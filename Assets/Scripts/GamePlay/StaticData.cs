using System.Collections;
using System.Collections.Generic;
using Game.Plot;
using UnityEngine;

public static class StaticData
{
    public static Dictionary<MainPlotEnum, bool> PlotData = new Dictionary<MainPlotEnum, bool>()
    {
        { MainPlotEnum.Level1_Begin, false },
        { MainPlotEnum.Level2_Begin, false },
        { MainPlotEnum.Level3_Begin, false },
        { MainPlotEnum.Level4_Begin, false },
        { MainPlotEnum.Level5_Begin, false },
        { MainPlotEnum.Level6_Begin, false },
        { MainPlotEnum.Level1_Lose, false },
        { MainPlotEnum.Level2_Lose, false },
        { MainPlotEnum.Level3_Lose, false },
        { MainPlotEnum.Level4_Lose, false },
        { MainPlotEnum.Level5_Lose, false },
        { MainPlotEnum.Level6_Lose, false },
        { MainPlotEnum.Level1_Win, false },
        { MainPlotEnum.Level2_Win, false },
        { MainPlotEnum.Level3_Win, false },
        { MainPlotEnum.Level4_Win, false },
        { MainPlotEnum.Level5_Win, false },
        { MainPlotEnum.Level6_Win, false }
    };
}