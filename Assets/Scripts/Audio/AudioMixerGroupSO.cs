using MizukiTool.MiAudio;
using UnityEngine;

namespace Game.Audio
{
    [CreateAssetMenu(fileName = "AudioMixerGroupSO", menuName = "SO/Audio/AudioMixerGroupSO")]
    public class AudioMixerGroupSO : AudioMixerGroupSO<AMGEnum>
    {
    }

    public enum AMGEnum
    {
        Master,
        BGM,
        SE
    }
}