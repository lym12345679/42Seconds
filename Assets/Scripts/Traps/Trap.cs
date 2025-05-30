using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Traps
{
    public class Trap : MonoBehaviour
    {
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
    }
}