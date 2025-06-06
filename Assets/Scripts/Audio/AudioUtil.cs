using System;
using MizukiTool.MiAudio;
using UnityEngine;
using UnityEngine.Audio;

namespace Game.Audio
{
    public static class AudioUtil
    {
        private static bool isRigister = false;

        /// <summary>
        /// 音响
        /// </summary>
        private static AudioMixerGroupSO audioMixerGroupSO =
            Resources.Load<AudioMixerGroupSO>("SO/Audio/AudioMixerGroupSO");

        /// 音效存储参考方式
        private static BGMAudioSO BGMAudioClipSO = Resources.Load<BGMAudioSO>("SO/Audio/BGMAudioSO");

        private static SEAudioSO SEAudioClipSo = Resources.Load<SEAudioSO>("SO/Audio/SEAudioSO");

//音量范围
        public static float DBMin = -40;
        public static float DBMax = 0;

        public static float DBRange
        {
            get { return DBMax - DBMin; }
        }


        private static void SetRigisterAction()
        {
            Action action = () => { RigisterAllAudioClip(); };
            MizukiTool.MiAudio.AudioUtil.SetRigisterAction(action);
        }

        private static void RigisterAllAudioClip()
        {
            foreach (var item in BGMAudioClipSO.audioList)
            {
                RegisterAudioClip(item.audioEnum, item.audioClip);
            }

            foreach (var item in SEAudioClipSo.audioList)
            {
                RegisterAudioClip(item.audioEnum, item.audioClip);
            }
        }

        private static void RegisterAudioClip<T>(T audioEnum, AudioClip audioClip) where T : Enum
        {
            MizukiTool.MiAudio.AudioUtil.RegisterAudioClip(audioEnum, audioClip);
        }

        public static void Play<T>
        (
            T audioEnum,
            AMGEnum audioMixerGroupEnum,
            AudioPlayMod audioPlayMod,
            Action<AudioPlayContext> endEventHander = null,
            Action<AudioPlayContext> fixedUpdateEventHander = null
        ) where T : Enum
        {
            EnsureRigister();
            MizukiTool.MiAudio.AudioUtil.Play(audioMixerGroupSO, audioEnum, audioMixerGroupEnum, audioPlayMod,
                endEventHander, fixedUpdateEventHander);
        }

        public static void SetAudioVolume(AMGEnum audioMixerEnum, float volume)
        {
            EnsureRigister();
            AudioMixerGroup entry = audioMixerGroupSO.GetAudioMixerGroup(audioMixerEnum);
            MizukiTool.MiAudio.AudioUtil.SetAudioVolume(audioMixerEnum, volume, entry);
        }

        internal static float GetAudioMixerGroupValume(AMGEnum audioMixerEnum)
        {
            if (audioMixerGroupSO != null)
            {
                audioMixerGroupSO.GetAudioMixerGroup(AMGEnum.Master).audioMixer
                    .GetFloat(audioMixerEnum.ToString(), out float value);
                return GetPersentageFromValume(value);
            }

            return 0;
        }

//获取音量百分比
        private static float GetPersentageFromValume(float valume)
        {
            return (valume - DBMin) / DBRange;
        }

        public static void PauseAllLoopAudio()
        {
            EnsureRigister();
            MizukiTool.MiAudio.AudioUtil.PauseAllLoopAudio();
        }

        public static void ContinueAllLoopAudio()
        {
            EnsureRigister();
            MizukiTool.MiAudio.AudioUtil.ContinueAllLoopAudio();
        }

        public static void ReturnAllLoopAudio()
        {
            EnsureRigister();
            MizukiTool.MiAudio.AudioUtil.ReturnAllLoopAudio();
        }

        public static bool CheckEnumInLoopAudio<T>(T audioEnum) where T : Enum
        {
            EnsureRigister();
            return MizukiTool.MiAudio.AudioUtil.CheckEnumInLoopAudio(audioEnum);
        }

        private static void EnsureRigister()
        {
            if (!isRigister)
            {
                isRigister = true;
                SetRigisterAction();
            }
        }
    }

    public enum AudioMixerGroupEnum
    {
        Master,
        BGM,
        Effect
    }
}