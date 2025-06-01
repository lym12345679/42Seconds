using Game.Plot;
using Game.Recycle;
using Game.TextShow;
using UnityEngine;

namespace Game.UI
{
    public class TestUIManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //MessageBox.Open(new Message("测试标题", "测试内容"));
            //TextShowUI.Open(new TextShowUIMessage(PlotDict.Instance.GetPlot("TestPlot1")));
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void FixedUpdate()
        {
            /*RecyclePool.Request(RecycleItemEnum.Warn,
                (c) =>
                {
                    c.GameObject.transform.position = new Vector3(Random.Range(-5f, 5f),
                        Random.Range(-5f, 5f), 0);
                });*/
        }
    }
}