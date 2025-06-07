using System;
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
            SelfGuidedMissile.Boom();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if ((1 << other.gameObject.layer & GroundLayer) != 0)
            {
                SelfGuidedMissile.Boom();
            }
        }


        public override void OnTrapEnter(Trap trap)
        {
            if (trap.TrapType == TrapEnum.WeakWall)
            {
                trap.GetComponent<WeakWall>().OnDestroyedByTrap();
                SelfGuidedMissile.Boom();
            }
        }
    }
}