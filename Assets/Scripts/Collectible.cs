using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject victoryScreen; // Reference to the victory screen
    public Animator confettiAnimator; // Reference to the confetti animator

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Play the confetti animation
            if (confettiAnimator != null)
            {
                confettiAnimator.SetTrigger("PlayConfetti");
            }

            // Display the victory screen
            if (victoryScreen != null)
            {
                victoryScreen.SetActive(true);
            }

            // Pause the game or trigger level completion
            Time.timeScale = 0f;
        }
    }
}
