using System;
using System.Collections;
using System.Collections.Generic;
using Game.Audio;
using Game.Level;
using Game.Recycle;
using UnityEngine;

namespace Game.Traps
{
    public class GuidedMissile : MonoBehaviour
    {
        private float speed = 5f, duration = 5f, currentTime = 0f, originalRotationZ = 0f;

        private Transform player
        {
            get { return LevelManager.Instance.GetPlayerTransform(); }
        }

        private void Awake()
        {
            originalRotationZ = transform.rotation.z;
        }

        private void FixedUpdate()
        {
            FollowPlayer();
        }

        public void Init()
        {
            currentTime = 0f; // 重置当前时间
            transform.rotation = Quaternion.Euler(0, 0, originalRotationZ); // 重置子物体的旋转
            transform.localPosition = Vector3.zero; // 重置子物体的位置
        }

        private void FollowPlayer()
        {
            if (currentTime < duration)
            {
                Vector3 direction = (player.position - transform.position).normalized; // 计算指向玩家的方向
                transform.position += speed * Time.fixedDeltaTime * direction; // 移动子物体

                // 计算新的旋转角度
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle); // 设置子物体的旋转
                currentTime += Time.fixedDeltaTime; // 增加当前时间
            }
            else
            {
                Boom();
            }
        }

        public void Boom()
        {
            RecyclePool.Request(RecycleItemEnum.Boom,
                (recycleCollection) => { recycleCollection.GameObject.transform.position = transform.position; });
            RecyclePool.ReturnToPool(transform.gameObject);
            GamePlayManager.PlaySe(SEAudioEnum.Boom);
        }
    }
}