using System.Collections;
using System.Collections.Generic;
using Game.Scene;
using UnityEngine;

namespace Game.UI
{
    public class LevelSelectorUIBtn : MonoBehaviour
    {
        public SceneType level;

        public void OnClick()
        {
            LevelSelectorUI.Instance.GoToLevel(SceneType.Level1);
        }
    }
}