using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    public GameObject victoryScreen; // Reference to the victory screen

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Display the victory screen
            if (victoryScreen != null)
            {
                victoryScreen.SetActive(true);
            }

            // End the level (optionally load a new scene or pause game)
            Time.timeScale = 0f; // Pause the game

            // Optionally, you can load the next level
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
