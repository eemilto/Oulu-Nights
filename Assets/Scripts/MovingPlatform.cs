using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 pointA; // Starting point
    public Vector3 pointB; // Ending point
    public float speed = 2f;

    private Vector3 target;

    void Start()
    {
        // Set initial target to point B
        target = pointB;
    }

    void Update()
    {
        // Move the platform towards the target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Check if the platform has reached the target
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            // Switch to the other point
            target = target == pointA ? pointB : pointA;
        }
    }

    // Remove 'private' from these methods
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
