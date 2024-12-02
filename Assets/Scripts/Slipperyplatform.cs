using UnityEngine;

public class SlipPlatform : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the player
    public float frictionOnSlip = 0.95f; // Friction multiplier for slip platforms

    private bool isOnSlipPlatform = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (isOnSlipPlatform)
        {
            // Add horizontal force with reduced friction
            rb.velocity = new Vector2(rb.velocity.x * frictionOnSlip, rb.velocity.y);
            rb.AddForce(new Vector2(moveInput * moveSpeed, 0), ForceMode2D.Force);
        }
        else
        {
            // Directly control velocity on regular platforms
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slip"))
        {
            isOnSlipPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slip"))
        {
            isOnSlipPlatform = false;
        }
    }
}
