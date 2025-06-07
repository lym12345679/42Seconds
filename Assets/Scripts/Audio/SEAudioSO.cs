using MizukiTool.MiAudio;
using UnityEngine;

namespace Game.Audio
{
    [CreateAssetMenu(fileName = "SEAudioSO", menuName = "SO/Audio/SEAudioSO")]
    public class SEAudioSO : GeneralAudioSO<SEAudioEnum>
    {
    }

    public enum SEAudioEnum
    {
        SE_Test_Player_Fail,
        SE_Test_Buttion_Click,
        SE_Test_Babel,
        Win,
        Lose,
        EnterGame,
        Boom,
        WeakWallBroken,
        NextLevel,
        Sprint,
        Laser,
        MouseClick,
        UIClose,
    }
}