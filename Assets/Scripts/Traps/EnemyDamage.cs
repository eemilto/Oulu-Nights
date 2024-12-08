using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage; // Amount of damage inflicted
    [SerializeField] private Animator animator; // Reference to Animator
    [SerializeField] private AudioClip damageSound; // Sound to play when damage is dealt

    private AudioSource audioSource; // Reference to AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Deal damage to the player
            collision.GetComponent<Health>().TakeDamage(damage);

            // Play the damage sound
            PlayDamageSound();
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
