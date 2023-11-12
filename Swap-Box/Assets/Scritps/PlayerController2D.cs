using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    // speed variables
    [SerializeField] private float moveSpeed;

    // Jump variables
    [SerializeField] private float jumpVelocity;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private Rigidbody2D playerRb;
    float moveInput;

    bool facingRight = true;

    // Ground Stuff
    private bool isGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        Jump();
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        Movement();
    }
    private void Movement()
    {
        // player moving logic 
        moveInput = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(moveSpeed * moveInput, playerRb.velocity.y);

        if (facingRight == false && moveInput > 0) { Flip(); }
        if (facingRight == true && moveInput < 0) { Flip(); }
    }

    private void Jump()
    {
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpVelocity);
            jumpBufferCounter = 0;
        }

        // jump buffer
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && playerRb.velocity.y > 0f)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }


    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
