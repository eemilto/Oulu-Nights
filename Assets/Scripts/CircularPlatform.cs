using UnityEngine;

public class CircularPlatform : MonoBehaviour
{
    public Transform centerPoint; // The central point around which the platform will move
    public float radius = 5f; // Radius of the circular path
    public float speed = 1f; // Speed of rotation
    public float rotationOffset = 0f; // Offset angle for rotation in degrees
    public bool clockwise = true; // Determines if the rotation is clockwise or counter-clockwise

    private float angle = 0f; // Current angle of rotation

    void Update()
    {
        // Increment the angle based on speed and direction
        angle += (clockwise ? -1 : 1) * speed * Time.deltaTime;

        // Keep the angle within 0 to 360 degrees
        angle %= 360f;

        // Convert rotation offset to radians
        float offsetInRadians = Mathf.Deg2Rad * rotationOffset;

        // Calculate the new position of the platform
        float x = centerPoint.position.x + Mathf.Cos(angle + offsetInRadians) * radius;
        float y = centerPoint.position.y + Mathf.Sin(angle + offsetInRadians) * radius;

        // Update the platform's position
        transform.position = new Vector3(x, y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Make the player a child of the platform
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Detach the player from the platform
            collision.transform.SetParent(null);
        }
    }
}

