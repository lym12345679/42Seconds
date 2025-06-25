using System;
using System.Collections;
using System.Collections.Generic;
using Game.Audio;
using Game.Plot;
using Game.Scene;
using MizukiTool.MiAudio;
using TMPro;
using UnityEngine;
using AudioUtil = Game.Audio.AudioUtil;

namespace Game.UI
{
    public class MenuUI : UIGeneralBox<MenuUI, string, string>
    {
        public TextMeshProUGUI BeginBtnText, SettingBtnText, ExitBtnText;

        private void Start()
        {
            SetLanguage();
            GamePlayManager.OnChangeLanguage += SetLanguage;
        }

        private void SetLanguage()
        {
            BeginBtnText.text = PlotDict.Instance.GetUIDict("Play");
            SettingBtnText.text = PlotDict.Instance.GetUIDict("Options");
            ExitBtnText.text = PlotDict.Instance.GetUIDict("Exit");
        }

        public override void GetParams(string param)
        {
            GamePlayManager.PlayBGM(BGMAudioEnum.BGM_1);

            base.GetParams(param);
        }

        public override void Close()
        {
            Debug.Log("close");
            GamePlayManager.OnChangeLanguage -= SetLanguage;
            base.Close();
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