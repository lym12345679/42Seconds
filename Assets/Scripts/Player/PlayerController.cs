using System;
using Game;
using Game.Audio;
using Game.KeyBoard;
using Game.Level;
using Game.Traps;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public delegate void TrapDelegate(PlayerController p);

    private int direction = 1; // 1表示向右，-1表示向左

    //冲刺相关数据
    private bool isSprinting = false; // 是否正在冲刺
    private readonly int sprintCount = 1; // 冲刺次数
    private int sprintDirection = 1; // 冲刺方向，1表示向右，-1表示向左
    public int currentSprintCount = 0; // 当前剩余冲刺次数
    private readonly float sprintSpeed = 20f; // 冲刺速度
    private readonly float sprintTick = 0.1f; // 冲刺持续时间
    private float currentSprintTick = 0f; // 当前冲刺计时
    private readonly float sprintCooldownTick = 0.5f; // 冲刺冷却时间
    public TrapDelegate TrapDe = (p) => { }; // 冲刺事件
    private float currentSprintCooldownTick = 0f; // 当前冲刺冷却计时

    //跳跃相关数据
    private readonly int jumpCount = 2; // 可跳跃次数
    public int currentJumpCount = 0; // 当前剩余跳跃次数
    private readonly float jumpSpeed = 10f; // 跳跃速度

    private bool isLeaveGround = false; // 是否离开地面
    private readonly float playerHight = .3f; // 玩家高度
    public LayerMask GroundLayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Rigister();
    }

    void Update()
    {
        CheckKeyInputs();
    }

    private void FixedUpdate()
    {
        if (!isSprinting)
        {
            OnPlayerMove();
        }

        CheckJumpCondition();
        SprintAction();
    }

    private void Rigister()
    {
        LevelManager.Instance.RigisterPlayer(this.transform);
    }

    #region 按键检测

    private void CheckKeyInputs()
    {
        if (isSprinting)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && currentJumpCount > 0)
        {
            OnPlayerJumpInputed();
        }

        if ((KeyboardSet.IsKeyDown(KeyEnum.LeftShift) || KeyboardSet.IsKeyDown(KeyEnum.MouseRight)) && isSprinting ==
            false)
        {
            OnPlayerSprintInputed();
        }
    }

    #endregion

    #region 移动相关

    private void OnPlayerMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Time.deltaTime * 5f * Vector3.left);
            ChangeDirection();
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Time.deltaTime * 5f * Vector3.right);
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
            transform.localScale =
                new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            transform.localScale =
                new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    #endregion

    #region 跳跃相关

    //跳跃次数重置条件
    private void CheckJumpCondition()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, .53f);
        RaycastHit2D[] hit1 = Physics2D.RaycastAll(transform.position + new Vector3(0.28f, 0, 0), Vector2.down, .53f);
        RaycastHit2D[] hit2 = Physics2D.RaycastAll(transform.position + new Vector3(-0.28f, 0, 0), Vector2.down, .53f);
        bool isGrounded = false;

        foreach (var h in hit1)
        {
            if (h.collider != null && h.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                isGrounded = true; // 检测到地面（落地）
            }
        }

        foreach (var h in hit)
        {
            if (h.collider != null && h.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                isGrounded = true; // 检测到地面（落地）
            }
        }

        foreach (var h in hit2)
        {
            if (h.collider != null && h.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                isGrounded = true; // 检测到地面（落地）
            }
        }

        if (isGrounded)
        {
            isLeaveGround = false; // 重置离开地面标记
            currentJumpCount = jumpCount;
            //Debug.Log("Player is on the ground, jump count reset to: " + currentJumpCount);
        }
        else
        {
            if (!isLeaveGround)
            {
                isLeaveGround = true; // 标记玩家已离开地面
                currentJumpCount--; // 减少跳跃次数
            }
        }
    }

    // 玩家跳跃输入检测
    private void OnPlayerJumpInputed()
    {
        //SetJumpState(true);
        if (!isLeaveGround)
        {
            isLeaveGround = true; // 标记玩家离开地面
        }
        else
        {
            currentJumpCount--;
        }

        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed); // 重置垂直速度
    }

    #endregion

    #region 冲刺相关

    private void SprintAction()
    {
        if (isSprinting)
        {
            OnPlayerSprint();
        }
        else if (currentSprintCount < sprintCount)
        {
            OnPlayerSprintCooldown();
        }
    }

    //检测冲刺按键是否按下
    private void OnPlayerSprintInputed()
    {
        if (currentSprintCount <= 0)
        {
            return; // 如果没有剩余冲刺次数，则不执行冲刺
        }

        GamePlayManager.PlaySe(SEAudioEnum.Sprint);
        sprintDirection = direction; // 设置冲刺方向
        TrapDe?.Invoke(this);
        SetSprintState(true);
    }

    //冲刺逻辑
    private void OnPlayerSprint()
    {
        if (isSprinting && currentSprintTick < sprintTick)
        {
            transform.Translate(Time.deltaTime * sprintSpeed * sprintDirection * Vector3.right);
            currentSprintTick += Time.deltaTime;
            //Debug.Log("Player is sprinting!");
        }
        else
        {
            SetSprintState(false);
        }
    }

    public void SetSpritDirection(int i)
    {
        sprintDirection = i; // 设置冲刺方向
    }

    public bool GetIsSprinting()
    {
        return isSprinting;
    }

    public float GetPlayerHeight()
    {
        return playerHight;
    }

    //冲刺冷却逻辑
    private void OnPlayerSprintCooldown()
    {
        if (currentSprintCooldownTick < sprintCooldownTick)
        {
            currentSprintCooldownTick += Time.deltaTime;
        }
        else
        {
            currentSprintCount++;
            currentSprintCooldownTick = 0f;
            //Debug.Log("Player can sprint again!");
        }
    }

    // 设置冲刺状态
    private void SetSprintState(bool state)
    {
        isSprinting = state;
        if (!state)
        {
            currentSprintTick = 0f;
            currentSprintCount--;
        }
    }

    #endregion

    #region 玩家死亡

    public void OnPlayerDeath()
    {
        // 这里可以添加玩家死亡的逻辑，比如重置关卡、播放死亡动画等
        Debug.Log("Player has died!");
        // 玩家不可见
        this.gameObject.SetActive(false);
        LevelManager.Instance.OnPlayerDead(); // 通知关卡管理器玩家死亡
    }

    #endregion

    #region 玩家碰撞

    // 检测玩家与其他物体的碰撞
    private void OnCollisionEnter2D(Collision2D other)
    {
        // 检测玩家与其他物体的碰撞
        Vector2 collisionPoint = new Vector2(0, 0);
        foreach (var p in other.contacts)
        {
            collisionPoint += p.point;
        }

        //Debug.Log(other.contacts.Length);
        collisionPoint /= other.contacts.Length; // 计算碰撞点的平均位置
        if (other.gameObject.CompareTag("Trap"))
        {
            OnTrapEnter(other, collisionPoint);
        }

        if ((1 << other.gameObject.layer & GroundLayer) != 0)
        {
            OnGroundEnter(other, collisionPoint);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            OnTrapExit(other);
        }
    }

    private void OnTrapEnter(Collision2D other, Vector2 collisionPoint)
    {
        Trap trap = other.gameObject.GetComponent<Trap>();
        if (trap != null)
        {
            if (isSprinting)
            {
                trap.OnPlayerSprintInToTrap(this, collisionPoint);
            }
            else
            {
                trap.OnPlayerEnter(this, collisionPoint);
            }
        }
    }

    private void OnTrapExit(Collision2D other)
    {
        Trap trap = other.gameObject.GetComponent<Trap>();
        trap.OnPlayerExit(this);
    }

    private void OnGroundEnter(Collision2D other, Vector2 collisionPoint)
    {
        //Debug.Log("Player collided with ground at: " + collisionPoint);
        if (isSprinting && collisionPoint.y > transform.position.y - playerHight &&
            collisionPoint.y < transform.position.y + playerHight)
        {
            //Debug.Log("Player collided with ground while sprinting.");
            if (transform.position.x > collisionPoint.x)
            {
                //Debug.Log("Player sprinted from right to left.");
                SetSpritDirection(1);
            }
            else
            {
                //Debug.Log("Player sprinted from left to right.");
                SetSpritDirection(-1);
            }
        }
    }

    // 检测玩家与陷阱的触发器碰撞
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            Trap trap = other.gameObject.GetComponent<Trap>();
            if (trap != null)
            {
                Vector2 collisionPoint = other.ClosestPoint(transform.position);
                trap.OnPlayerTriggerEnter(this, collisionPoint);
            }
        }
    }

    #endregion
}