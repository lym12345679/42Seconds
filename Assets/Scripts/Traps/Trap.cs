using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Traps
{
    public class Trap : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public virtual void OnPlayerSprintInToTrap(Collider2D playerCollider)
        {
            // 处理玩家进入陷阱的逻辑
            Debug.Log("Player entered trap: " + playerCollider.name);
            Debug.Log("你没有在子类中设置 OnPlayerSprintInToTrap 方法的实现。请在子类中重写此方法以处理玩家进入陷阱的逻辑。");
        }
    }
}
