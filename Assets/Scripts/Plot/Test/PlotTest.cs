using System.Collections;
using System.Collections.Generic;
using Game.Plot;
using Game.TextShow;
using Game.UI;
using UnityEngine;
namespace Game.Plot
{
    public class PlotTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            TextAsset textAsset = PlotTreeTest.Instance.GetPlot();
            Debug.Log(textAsset.text);
            TextShowUI.Open(new TextShowUIMessage(textAsset));
            //DialogUI.Open(new DialogUIMessage().SetTextAsset(textAsset));
            //DialogMessage dialogMessage = new DialogMessage().SetTextAsset(textAsset);
            //DialogUI1.Open(dialogMessage);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
