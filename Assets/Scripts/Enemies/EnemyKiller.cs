using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider that entered has the "Player" tag
        if (gameObject.CompareTag("Player"))
        {
            // Then check if the other GameObject has the "Salmon" tag
            if (other.gameObject.CompareTag("Salmon"))
            {
                var salmon = other.gameObject.GetComponent<EnemyController>();
                salmon.Kill();
            }
        }
    }
}
