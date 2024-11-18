using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform[] waypoints; // Add two or more waypoints in the Inspector
    private int currentWaypointIndex = 0;
    private float waypointDetectionThreshold = 0.2f; // Increase this threshold if needed

    private void Update()
    {
        PatrolMovement();
    }

    private void PatrolMovement()
    {
        // Check if we have reached the current waypoint
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < waypointDetectionThreshold)
        {
            // Switch to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

            // Flip the enemy to face the direction of movement
            Flip();
        }

        // Move towards the current waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
    }

    private void Flip()
    {
        // Flip the enemy sprite horizontally based on direction
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
