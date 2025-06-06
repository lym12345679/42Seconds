using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Traps
{
    public class Trap : MonoBehaviour
    {
        public TrapEnum TrapType = TrapEnum.None;

        public virtual void OnPlayerSprintInToTrap(PlayerController playerController, Vector2 position)
        {
            // 处理玩家进入陷阱的逻辑
            Debug.Log("Player entered trap: " + playerController.name + " in trap: " + gameObject.name);
            Debug.Log("你没有在子类中设置 OnPlayerSprintInToTrap 方法的实现。请在子类中重写此方法以处理玩家进入陷阱的逻辑。");
        }

        public virtual void OnPlayerEnter(PlayerController playerController, Vector2 position)
        {
            Debug.Log("Player entered trap: " + gameObject.name);
        }

        public virtual void OnPlayerTriggerEnter(PlayerController playerController, Vector2 enterPos)
        {
        }

        public virtual void OnPlayerExit(PlayerController playerController)
        {
            // 处理玩家离开陷阱的逻辑
            Debug.Log("Player exited trap: " + playerController.name + " from trap: " + gameObject.name);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Trap"))
            {
                if (other.TryGetComponent(out Trap trap))
                {
                    OnTrapEnter(trap);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Trap"))
            {
                if (other.gameObject.TryGetComponent(out Trap trap))
                {
                    OnTrapEnter(trap);
                }
            }
        }

        public virtual void OnTrapEnter(Trap trap)
        {
        }
    }
}