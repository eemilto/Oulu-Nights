using UnityEngine;

public class CircularPlatform : MonoBehaviour
{
    public Transform centerPoint; // The central point around which the platform will move
    public float radius = 5f; // Radius of the circular path
    public float speed = 1f; // Speed of rotation

    private float angle = 0f; // Current angle of rotation

    void Update()
    {
        // Increment the angle based on speed
        angle += speed * Time.deltaTime;

        // Keep the angle within 0 to 360 degrees
        if (angle > 360f)
        {
            angle -= 360f;
        }

        // Calculate the new position of the platform
        float x = centerPoint.position.x + Mathf.Cos(angle) * radius;
        float y = centerPoint.position.y + Mathf.Sin(angle) * radius;

        // Update the platform's position
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
