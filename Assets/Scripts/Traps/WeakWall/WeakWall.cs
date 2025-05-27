using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MizukiTool.UIEffect;
using Unity.VisualScripting;
public class WeakWall : Trap
{
    private SpriteRenderer spriteRenderer;
    private EffectController effectController;
    private Color originalColor;
    void Awake()
    {
        effectController = GetComponent<EffectController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (effectController != null)
        {
            effectController.SetSpriteRenderer(spriteRenderer);
        }
    }
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
        effectController.StartBlink(Color.white); // 开始闪烁效果
        // 在这里添加弱墙被冲破的逻辑

    }
}
