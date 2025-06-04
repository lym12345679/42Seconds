using Game.Recycle;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Traps
{
    public class WeakWall : Trap
    {
        public WeakWallEffectController controller;
        private bool isDistroying = false; // 是否正在销毁

        public void Init()
        {
            controller.Init();
        }

        public override void OnPlayerSprintInToTrap(PlayerController playerController, Vector2 position)
        {
            if (isDistroying)
            {
                return; // 如果已经在销毁中，则不再处理
            }

            isDistroying = true; // 设置为正在销毁状态
            // 处理玩家冲刺进入弱墙的逻辑
            //Debug.Log("WeakWall: Player sprinted into the weak wall trap: " + playerController.name);
            if (playerController.transform.position.x > transform.position.x)
            {
                // 玩家从右侧冲入弱墙
                playerController.SetSpritDirection(1);
            }
            else
            {
                // 玩家从左侧冲入弱墙
                playerController.SetSpritDirection(-1);
            }

            controller.StartBlink(Color.white, (e) => { RecyclePool.ReturnToPool(this.gameObject); }); // 开始闪烁效果
            // 在这里添加弱墙被冲破的逻辑
        }
    }
}