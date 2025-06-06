using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Game.Level;
using Game.Recycle;
using MizukiTool.UIEffect;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Game.Traps
{
    public class Bread : MonoBehaviour
    {
        public TrapEffectController controller;
        public Transform left, right;
        private bool isFollowingPlayer = true;
        private float followDuration = 2f, mergeDuration = 1f, followTime = 0f;
        private float x1 = 5f, x2 = -5f;

        private Transform player
        {
            get { return LevelManager.Instance.GetPlayerTransform(); }
        }

        private void FixedUpdate()
        {
            if (isFollowingPlayer)
            {
                FollowPlayer();
            }
        }

        public void Init()
        {
            followTime = 0f;
            isFollowingPlayer = true;
            left.localPosition = new Vector3(x1, 0, transform.localPosition.z);
            right.localPosition = new Vector3(x2, 0, transform.localPosition.z);
        }

        private void FollowPlayer()
        {
            if (!isFollowingPlayer || ReferenceEquals(player, null))
                return;
            transform.position = player.position;
            followTime += Time.deltaTime;
            if (followTime >= followDuration)
            {
                isFollowingPlayer = false;
                StartMerge();
            }
        }

        private void StartMerge()
        {
            controller.SetGeneralPositionEffect(Vector2.zero,
                mergeDuration);
            controller.StartPositionEffect(left);
            controller.SetGeneralPositionEffect(Vector2.zero,
                mergeDuration);
            controller.StartPositionEffect(right);
        }
    }
}