using UnityEngine;

public class SlipperyPlatform : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float frictionOnSlippery = 0.98f; // Between 0 and 1, closer to 1 for more slipperiness
    private bool isOnSlipperyPlatform = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        if (isOnSlipperyPlatform)
        {
            // Apply reduced friction on slippery platform
            rb.velocity = new Vector2(rb.velocity.x * frictionOnSlippery, rb.velocity.y);
            rb.AddForce(new Vector2(moveInput * moveSpeed, 0));
        }
        else
        {
            // Regular movement
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slippery"))
        {
            isOnSlipperyPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slippery"))
        {
            isOnSlipperyPlatform = false;
        }
    }
}
void Update()
{
    float moveInput = Input.GetAxis("Horizontal");

    if (isOnSlipperyPlatform)
    {
        // On a slippery platform, add a force to move without immediately stopping
        rb.AddForce(new Vector2(moveInput * moveSpeed, 0), ForceMode2D.Force);
    }
    else
    {
        // On a regular surface, set the velocity directly for more control
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}
