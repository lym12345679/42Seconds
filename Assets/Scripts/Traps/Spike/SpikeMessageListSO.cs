using System;
using System.Collections;
using System.Collections.Generic;
using MizukiTool.GeneralSO;
using UnityEngine;
namespace Game.Traps
{
    [CreateAssetMenu(fileName = "SpikeMessageListSO", menuName = "ScriptableObjects/SpikeMessageListSO")]
    public class SpikeMessageListSO : ScriptableObject
    {
        public string Description; // 描述信息
        public List<SpikeMessage> SpikeMessages = new List<SpikeMessage>(); // 存储脊柱的位移、旋转和缩放信息
    }
    [Serializable]
    public class SpikeMessage
    {
        public string Name; // 名称
        public float StartTime; // 距离开始的时间
                                //位移
        public VectorMassage Vector; // 位移信息
        public RotationMassage Rotation; // 旋转信息
        public ScaleMassage Scale; // 缩放信息
        public FlashMassage Flash; // 闪现信息

    }
    [Serializable]
    public class VectorMassage
    {
        public bool IsMove; // 是否需要移动
        public Vector2 Vector; // 位置
        public float Duration; // 时间
    }
    [Serializable]
    public class RotationMassage
    {
        public bool IsRotate; // 是否需要旋转
        public float Rotation; // 旋转角度
        public float Duration; // 时间
    }
    [Serializable]
    public class ScaleMassage
    {
        public bool IsScale; // 是否需要缩放
        public Vector2 Scale; // 缩放比例
        public float Duration; // 时间
    }
    [Serializable]
    public class FlashMassage
    {
        public bool IsFlash; // 是否需要闪现
        public Vector2 Position; // 闪现位置
    }
}