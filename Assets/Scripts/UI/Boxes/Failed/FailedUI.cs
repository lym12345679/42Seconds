using System;
using System.Collections;
using System.Collections.Generic;
using Game.Level;
using Game.Scene;
using TMPro;

namespace Game.UI
{
    public class FailedUI : UIGeneralBox<FailedUI, string, string>
    {
        public TextMeshProUGUI text;

        private void Start()
        {
            if (LevelManager.Instance.CurrentSceneType == SceneType.Level6)
            {
                text.text = "（你真的要犹豫再来一次吗？它可能会带来难以想象的后果）";
            }
        }

        public void ReSetGame()
        {
            GamePlayManager.LoadScene(LevelManager.Instance.CurrentSceneType);
        }

        public void GoToLevelSelector()
        {
            GamePlayManager.LoadScene(SceneType.LevelSelector);
        }
    }
}