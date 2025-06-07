using System.Collections;
using System.Collections.Generic;
using Game.Audio;
using Game.Scene;
using MizukiTool.MiAudio;
using UnityEngine;
using AudioUtil = Game.Audio.AudioUtil;

namespace Game.UI
{
    public class MenuUI : UIGeneralBox<MenuUI, string, string>
    {
        public override void GetParams(string param)
        {
            GamePlayManager.PlayBGM(BGMAudioEnum.BGM_1);

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