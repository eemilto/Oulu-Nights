using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveLeft : MonoBehaviour
{
    public float speed = 2f; // Speed of the enemy

    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the enemy
        rb = GetComponent<Rigidbody2D>();
        
        // Set the velocity to move to the left
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    void Update()
    {
        // Maintain the leftward velocity in case other forces try to change it
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
}
