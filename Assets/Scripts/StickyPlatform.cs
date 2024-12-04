using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
   public float slowMultiplier = 0.5f; // Speed multiplier (0.5 = half speed)

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Access the player's movement script and apply the slow effect
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.SetSpeedMultiplier(slowMultiplier);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reset the player's speed multiplier to normal
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.SetSpeedMultiplier(1f);
            }
        }
    }
}