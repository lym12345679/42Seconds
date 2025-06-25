using System;
using System.Collections;
using System.Collections.Generic;
using Game.Level;
using Game.Plot;
using Game.Scene;
using TMPro;

namespace Game.UI
{
    public class FailedUI : UIGeneralBox<FailedUI, string, string>
    {
        public TextMeshProUGUI text;
        public TextMeshProUGUI RestartText, LevelSelectorText;

        private void Start()
        {
            if (LevelManager.Instance.CurrentSceneType == SceneType.Level6)
            {
                text.text = PlotDict.Instance.GetUIDict("Final False");
            }
            else
            {
                text.text = PlotDict.Instance.GetUIDict("General False");
            }

            RestartText.text = PlotDict.Instance.GetUIDict("Restart");
            LevelSelectorText.text = PlotDict.Instance.GetUIDict("Level Select");
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