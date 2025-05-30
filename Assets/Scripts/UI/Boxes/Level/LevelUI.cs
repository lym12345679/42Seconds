using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class LevelUI : UIGeneralBox<LevelUI, string, string>
    {
        public override void GetParams(string param)
        {
            base.GetParams(param);
            Debug.Log("LevelUI GetParams: " + param);
        }

        public override void Close()
        {
            base.Close();
            Debug.Log("LevelUI Closed");
        }
    }

}
