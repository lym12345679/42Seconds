using System;
using System.Collections;
using System.Collections.Generic;
using Game.Recycle;
using UnityEngine;

namespace Game.Traps
{
    public class GeneratingLaser : MonoBehaviour
    {
        public GeneratingLaserController generatingLaserController; // 控制激光发生器动作效果的脚本
        public ShotDirectionEnum shotDirection; // 激光发射方向

        private void Start()
        {
        }

        public void Shot()
        {
            Vector2 d = GetShotDirection();
            RecyclePool.Request(RecycleItemEnum.Laser1,
                (recycleCollection) =>
                {
                    Laser laser = recycleCollection.GetMainComponent<Laser>();
                    laser.gameObject.transform.position = new Vector3(
                        transform.position.x + d.x, transform.position.y + d.y, transform.position.z); // 设置激光的初始位置
                    laser.Shot(d);
                }, transform);
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