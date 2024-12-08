using UnityEngine;

public class MovingEnemyPatrol : MonoBehaviour
{
    public Transform pointA; // Reference to the transform for Point A
    public Transform pointB; // Reference to the transform for Point B
    public float speed = 2f;
    public AudioClip movementSound; // Sound to play while moving

    private Transform target; // Current target point
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer for flipping
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Start by moving toward Point B
        target = pointB;

        // Get the SpriteRenderer component attached to the enemy
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Configure the AudioSource
        if (audioSource != null)
        {
            audioSource.clip = movementSound;
            audioSource.loop = true; // Enable looping for continuous playback
            audioSource.Play(); // Start playing the movement sound
        }
    }

    void Update()
    {
        // Move the enemy toward the target point
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Flip the sprite based on the target direction
        if (target == pointB && spriteRenderer.flipX) spriteRenderer.flipX = false;
        else if (target == pointA && !spriteRenderer.flipX) spriteRenderer.flipX = true;

        // Switch target when reaching the current target point
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target = target == pointA ? pointB : pointA;
        }
    }
}
