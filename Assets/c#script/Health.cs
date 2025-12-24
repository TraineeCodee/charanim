using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    int currentHealth;

    [Header("UI")]
    public Image[] hearts;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip damageSound;
    public AudioClip deathSound;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // 🔊 Play damage sound
        if (audioSource && damageSound)
            audioSource.PlayOneShot(damageSound);

        UpdateHearts();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHealth;
        }
    }

    void Die()
    {
        // 🔊 Play death sound
        if (audioSource && deathSound)
            audioSource.PlayOneShot(deathSound);

        Destroy(gameObject, 0.1f);
    }
}
