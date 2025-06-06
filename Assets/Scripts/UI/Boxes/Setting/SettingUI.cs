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
            /*if (!AudioUtil.CheckEnumInLoopAudio(SEAudioEnum.SE_Test_Babel) ||
                !AudioUtil.CheckEnumInLoopAudio(BGMAudioEnum.Test_Babel))
            {
                AudioUtil.Play(SEAudioEnum.SE_Test_Babel, AMGEnum.BGM, AudioPlayMod.FadeInThenNormal,
                    (context) => { AudioUtil.Play(BGMAudioEnum.Test_Babel, AMGEnum.BGM, AudioPlayMod.Loop); });
            }*/


            base.GetParams(param);
        }

        public override void Close()
        {
            /*AudioUtil.PauseAllLoopAudio();
            AudioUtil.ReturnAllLoopAudio();*/
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