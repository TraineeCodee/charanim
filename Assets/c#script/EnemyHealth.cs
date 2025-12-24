using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    Animator animator;
    Collider2D col;
    Patrol patrol;

    void Awake()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        patrol = GetComponent<Patrol>();
    }

    public void Die()
    {
        // Stop enemy movement
        if (patrol != null)
            patrol.enabled = false;

        // Disable collision
        if (col != null)
            col.enabled = false;

        // Play die animation
        if (animator != null)
            animator.SetTrigger("die");

        // Destroy after animation
        StartCoroutine(DestroyAfter());
    }

    IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
