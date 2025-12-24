using UnityEngine;

public class Fall : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasFallen = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasFallen) return;

        if (other.CompareTag("Player"))
        {
            hasFallen = true;

            // Enable falling
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 5f;
        }
    }
}
