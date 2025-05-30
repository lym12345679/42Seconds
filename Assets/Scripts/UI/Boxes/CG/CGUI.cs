using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.UI
{
    public class CGUI : UIGeneralBox<CGUI, string, string>
    {
        public override void GetParams(string param)
        {
            base.GetParams(param);
            Debug.Log("CGUI GetParams: " + param);
        }

        public override void Close()
        {
            base.Close();
            Debug.Log("CGUI Closed");
        }
    }
}
