using System.Collections;
using System.Collections.Generic;
using Game.Scene;
using UnityEngine;

namespace Game.UI
{
    public class MenuUI : UIGeneralBox<MenuUI, string, string>
    {
        public override void GetParams(string param)
        {
            base.GetParams(param);
        }

        public override void Close()
        {
            base.Close();
            Debug.Log("MenuUI Closed");
        }

        public void GoToLevelSelector()
        {
            GamePlayManager.LoadScene(SceneType.LevelSelector);
        }

        public void OpenSetting()
        {
            SettingUI.Open(" ");
        }

        public void ExitGame()
        {
            GamePlayManager.ExitGame();
        }

        public void StartGame()
        {
            Debug.Log("Start Game");
            GamePlayManager.LoadScene(SceneType.LevelSelector);
            // Add logic to start the game
        }
    }
}