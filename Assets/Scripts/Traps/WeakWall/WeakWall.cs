using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakWall : Trap
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void OnPlayerSprintInToTrap(Collider2D playerCollider)
    {
        // 处理玩家冲刺进入弱墙的逻辑
        Debug.Log("WeakWall: Player sprinted into the weak wall trap: " + playerCollider.name);
        // 在这里添加弱墙被冲破的逻辑
        Destroy(gameObject); // 销毁弱墙
    }
}
