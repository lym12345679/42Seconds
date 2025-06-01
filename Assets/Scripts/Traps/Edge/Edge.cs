using System.Collections;
using System.Collections.Generic;
using Game.Traps;
using UnityEngine;

namespace Game.Traps
{
    public class Edge : Trap
    {
        public override void OnPlayerTriggerEnter(PlayerController playerController, Vector2 enterPos)
        {
            playerController.OnPlayerDeath();
        }
    }
}