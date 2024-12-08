using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator; // Reference to Animator
    [SerializeField] private float health = 100f; // Health of the enemy
    [SerializeField] private float damageAnimationDuration = 0.5f; // Duration of damage animation
    [SerializeField] private float deathAnimationDuration = 1f; // Duration of death animation
    [SerializeField] private AudioClip damageSound; // Sound to play when taking damage
    [SerializeField] private AudioClip deathSound; // Sound to play when dying

    private AudioSource audioSource; // Reference to AudioSource component
    private bool isDying = false; // To prevent overlapping animations

    private void Start()
    {
        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Method to apply damage to the enemy
    public void TakeDamage(float damage)
    {
        if (isDying) return; // Prevent further actions if the enemy is already dying

        health -= damage;

        if (health <= 0)
        {
            TriggerDeathAnimation(); // Trigger death if health is 0 or below
        }
        else
        {
            TriggerDamageAnimation(); // Play damage animation
        }
    }

    // Trigger damage animation
    private void TriggerDamageAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Hurt"); // Trigger the damage animation
        }
        PlaySound(damageSound); // Play the damage sound
        StartCoroutine(WaitForDamageAnimation()); // Wait before allowing further actions
    }

    // Wait for the damage animation to finish
    private IEnumerator WaitForDamageAnimation()
    {
        yield return new WaitForSeconds(damageAnimationDuration);
    }

    // Trigger death animation
    public void TriggerDeathAnimation()
    {
        if (isDying) return; // Ensure death logic runs only once

        isDying = true;

        if (animator != null)
        {
            animator.SetTrigger("Die"); // Trigger death animation
        }
        PlaySound(deathSound); // Play the death sound
        StartCoroutine(HandleDeath());
    }

    // Coroutine to handle object destruction after death animation
    private IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(deathAnimationDuration); // Wait for death animation
        Destroy(gameObject); // Destroy the enemy
    }

    // Immediate destruction method
    public void Kill()
    {
        Destroy(gameObject); // Destroy the enemy immediately
    }

    // Play a specific sound
    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
