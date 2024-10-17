using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Salmon"))
        {
            var Salmon = other.gameObject.GetComponent<EnemyController>();
            Salmon.Kill();
        }
    }
}
