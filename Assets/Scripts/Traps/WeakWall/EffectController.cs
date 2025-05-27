using System.Collections;
using System.Collections.Generic;
using MizukiTool.UIEffect;
using UnityEngine;

using UnityEngine.UI;

public class EffectController : MonoBehaviour
{
    private bool isBlinking = false;
    private float Duation = 1f;
    private float tick = 0f;
    private float stage = 0;// 当前阶段
    private float internalTime = 0.1f; // 闪烁间隔时间
    private SpriteRenderer spriteRenderer;
    private Color originalColor; // 初始颜色
    private Color targetColor; // 目标颜色
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        BlinkEffectUpdate();
    }
    public void SetSpriteRenderer(SpriteRenderer spriteRenderer)
    {
        this.spriteRenderer = spriteRenderer;
        originalColor = spriteRenderer.color; // 保存初始颜色
    }
    //颜色闪烁效果
    public void StartBlink(Color targetColor)
    {
        tick = 0f;
        stage = 0;
        isBlinking = true;
        this.targetColor = targetColor; // 设置目标颜色

    }
    private void BlinkEffectUpdate()
    {
        if (isBlinking)
        {
            // 在这里实现颜色闪烁的逻辑
            // 例如，使用Lerp函数在当前颜色和目标颜色之间插值
            // spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, Time.deltaTime / duration);
            if (tick < Duation)
            {
                tick += Time.deltaTime;
                if (stage * internalTime < tick)
                {
                    stage++;
                    if (stage % 2 == 0)
                    {
                        ChangeColor(originalColor);
                    }
                    else
                    {
                        ChangeColor(targetColor);
                    }
                }
            }
            else
            {
                isBlinking = false;
                spriteRenderer.color = originalColor; // 恢复原始颜色
            }
        }
    }

    private void ChangeColor(Color targetColor, float duration)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, Time.deltaTime / duration);
        }
    }
    private void ChangeColor(Color targetColor)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = targetColor; // 恢复原始颜色
        }
    }
}
