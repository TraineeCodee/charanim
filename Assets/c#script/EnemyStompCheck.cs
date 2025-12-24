using UnityEngine;

public class EnemyStompCheck : MonoBehaviour
{
    public float bounceForce = 7f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        // Check if player hit from above
        if (collision.contacts[0].normal.y < -0.5f)
        {
            // Kill enemy
            GetComponent<EnemyHealth>()?.Die();

            // Bounce player
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
        }
        else
        {
            // Side hit → damage player
            collision.gameObject.GetComponent<Health>()?.TakeDamage(1);
        }
    }
}
