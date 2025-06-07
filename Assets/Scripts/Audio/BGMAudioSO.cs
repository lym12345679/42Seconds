using MizukiTool.MiAudio;
using UnityEngine;

namespace Game.Audio
{
    [CreateAssetMenu(fileName = "BGMAudioSO", menuName = "SO/Audio/BGMAudioSO")]
    public class BGMAudioSO : GeneralAudioSO<BGMAudioEnum>
    {
    }

    public enum BGMAudioEnum
    {
        Test_Babel,
        Test2,
        BGM_1
    }
}