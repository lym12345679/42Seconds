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

        #region 循环音频

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

        /// <summary>
        ///     根据枚举回收非循环音效
        /// </summary>
        /// <param name="audioEnum"></param>
        /// <typeparam name="T"></typeparam>
        public static void ReturnLoopAudioByEnum<T>(T audioEnum) where T : Enum
        {
            EnsureRigister();
            MizukiTool.MiAudio.AudioUtil.ReturnLoopAudioByEnum(audioEnum);
        }

        #endregion

        #region 非循环音频

        /// <summary>
        ///     暂停所有非循环音频
        /// </summary>
        public static void PauseAllNormalAudio()
        {
            EnsureRigister();
            MizukiTool.MiAudio.AudioUtil.PauseAllNormalAudio();
        }

        /// <summary>
        ///     继续所有非循环音频
        /// </summary>
        public static void ContinueAllNormalAudio()
        {
            EnsureRigister();
            MizukiTool.MiAudio.AudioUtil.ContinueAllNormalAudio();
        }

        /// <summary>
        ///     归还所有非循环音频
        /// </summary>
        public static void ReturnAllNormalAudio()
        {
            EnsureRigister();
            MizukiTool.MiAudio.AudioUtil.ReturnAllNormalAudio();
        }

        /// <summary>
        ///     检查枚举是否在非循环音频中，如果有则返回对应的AudioClip
        /// </summary>
        /// <param name="audioEnum"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static AudioClip CheckEnumInNormalAudio<T>(T audioEnum) where T : Enum
        {
            EnsureRigister();
            return MizukiTool.MiAudio.AudioUtil.CheckEnumInNormalAudio(audioEnum);
        }

        /// <summary>
        ///     检测是否有指定音效正在播放
        /// </summary>
        /// <param name="audioEnum"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void ReturnNormalAudioByEnum<T>(T audioEnum) where T : Enum
        {
            EnsureRigister();
            MizukiTool.MiAudio.AudioUtil.ReturnNormalAudioByEnum(audioEnum);
        }

        #endregion

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