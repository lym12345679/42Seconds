using UnityEngine;

namespace Game.Traps
{
    public class WeakWall : Trap
    {
        public WeakWallEffectController effectController;


        public override void OnPlayerSprintInToTrap(PlayerController playerController, Vector2 position)
        {
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

            Debug.Log("WeakWall: Player sprinted into the weak wall trap from right side: " + playerController.name);
            effectController.StartBlink(Color.white); // 开始闪烁效果
            // 在这里添加弱墙被冲破的逻辑
        }
    }
}