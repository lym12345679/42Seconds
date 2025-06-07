using System.Collections;
using System.Collections.Generic;
using Game.Audio;
using Game.Scene;
using MizukiTool.MiAudio;
using UnityEngine;
using AudioUtil = Game.Audio.AudioUtil;

namespace Game.UI
{
    public class LevelSelectorUIBtn : MonoBehaviour
    {
        public SceneType level;
        public SEAudioEnum ClickedAudio;

        public void OnClick()
        {
            AudioUtil.Play(ClickedAudio, AMGEnum.SE, AudioPlayMod.Normal);
            LevelSelectorUI.Instance.GoToLevel(level);
        }
    }
}