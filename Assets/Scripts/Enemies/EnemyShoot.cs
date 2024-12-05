using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab
    public Transform shootPoint;       // Where the projectile spawns
    public float projectileSpeed = 10f;
    public float attackCooldown = 2f;
    public float detectionRange = 10f;
    public LayerMask playerLayer; // Layer mask for detecting the player

    private float lastAttackTime;
    private Transform player;

    void Update()
    {
        DetectPlayer();

        if (player != null && Time.time >= lastAttackTime + attackCooldown)
        {
            Shoot();
            lastAttackTime = Time.time;
        }
    }

    void DetectPlayer()
    {
        // Use a raycast or circle check to detect the player
        Collider2D detectedPlayer = Physics2D.OverlapCircle(transform.position, detectionRange, playerLayer);
        if (detectedPlayer != null)
        {
            player = detectedPlayer.transform;
        }
        else
        {
            player = null;
        }
    }

    void Shoot()
    {
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        // Add velocity to the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Shoot towards the player's direction
            Vector2 direction = (player.position - shootPoint.position).normalized;
            rb.velocity = direction * projectileSpeed;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw the detection range in the Scene view for debugging
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
