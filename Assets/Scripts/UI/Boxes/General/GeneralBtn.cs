using System.Collections;
using System.Collections.Generic;
using Game.Audio;
using MizukiTool.MiAudio;
using UnityEngine;
using AudioUtil = Game.Audio.AudioUtil;

namespace Game.UI
{
    public class GeneralBtn : MonoBehaviour
    {
        public SEAudioEnum audioEnum = SEAudioEnum.SE_Test_Buttion_Click;

        public void OnClick()
        {
            AudioUtil.Play(audioEnum, AMGEnum.SE, AudioPlayMod.Normal);
        }
    }
}