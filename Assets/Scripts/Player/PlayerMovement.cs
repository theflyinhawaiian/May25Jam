using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement Parameters")]
    public float moveSpeed = 5f;

    [Header("Jumping Parameters")]
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    [Header("Gravity Modifiers")]
    public float lowJumpMultiplier = 2f;

    private Rigidbody2D rb;
    private Collider2D collider2d;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
    }
    private void Update()
    {
        CheckGrounded();
        HandleSideViewMovement();

        if (Input.GetButtonDown("Jump")) //space
            TryJump();

        if (rb.linearVelocity.y > 0)
            rb.linearVelocity += (lowJumpMultiplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
    }

    private void HandleSideViewMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float speed = moveSpeed;
        Move(horizontalInput, speed);
    }

    private void CheckGrounded()
    {
        isGrounded = Physics2D.IsTouchingLayers(collider2d, groundLayer);
    }

    private void Move(float horizontalInput, float speed)
    {
        Vector2 moveVelocity = new(horizontalInput * speed, rb.linearVelocity.y);
        rb.linearVelocity = moveVelocity;
    }

    private void TryJump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

}