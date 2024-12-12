using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private float speedMultiplier = 1f; // Multiplier for platform effects

    private void Awake()
    {
        // Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = SimpleInput.GetAxis("Horizontal");

        // Flip player when moving left & right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        // Wall jump logic
        if (wallJumpCooldown > 0.2f)
        {
            // Apply speed multiplier for slowed platforms
            float movementSpeed = horizontalInput * speed * speedMultiplier;
            if (!isGrounded())
            {
                // Reduce air control
                movementSpeed *= 0.8f;
            }
            body.velocity = new Vector2(movementSpeed, body.velocity.y);

            // Jump logic
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                Jump();
                SoundManager.instance.PlaySound(jumpSound);
            }

            // Apply custom gravity for better jump feel
            if (body.velocity.y < 0) // Falling
            {
                body.gravityScale = 5; // Stronger gravity when falling
            }
            else if (body.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) // Short hop
            {
                body.gravityScale = 4; // Less gravity if the player releases jump early
            }
            else
            {
                body.gravityScale = 3; // Normal gravity
            }
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }
    }

    public void Jump()
    {
        if (isGrounded())
        {
            SoundManager.instance.PlaySound(jumpSound);
            anim.SetTrigger("jump");
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            wallJumpCooldown = 0;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }

    // Function to modify the speed multiplier
    public void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
    }
}
