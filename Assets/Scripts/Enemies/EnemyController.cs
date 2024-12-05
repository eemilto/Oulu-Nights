using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator; // Reference to Animator
    [SerializeField] private float health = 100f; // Health of the salmon
    [SerializeField] private float damageAnimationDuration = 0.5f; // Duration of damage animation
    [SerializeField] private float deathAnimationDuration = 1f; // Duration of death animation

    private bool isDying = false; // To prevent overlapping animations

    // Method to apply damage to the salmon
    public void TakeDamage(float damage)
    {
        if (isDying) return; // Prevent further actions if the salmon is already dying

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
            StartCoroutine(WaitForDamageAnimation()); // Wait before allowing further actions
        }
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
            StartCoroutine(HandleDeath());
        }
        else
        {
            Kill(); // Fallback if no animator is present
        }
    }

    // Coroutine to handle object destruction after death animation
    private IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(deathAnimationDuration); // Wait for death animation
        Destroy(gameObject); // Destroy the salmon
    }

    // Immediate destruction method
    public void Kill()
    {
        Destroy(gameObject); // Destroy the salmon immediately
    }
}
