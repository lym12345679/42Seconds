using MizukiTool.MiAudio;
using UnityEngine;


namespace Game.Audio
{
    public class AudioTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            AudioUtil.Play(SEAudioEnum.SE_Test_Babel, AMGEnum.BGM, AudioPlayMod.FadeInThenNormal,
                (context) => { AudioUtil.Play(BGMAudioEnum.Test_Babel, AMGEnum.BGM, AudioPlayMod.Loop); });
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}