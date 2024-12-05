using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float damage = 10f; // Damage dealt to the player
    public float lifetime = 5f; // How long the projectile lasts

    void Start()
    {
        Destroy(gameObject, lifetime); // Destroy after its lifetime
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the Health script
        Health playerHealth = other.GetComponent<Health>();
        if (playerHealth != null)
        {
            // Deal damage to the player
            playerHealth.TakeDamage(damage);
        }

        // Destroy the projectile after hitting the target
        Destroy(gameObject);
    }
}
