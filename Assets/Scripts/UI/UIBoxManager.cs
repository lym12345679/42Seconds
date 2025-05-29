using System.Collections;
using System.Collections.Generic;
using MizukiTool.Box;
using UnityEngine;
namespace Game.UI
{
    public class UIBoxManager : BoxManager
    {
        private static UIBoxManager instance;
        public new static UIBoxManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UIBoxManager();
                }
                return instance;
            }
        }
        protected override Dictionary<string, string> GetBoxPathDict()
        {
            return UIBoxDict.BoxPathDic;
        }
        protected override Dictionary<System.Type, string> GetBoxTypeDict()
        {
            return UIBoxDict.BoxTypeDic;
        }
    }
}
