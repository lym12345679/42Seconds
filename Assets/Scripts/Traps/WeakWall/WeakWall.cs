
using UnityEngine;
namespace Game.Traps
{
    public class WeakWall : Trap
    {
        public WeakWallEffectController effectController;


        public override void OnPlayerSprintInToTrap(Collider2D playerCollider)
        {
            // 处理玩家冲刺进入弱墙的逻辑
            //Debug.Log("WeakWall: Player sprinted into the weak wall trap: " + playerCollider.name);
            effectController.StartBlink(Color.white); // 开始闪烁效果
            // 在这里添加弱墙被冲破的逻辑

        }
    }
}

