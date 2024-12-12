using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Options")]
    [SerializeField] private GameObject options;

    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenu;

    [Header("Cutscene 1")]
    [SerializeField] private GameObject cutScene1;

    [Header("Cutscene 2")]
    [SerializeField] private GameObject cutScene2;

    [Header("Cutscene 3")]
    [SerializeField] private GameObject cutScene3;

    [Header("Level 1")]
    [SerializeField] private GameObject leVel1;

    [Header("Level 2")]
    [SerializeField] private GameObject leVel2;

    private void Awake()
    {
        gameOverScreen.SetActive(false); // Initially hide the Game Over screen
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If pause screen already active, unpause, and vice versa
            PauseGame(!pauseScreen.activeInHierarchy);
        }
    }

    #region Game Over
    // Activate game over screen
    public void GameOver()
    {
        gameOverScreen.SetActive(true); // Show the Game Over screen
        SoundManager.instance.PlaySound(gameOverSound); // Play Game Over sound

        // Optional: Pause the game when the Game Over screen shows
        Time.timeScale = 0;
    }

    // Restart level
    public void Restart()
    {
        Debug.Log("Restarting level...");

        // Reset Time.timeScale to normal speed
        Time.timeScale = 1;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Return to main menu
    public void MainMenu()
    {
        Debug.Log("Returning to Main Menu...");

        // Reset Time.timeScale to normal speed
        Time.timeScale = 1;

        // Load the main menu scene (assuming index 0)
        SceneManager.LoadScene(0);
    }

    // Start Game
    public void CutScene1()
    {
        Debug.Log("Starting Cutscene 1...");
        SceneManager.LoadScene(1);
    }

    // Cutscene 2
    public void CutScene2()
    {
        Debug.Log("Starting Cutscene 2...");
        SceneManager.LoadScene(2);
    }

    // Cutscene 3
    public void CutScene3()
    {
        Debug.Log("Starting Cutscene 3...");
        SceneManager.LoadScene(3);
    }

    // Level 1
    public void Level1()
    {
        Debug.Log("Loading Level 1...");
        SceneManager.LoadScene(4);
    }

    // Level 2
    public void Level2()
    {
        Debug.Log("Loading Level 2...");
        SceneManager.LoadScene(5);
    }

    // Options
    public void Options()
    {
        Debug.Log("Opening Options...");
        SceneManager.LoadScene(6);
    }

    // Quit game/exit play mode if in Editor
    public void Quit()
    {
        Debug.Log("Quitting the game...");
        Application.Quit(); // Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Exits play mode (editor only)
#endif
    }
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        Debug.Log(status ? "Pausing game..." : "Unpausing game...");

        // If status == true, pause; if status == false, unpause
        pauseScreen.SetActive(status);

        // When pause status is true, change timescale to 0 (time stops)
        // When false, change it back to 1 (time goes by normally)
        Time.timeScale = status ? 0 : 1;
    }

    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }

    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }
    #endregion
}
