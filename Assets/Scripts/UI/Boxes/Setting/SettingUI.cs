using System;
using System.Collections;
using System.Collections.Generic;
using Game.Audio;
using Game.Plot;
using MizukiTool.MiAudio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using AudioUtil = Game.Audio.AudioUtil;

namespace Game.UI
{
    public class SettingUI : UIGeneralBox<SettingUI, string, string>
    {
        public Scrollbar BGMScrollbar;
        public Scrollbar SEScrollbar;
        public TextMeshProUGUI BGMText, SEText, BackBtnText, LanguageBtnText;

        private void Start()
        {
            SetLanguage();
            GamePlayManager.OnChangeLanguage += SetLanguage;
        }

        private void SetLanguage()
        {
            BGMText.text = PlotDict.Instance.GetUIDict("Music");
            SEText.text = PlotDict.Instance.GetUIDict("SFX");
            BackBtnText.text = PlotDict.Instance.GetUIDict("Back");
            LanguageBtnText.text = PlotDict.Instance.GetUIDict("Language");
        }

        public override void GetParams(string param)
        {
            BGMScrollbar.value = AudioUtil.GetAudioMixerGroupValume(AMGEnum.BGM);
            SEScrollbar.value = AudioUtil.GetAudioMixerGroupValume(AMGEnum.SE);

            /*if (!AudioUtil.CheckEnumInLoopAudio(BGMAudioEnum.Test2))
            {
                AudioUtil.Play(BGMAudioEnum.Test2, AMGEnum.BGM, AudioPlayMod.Loop);
            }*/


            base.GetParams(param);
        }

        public override void Close()
        {
            //AudioUtil.ReturnAllLoopAudio();
            GamePlayManager.OnChangeLanguage -= SetLanguage;
            base.Close();
        }

        public void OnBGMVolumeChange()
        {
            AudioUtil.SetAudioVolume(AMGEnum.BGM, BGMScrollbar.value);
        }

        public void OnSEVolumeChange()
        {
            AudioUtil.SetAudioVolume(AMGEnum.SE, SEScrollbar.value);
        }

        public void ChangeLanguage()
        {
            GamePlayManager.SetLanguage();
        }
    }
}