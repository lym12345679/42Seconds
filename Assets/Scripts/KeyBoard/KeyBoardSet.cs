using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.KeyBoard
{
    public static class KeyboardSet
    {
        public static readonly Dictionary<KeyEnum, KeyCode> KeyboardDict = new()
        {
            // Player
            { KeyEnum.Up, KeyCode.W },
            { KeyEnum.Down, KeyCode.S },
            { KeyEnum.Left, KeyCode.A },
            { KeyEnum.Right, KeyCode.D },
            { KeyEnum.Jump, KeyCode.Space },
            { KeyEnum.ESC, KeyCode.Escape },
            { KeyEnum.LeftShift, KeyCode.LeftShift },
            { KeyEnum.Reset, KeyCode.R },
        };

        public static void ChangeKey(KeyEnum key, KeyCode keyCode)
        {
            if (KeyboardDict.ContainsValue(keyCode))
            {
                //提示用户:The key is already in use"
                return;
            }

            KeyboardDict[key] = keyCode;
        }

        public static void ResetKey(KeyEnum key)
        {
            KeyboardDict[key] = KeyCode.None;
        }

        public static KeyCode GetKeyCode(KeyEnum key)
        {
            return KeyboardDict[key];
        }

        /// <summary>
        /// 当前按键是否处于按下的状态
        /// </summary>
        public static bool IsPressing(this KeyEnum key)
            => Input.GetKey(GetKeyCode(key));

        /// <summary>
        /// 当前是否是按键按下的第一帧
        /// </summary>
        public static bool IsKeyDown(this KeyEnum key)
            => Input.GetKeyDown(GetKeyCode(key));

        /// <summary>
        /// 当前是否是按键抬起前的最后一帧
        /// </summary>
        public static bool IsKeyUp(this KeyEnum key)
            => Input.GetKeyUp(GetKeyCode(key));
    }
}