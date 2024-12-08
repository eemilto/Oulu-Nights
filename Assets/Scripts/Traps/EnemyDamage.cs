using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage; // Amount of damage inflicted
    [SerializeField] private Animator animator; // Reference to Animator
    [SerializeField] private AudioClip damageSound; // Sound to play when damage is dealt
    private string attack = "Attack"; // Animator trigger for attack animation

    private AudioSource audioSource; // Reference to AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Play attack animation
            PlayAttackAnimation();

            // Deal damage to the player
            collision.GetComponent<Health>().TakeDamage(damage);

            // Play the damage sound
            PlayDamageSound();
        }
    }

    private void PlayAttackAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack"); // Trigger the attack animation
        }
    }

    private void PlayDamageSound()
    {
        if (audioSource != null && damageSound != null)
        {
            audioSource.PlayOneShot(damageSound);
        }
    }
}
