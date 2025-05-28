using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Traps
{
    public class Spike : Trap
    {
        public SpikeMessageListSO spikeMessageListSO; // 存储尖刺的位移、旋转和缩放信息
        public SpikeEffectController spikeEffectController; // 控制尖刺效果的脚本
        private List<SpikeMessage> spikeMessages = new List<SpikeMessage>(); // 存储尖刺的位移、旋转和缩放信息列表
        void Awake()
        {
            if (spikeMessageListSO != null)
            {
                spikeMessages = spikeMessageListSO.SpikeMessages;
            }
        }
    }
}
