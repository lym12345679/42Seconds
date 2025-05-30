using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public enum BoxEnum
    {
        MessageBox,
        MenuUI,
        TextShowUI,
        LevelSelectorUI,
        LevelUI,
        PauseUI,
        SettingUI,
        FailedUI
    }

    public static class UIBoxDict
    {
        //用字典存储所有的UIEnum和类型
        public static Dictionary<System.Type, string> BoxTypeDic = new Dictionary<System.Type, string>()
        {
            { typeof(MessageBox), BoxEnum.MessageBox.ToString() },
            { typeof(MenuUI), BoxEnum.MenuUI.ToString() },
            { typeof(CGUI), BoxEnum.TextShowUI.ToString() },
            { typeof(LevelSelectorUI), BoxEnum.LevelSelectorUI.ToString() },
            { typeof(LevelUI), BoxEnum.LevelUI.ToString() },
            { typeof(PauseUI), BoxEnum.PauseUI.ToString() },
            { typeof(SettingUI), BoxEnum.SettingUI.ToString() },
            { typeof(FailedUI), BoxEnum.FailedUI.ToString() }
        };

        //用字典存储所有的UI预制体路径
        public static Dictionary<string, string> BoxPathDic = new Dictionary<string, string>
        {
            { BoxEnum.MessageBox.ToString(), "Prefabs/UI/MessageBox" },
            { BoxEnum.MenuUI.ToString(), "Prefabs/UI/Menu/MenuUI" },
            { BoxEnum.TextShowUI.ToString(), "Prefabs/UI/TextShow/TextShowUI" },
            { BoxEnum.LevelSelectorUI.ToString(), "Prefabs/UI/LevelSelector/LevelSelectorUI" },
            { BoxEnum.LevelUI.ToString(), "Prefabs/UI/Level/LevelUI" },
            { BoxEnum.PauseUI.ToString(), "Prefabs/UI/Pause/PauseUI" },
            { BoxEnum.SettingUI.ToString(), "Prefabs/UI/Setting/SettingUI" },
            { BoxEnum.FailedUI.ToString(), "Prefabs/UI/Failed/FailedUI" }
        };
    }
}