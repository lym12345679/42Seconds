using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Traps
{
    public class GuidedMissileCollider : Trap
    {
        public override void OnPlayerTriggerEnter(PlayerController playerController, Vector2 enterPos)
        {
            playerController.OnPlayerDeath();
        }
    }
}