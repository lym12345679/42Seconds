using System;
using System.Collections;
using System.Collections.Generic;
using Game.Recycle;
using UnityEngine;

namespace Game.Traps
{
    public class GuideMissileCollider : Trap
    {
        public LayerMask GroundLayer; // 地面层的LayerMask
        public GuidedMissile SelfGuidedMissile;

        public override void OnPlayerTriggerEnter(PlayerController playerController, Vector2 enterPos)
        {
            playerController.OnPlayerDeath();
            Boom();
        }

        private void OnTriggerEnter(Collider other)
        {
            if ((1 << other.gameObject.layer & GroundLayer) != 0)
            {
                Boom();
            }
        }

        private void Boom()
        {
            Debug.Log("Boom");
            RecyclePool.Request(RecycleItemEnum.Boom,
                (recycleCollection) => { recycleCollection.GameObject.transform.position = transform.position; });
            RecyclePool.ReturnToPool(SelfGuidedMissile.gameObject);
        }

        public override void OnTrapEnter(Trap trap)
        {
            if (trap.TrapType == TrapEnum.WeakWall)
            {
                RecyclePool.ReturnToPool(trap.gameObject);
                Boom();
            }
        }
    }
}