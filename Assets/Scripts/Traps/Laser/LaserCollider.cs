using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Traps
{
    public class LaserCollider : Trap
    {
        public override void OnPlayerTriggerEnter(PlayerController playerController, Vector2 enterPos)
        {
            playerController.OnPlayerDeath();
        }

        public override void OnPlayerEnter(PlayerController playerController, Vector2 position)
        {
            playerController.OnPlayerDeath();
        }
    }
}