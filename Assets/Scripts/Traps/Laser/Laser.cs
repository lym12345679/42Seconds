using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Traps
{
    public class Laser : Trap
    {
        public LaserEffectController controller; // 控制激光效果的脚本
        private readonly float maxLength = 50f; // 激光的最大长度
        private readonly float maxDuration = 0.25f; // 激光的最大持续时间
        private Vector3 originalScale;

        private void Awake()
        {
            originalScale = transform.localScale;
        }

        public void Init()
        {
            transform.localScale = originalScale; // 初始化激光的缩放
            controller.child.transform.localPosition = Vector3.zero; // 初始化子物体的位置
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().OnPlayerDeath();
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

        //
        public void Shot(Vector2 direction)
        {
            Vector2 targetScale = new Vector2(Mathf.Abs(direction.x), Mathf.Abs(direction.y)) * maxLength; // 计算激光的目标放大值
            Debug.Log(targetScale);
            controller.SetGeneralScaleEffect(targetScale, maxDuration);
            controller.StartScaleEffect(transform.position + (Vector3)direction / 2); // 启动位置和缩放效果
        }
    }
}