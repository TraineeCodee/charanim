using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float moveSpeed = 5f;
    public float jumpForce = 6f;
    private bool moveLeft, moveRight;
    public Animator animator;

    void Start()
    {
        moveLeft = false;
        moveRight = false;
    }

    void Update()
    {
        float moveX = 0f;

        // Movement Controls
        if (moveLeft)
        {
            moveX = -moveSpeed;
            sr.flipX = true;
        }
        else if (moveRight)
        {
            moveX = moveSpeed;
            sr.flipX = false;
        }

        rb.linearVelocity = new Vector2(moveX, rb.linearVelocity.y);

        // Animation logic
        if (Mathf.Abs(moveX) > 0.1f)
        {
            animator.SetBool("run", true);
            animator.SetBool("idle", false);
        }
        else
        {
            animator.SetBool("run", false);
            animator.SetBool("idle", true);
        }

        // Jump Control
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("jump"); // Trigger jump once
        }

        // Keyboard Controls for movement
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeft = true;
            moveRight = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRight = true;
            moveLeft = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveRight = false;
        }
    }
}
