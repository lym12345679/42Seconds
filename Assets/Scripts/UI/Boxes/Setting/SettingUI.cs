using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class SettingUI : UIGeneralBox<SettingUI, string, string>
    {
        public override void GetParams(string param)
        {
            base.GetParams(param);
            Debug.Log("SettingUI GetParams: " + param);
        }

        public override void Close()
        {
            base.Close();
            Debug.Log("SettingUI Closed");
        }
    }
}