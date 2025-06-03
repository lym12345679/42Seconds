using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Traps
{
    public class Laser : Trap
    {
        public LaserEffectController controller; // 控制激光效果的脚本
        private float maxLength = 100f; // 激光的最大长度
        private float maxDuration = 5f; // 激光的最大持续时间

        public void Init()
        {
            transform.localScale = new Vector3(1, 1, 1); // 初始化激光的缩放
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Stop();
            }
        }

        public override void OnPlayerTriggerEnter(PlayerController playerController, Vector2 enterPos)
        {
            playerController.OnPlayerDeath();
        }

        public void Stop()
        {
            controller.StopScaleEffect();
        }

        public void Shot(Vector2 direction)
        {
            Vector2 targetVec = direction.normalized * maxLength; // 计算激光的目标位移
            controller.SetGeneralScaleEffect(targetVec, maxDuration);
            controller.StartScaleEffect(transform.position - (Vector3)direction.normalized / 2); // 启动位置和缩放效果
        }
    }
}