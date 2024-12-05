using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; // Sound for reaching a checkpoint
    private Transform currentCheckpoint; // Holds the position of the last checkpoint
    private Health playerHealth; // Reference to the player's health component
    private UIManager uiManager; // Reference to UIManager for handling game over

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    /// <summary>
    /// Handles respawn logic. Moves player to the last checkpoint or triggers Game Over if no checkpoint exists.
    /// </summary>
    public void RespawnCheck()
    {
        if (playerHealth.IsDead())
        {
            // Pause the game
            Time.timeScale = 0;

            if (currentCheckpoint == null)
            {
                // No checkpoint reached, trigger game over
                uiManager.GameOver();
                return;
            }

            // Respawn logic when a checkpoint exists
            playerHealth.Respawn(); // Restore health and reset any death state
            transform.position = currentCheckpoint.position; // Move player to the checkpoint

            // Resume the game
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// Detects when the player reaches a checkpoint and updates the current checkpoint position.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint")) // Check if the object has the "Checkpoint" tag
        {
            currentCheckpoint = collision.transform; // Save the checkpoint position
            SoundManager.instance.PlaySound(checkpointSound); // Play checkpoint sound

            // Optional: Trigger checkpoint animation
            Animator checkpointAnimator = collision.GetComponent<Animator>();
            if (checkpointAnimator != null)
            {
                checkpointAnimator.SetTrigger("appear");
            }

            // Disable the checkpoint to prevent reactivation
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
