using Game.Plot;
using UnityEngine;

namespace Game.UI
{
    public class TestUIManager : MonoBehaviour
    {
        // Start is called before the first frame update
        public MainPlotEnum testPlot = MainPlotEnum.Test1;

        void Start()
        {
            //MessageBox.Open(new Message("测试标题", "测试内容"));
            PlotDict.Instance.TryGetPlot(testPlot, out TextAsset text);
            TextShowUI.Open(new TextShowUIMessage(text));
        }
    }
}