using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.UI
{
    public enum BoxEnum
    {
        MessageBox,
    }
    public static class UIBoxDict
    {
        //用字典存储所有的UIEnum和类型
        public static Dictionary<System.Type, string> BoxTypeDic = new Dictionary<System.Type, string>()
        {
            {typeof(MessageBox),BoxEnum.MessageBox.ToString()}
        };
        //用字典存储所有的UI预制体路径
        public static Dictionary<string, string> BoxPathDic = new Dictionary<string, string>
        {
            {BoxEnum.MessageBox.ToString(),"Prefabs/UI/MessageBox"}
        };

    }
}


