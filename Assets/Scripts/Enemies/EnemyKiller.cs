using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    [SerializeField] private float damageAmount = 50f; // Damage dealt to the salmon

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
    }
}
