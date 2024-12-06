using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    [SerializeField] private float damageAmount = 50f; // Damage dealt to the enemy
    [SerializeField] private float bounceForce = 10f; // Upward force applied to the player

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Salmon"))
        {
            var salmon = other.GetComponent<EnemyController>();
            if (salmon != null)
            {
                salmon.TakeDamage(damageAmount); // Apply damage
            }
        }

        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Check if the player is coming from above
                if (other.transform.position.y > transform.position.y)
                {
                    // Apply upward bounce force
                    playerRb.velocity = new Vector2(playerRb.velocity.x, bounceForce);
                }
            }
        }
    }
}
