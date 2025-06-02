using System.Collections;
using System.Collections.Generic;
using Game.Level;
using Game.Scene;

namespace Game.UI
{
    public class FailedUI : UIGeneralBox<FailedUI, string, string>
    {
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