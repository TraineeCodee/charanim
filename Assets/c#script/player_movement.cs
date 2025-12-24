using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator animator;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 6f;

    private bool moveLeft, moveRight;

    [Header("Jump Settings")]
    private int jumpCount = 0;
    private int maxJumps = 2;

    [Header("Dash Settings")]
    public float dashSpeed = 15f;
    public float dashTime = 0.5f;
    public float dashCooldown = 1f;

    private bool isDashing = false;
    private bool canDash = true;
    private float dashDirection;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip jumpClip;
    public AudioClip dashClip;

    void Start()
    {
        moveLeft = false;
        moveRight = false;

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isDashing) return;

        float moveX = 0f;

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

        animator.SetBool("run", Mathf.Abs(moveX) > 0.1f);
        animator.SetBool("idle", Mathf.Abs(moveX) <= 0.1f);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("jump");

            if (jumpClip != null)
                audioSource.PlayOneShot(jumpClip);

            jumpCount++;
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            dashDirection = sr.flipX ? -1f : 1f;
            StartCoroutine(Dash());
        }

        // Keyboard Input
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

    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        rb.linearVelocity = new Vector2(dashDirection * dashSpeed, 0f);
        animator.SetTrigger("dash");

        if (dashClip != null)
            audioSource.PlayOneShot(dashClip); // 🔊 Dash Sound

        yield return new WaitForSeconds(dashTime);

        rb.gravityScale = originalGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}
