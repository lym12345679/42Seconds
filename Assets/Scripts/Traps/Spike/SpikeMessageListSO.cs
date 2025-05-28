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
        public List<SpikeMessageSOWithTime> SpikeMessages = new List<SpikeMessageSOWithTime>(); // 存储尖刺的位移、旋转和缩放信息
        private void OnValidate()
        {
            for (int i = 0; i < SpikeMessages.Count; i++)
            {
                if (SpikeMessages[i].SpikeMessage == null)
                {
                    SpikeMessages[i].Name = $"在第{SpikeMessages[i].StartTime}秒时，无事发生"; // 如果SpikeMessage为空，则设置默认名称
                    continue; // 跳过空的SpikeMessageSO
                }
                else
                {
                    SpikeMessages[i].Name = $"在第{SpikeMessages[i].StartTime}秒时，{SpikeMessages[i].SpikeMessage.Name}";
                }

            }
        }
        /*if (SpikeMessage != null)
        {
            Name = $"在第{StartTime}时，{SpikeMessage.Name}"; // 确保名称与SO中的名称一致
        }
        else
        {
            Name = "Unnamed Spike Message";
        }*/
    }

    [Serializable]
    public class SpikeMessageSOWithTime
    {

        public string Name;
        public float StartTime; // 时间
        public SpikeMessageSO SpikeMessage; // 尖刺的位移、旋转和缩放信息

    }
    [Serializable]
    [CreateAssetMenu(fileName = "SpikeMessageSO", menuName = "ScriptableObjects/SpikeMessageSO")]
    public class SpikeMessageSO : ScriptableObject
    {
        public string Name; // 名称
        public bool IsMove; // 是否需要移动
        public VectorMassage Vector; // 位移信息
        public bool IsRotate; // 是否需要旋转
        public RotationMassage Rotation; // 旋转信息
        public bool IsScale; // 是否需要缩放
        public ScaleMassage Scale; // 缩放信息
        public bool IsFlash; // 是否需要闪现
        public FlashMassage Flash; // 闪现信息
    }
    [Serializable]
    public class VectorMassage
    {

        public Vector2 Vector; // 位置
        public float Duration; // 时间
        public SpikePersentageHanderEnum PercentageHandler = SpikePersentageHanderEnum.X; // 百分比处理方式
    }
    [Serializable]
    public class RotationMassage
    {

        public float Rotation; // 旋转角度
        public float Duration; // 时间
        public SpikePersentageHanderEnum PercentageHandler = SpikePersentageHanderEnum.X; // 百分比处理方式
    }
    [Serializable]
    public class ScaleMassage
    {
        public Vector2 Scale; // 缩放比例
        public float Duration; // 时间
        public SpikePersentageHanderEnum PercentageHandler = SpikePersentageHanderEnum.X; // 百分比处理方式
    }
    [Serializable]
    public class FlashMassage
    {
        public Vector2 Position; // 闪现位置
    }
    public class SpikePersentageHander
    {
        private static Dictionary<SpikePersentageHanderEnum, Func<float, float>> Handlers = new Dictionary<SpikePersentageHanderEnum, Func<float, float>>()
        {
            { SpikePersentageHanderEnum.X, t => t },
            { SpikePersentageHanderEnum.X2, t => t*t },
            { SpikePersentageHanderEnum.X3, t => t*t*t },
            { SpikePersentageHanderEnum.X_2, t => 1/t/t },
            { SpikePersentageHanderEnum.X_3, t => 1/t/t/t },
        };
        public static Func<float, float> GetHandler(SpikePersentageHanderEnum handlerEnum)
        {
            if (Handlers.TryGetValue(handlerEnum, out var handler))
            {
                return handler;
            }
            throw new ArgumentException($"No handler found for {handlerEnum}");
        }
    }
    public enum SpikePersentageHanderEnum
    {
        X,
        X2,
        X3,
        X_2,
        X_3,
    }
}