using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    private int direction = 1; // 1表示向右，-1表示向左
    //冲刺相关数据
    private bool isSprinting = false;// 是否正在冲刺
    private int sprintCount = 1; // 冲刺次数
    private int sprintDirection = 1; // 冲刺方向，1表示向右，-1表示向左
    public int currentSprintCount = 0; // 当前剩余冲刺次数
    private float sprintSpeed = 20f;// 冲刺速度
    private float sprintTick = 0.1f;// 冲刺持续时间
    private float currentSprintTick = 0f;// 当前冲刺计时
    private float sprintCooldownTick = 0.5f; // 冲刺冷却时间
    private float currentSprintCooldownTick = 0f; // 当前冲刺冷却计时
    //跳跃相关数据
    private int jumpCount = 2;// 可跳跃次数
    public int currentJumpCount = 0;// 当前剩余跳跃次数
    public bool isJumping = false;// 是否正在跳跃
    private float jumpTick = 0.5f;// 跳跃持续时间
    private float currentJumpTick = 0f;// 当前跳跃计时
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        CheckKeyInputs();
        CheckJumpCondition();
    }
    private void FixedUpdate()
    {
        if (!isSprinting)
        {
            OnPlayerMove();
        }
        if (isJumping)
        {
            OnPlayerJump();
        }
        SprintAction();

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
        if (Input.GetKeyDown(KeyCode.LeftShift) && isSprinting == false)
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
            transform.Translate(Vector3.left * Time.deltaTime * 5f);
            ChangeDirection();
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 5f);
            ChangeDirection();
        }
    }
    private void ChangeDirection()
    {
        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    #endregion
    #region 跳跃相关
    //跳跃次数重置条件
    private void CheckJumpCondition()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, .52f);
        foreach (var h in hit)
        {
            if (h.collider != null && h.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                currentJumpCount = jumpCount;
            }
        }
    }
    // 玩家跳跃输入检测
    private void OnPlayerJumpInputed()
    {
        SetJumpState(true);
    }
    // 玩家跳跃逻辑:参考iwanna
    private void OnPlayerJump()
    {
        if (Input.GetKey(KeyCode.Space) && isJumping && currentJumpTick < jumpTick)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 5f);
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            currentJumpTick += Time.deltaTime;
            //Debug.Log("Player is jumping!");
        }
        else
        {
            SetJumpState(false);
        }
    }
    // 设置跳跃状态
    private void SetJumpState(bool state)
    {
        isJumping = state;
        if (!state)
        {
            currentJumpCount--;
            currentJumpTick = 0f;
        }
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
        sprintDirection = direction; // 设置冲刺方向
        SetSprintState(true);
    }

    //冲刺逻辑
    private void OnPlayerSprint()
    {
        if (isSprinting && currentSprintTick < sprintTick)
        {
            SprintCheck(); // 检测冲刺是否碰到墙壁
            transform.Translate(Vector3.right * Time.deltaTime * sprintSpeed * sprintDirection);
            currentSprintTick += Time.deltaTime;
            //Debug.Log("Player is sprinting!");
        }
        else
        {
            SetSprintState(false);
        }
    }
    //冲刺检测
    private void SprintCheck()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.right * direction, .52f);
        bool hitWall = false;
        foreach (var h in hit)
        {
            if (h.collider != null && h.collider.tag == "Wall")
            {
                hitWall = true; // 检测到墙壁
            }
            if (h.collider != null && h.collider.tag == "Trap")
            {
                h.collider.GetComponent<Trap>().OnPlayerSprintInToTrap(GetComponent<Collider2D>());
                hitWall = true; // 检测到陷阱
                //Debug.Log("Player hit a trap while sprinting!");
            }
        }
        if (hitWall)
        {
            sprintDirection = -sprintDirection; // 改变冲刺方向
            //Debug.Log("Player hit a wall while sprinting!");
        }
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
}
