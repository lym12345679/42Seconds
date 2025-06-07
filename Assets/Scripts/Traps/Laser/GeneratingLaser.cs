using System;
using System.Collections;
using System.Collections.Generic;
using Game.Audio;
using Game.Recycle;
using MizukiTool.UIEffect;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Traps
{
    public class GeneratingLaser : MonoBehaviour
    {
        public GeneratingLaserController controller; // 控制激光发生器动作效果的脚本
        public ShotDirectionEnum shotDirection; // 激光发射方向

        private void Start()
        {
        }

        //发射激光，激光初始位置距离发射器一格
        public void Shot(ShotDirectionEnum direction)
        {
            shotDirection = direction; // 设置激光发射方向
            Vector2 d = GetShotDirection();
            if (direction == ShotDirectionEnum.left || direction == ShotDirectionEnum.right)
            {
                Debug.Log("GeneratingLaser.Shot: " + direction);
                RecyclePool.Request(RecycleItemEnum.Laser2,
                    (recycleCollection) =>
                    {
                        Laser laser = recycleCollection.GetMainComponent<Laser>();
                        laser.gameObject.transform.position = new Vector3(
                            transform.position.x, transform.position.y, transform.position.z); // 设置激光的初始位置
                        laser.Shot(d);
                    }, transform);
            }
            else
            {
                RecyclePool.Request(RecycleItemEnum.Laser1,
                    (recycleCollection) =>
                    {
                        Laser laser = recycleCollection.GetMainComponent<Laser>();
                        laser.gameObject.transform.position = new Vector3(
                            transform.position.x, transform.position.y, transform.position.z); // 设置激光的初始位置
                        laser.Shot(d);
                    }, transform);
            }

            GamePlayManager.PlaySe(SEAudioEnum.Laser);
        }

        public void Move(Vector2 vector, float timeToMove,
            PositionEffectMode positionEffectMode = PositionEffectMode.Once,
            PersentageHanderEnum persentageHanderEnum = PersentageHanderEnum.X,
            Action<PositionEffect> endHandler = null)
        {
            if (controller != null)
            {
                controller.SetGeneralPositionEffect(vector, timeToMove, positionEffectMode,
                    persentageHanderEnum, endHandler);
                controller.StartPositionEffect();
            }
            else
            {
                Debug.LogWarning("GeneratingLaserController is not assigned in GeneratingLaser.");
            }
        }

        public Vector2 GetShotDirection()
        {
            switch (shotDirection)
            {
                case ShotDirectionEnum.left:
                    return Vector2.left;
                case ShotDirectionEnum.right:
                    return Vector2.right;
                case ShotDirectionEnum.up:
                    return Vector2.up;
                case ShotDirectionEnum.down:
                    return Vector2.down;
                default:
                    return Vector2.zero; // 默认返回零向量
            }
        }
    }

    public enum ShotDirectionEnum
    {
        left,
        right,
        up,
        down
    }
}