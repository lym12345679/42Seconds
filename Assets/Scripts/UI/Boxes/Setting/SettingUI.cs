using System.Collections;
using System.Collections.Generic;
using Game.Audio;
using MizukiTool.MiAudio;
using UnityEngine;
using UnityEngine.UI;
using AudioUtil = Game.Audio.AudioUtil;

namespace Game.UI
{
    public class SettingUI : UIGeneralBox<SettingUI, string, string>
    {
        public Scrollbar BGMScrollbar;
        public Scrollbar SEScrollbar;

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
    }
}