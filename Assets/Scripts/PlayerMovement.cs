using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [Header("移动参数")]
    public float speed = 8f;
    public float crouchSpeedDivisor = 3f;
    [Header("跳跃参数")]
    public float jumpForce = 6.3f;
    //public float jumpHoldForce = 1.9f;
    public float jumpHoldDuration = 0.1f;
    public float crouchJumpBoost = 2.5f;
    float jumpTime;
    [Header("状态")]
    public bool isCrouch;
    public bool isOnGround;
    public bool isJump;
    public bool isHeadBlock;
    [Header("环境监测")]
    public float footOffset = 0.4f;
    public float headClearance = 0.5f;
    public float groundDistance = 0.2f;
    public LayerMask groundLayer;
    public float xVelocity;
   public  float yVelocity;
    //按键设置
    bool jumpPressed;
    bool jumpHeld;
    bool crouch;
    bool standup;
    //碰撞体尺寸;
    Vector2 colliderStandSize;
    Vector2 colliderStandOffset;
    Vector2 colliderCrouchSize;
    Vector2 colliderCrouchOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        colliderStandOffset = coll.offset;
        colliderStandSize = coll.size;
        colliderCrouchSize = new Vector2(coll.size.x, coll.size.y * 0.5f);
        colliderCrouchOffset = new Vector2(coll.offset.x, coll.offset.y * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.boolGame())
        {
            return;
        }
        jumpPressed = Input.GetButtonDown("Jump");
        jumpHeld = Input.GetButton("Jump");
        crouch = Input.GetButtonDown("Crouch");
        standup = Input.GetButtonDown("Standup");
        PhysicsCheck();
        GroundMovement();
        MidAirMovement();

    }
    private void FixedUpdate()
    {
        
      
        

    }
    void PhysicsCheck()
    {
        RaycastHit2D leftCheck = Raycast(new Vector2(-footOffset, 0f), Vector2.down, groundDistance, groundLayer);
        RaycastHit2D rightCheck = Raycast(new Vector2(footOffset, 0f), Vector2.down, groundDistance, groundLayer);
        if (leftCheck||rightCheck)
            isOnGround = true;
        else isOnGround = false;
        RaycastHit2D headCheck = Raycast(new Vector2(0f, coll.size.y), Vector2.up, headClearance, groundLayer);
        if (headCheck)
            isHeadBlock = true;
    }
    void GroundMovement()
    {
        if (crouch && !isCrouch && isOnGround)
            Crouch();
        if (standup)
            Pstandup();
        xVelocity = Input.GetAxis("Horizontal");//得到键盘输入
        if (isCrouch)
            xVelocity /= crouchSpeedDivisor;
        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
        FilpDriction();
    }
    void MidAirMovement()//空中跳跃
    {
        if (jumpPressed && isOnGround && !isJump)
        {
            if(isCrouch&&isOnGround)
            {
               
                rb.AddForce(new Vector2(0f, crouchJumpBoost), ForceMode2D.Impulse);
            }
            isOnGround = false;
            isJump = true;
            jumpTime = Time.time + jumpHoldDuration;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Audiomanager.Playjumpaduio();
        }
        else if (isJump)
        {
            //if (jumpHeld)
            //    rb.AddForce(new Vector2(0f, jumpHoldForce), ForceMode2D.Impulse);
            if (jumpTime < Time.time)
                isJump = false;
        }
    }
    void FilpDriction()//翻转
    {
        if (xVelocity < 0)
            transform.localScale = new Vector2(-1, 1);
        if (xVelocity > 0)
            transform.localScale = new Vector2(1, 1);
    }
    void Crouch()
    {
        isCrouch = true;
        coll.size = colliderCrouchSize;
        coll.offset = colliderCrouchOffset;
        
    }
    void Pstandup()
    {
        isCrouch= false;
        coll.size = colliderStandSize;
        coll.offset = colliderStandOffset;
    }
    RaycastHit2D Raycast(Vector2 offset,Vector2 rayDirection, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, layer);
        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(pos + offset, rayDirection * length,color);
        return hit;

    }
}
