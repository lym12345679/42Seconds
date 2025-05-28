using System;
using System.Collections;
using System.Collections.Generic;
using MizukiTool.GeneralSO;
using UnityEngine;
namespace Game.Traps
{
    public class SpikeMessageListSO : ScriptableObject
    {
        public string Description; // 描述信息
        public List<SpikeMessage> SpikeMessages = new List<SpikeMessage>(); // 存储脊柱的位移、旋转和缩放信息
    }
    [Serializable]
    public class SpikeMessage
    {
        public string Name; // 名称
        public float Time; // 距离开始的时间
        //位移
        public Vector2 Vector; // 位移
        public float TimeToMove; // 移动时间
        //旋转
        public float Rotation; // 旋转角度
        public float TimeToRotate; // 旋转时间
        //缩放
        public Vector2 Scale; // 缩放比例
        public float TimeToScale; // 缩放时间

    }
}