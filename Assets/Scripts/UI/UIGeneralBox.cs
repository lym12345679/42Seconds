using System.Collections;
using System.Collections.Generic;
using MizukiTool.Box;
using UnityEngine;
namespace Game.UI
{

    public class UIGeneralBox<T1, T2, T3> : GeneralBox<T1, T2, T3> where T1 : UIGeneralBox<T1, T2, T3> where T2 : class where T3 : class
    {
        public static new void Open(T2 param)
        {
            UIBoxManager.Instance.OpenBox<T1, T2, T3>(param);
        }

        public override void Close()
        {
            UIBoxManager.Instance.CloseBox<T1, T2, T3>(this.BoxID);
        }
    }

}