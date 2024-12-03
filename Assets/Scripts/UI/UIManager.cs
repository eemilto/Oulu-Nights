using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header ("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header ("Options")]
    [SerializeField] private GameObject options;

    [Header ("Main Menu")]
    [SerializeField] private GameObject mainMenu;

    [Header ("Cutscene 1")]
    [SerializeField] private GameObject cutScene1;

    [Header ("Cutscene 2")]
    [SerializeField] private GameObject cutScene2;

    [Header ("Cutscene 3")]
    [SerializeField] private GameObject cutScene3;

    [Header ("Level 1")]
    [SerializeField] private GameObject leVel1;

    [Header ("Level 2")]
    [SerializeField] private GameObject leVel2;


    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If pause screen already active unpause and viceversa
            PauseGame(!pauseScreen.activeInHierarchy);
        }
    }

    #region Game Over
    //Activate game over screen
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    //Restart level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Start Game
    public void CutScene1()
    {
        SceneManager.LoadScene(1);
    }



    //Cutscene 2
    public void CutScene2()
    {
        SceneManager.LoadScene(2);
    }

    //Cutscene 3
    public void CutScene3()
    {
        SceneManager.LoadScene(3);
    }

    //Level 1
    public void Level1()
    {
        SceneManager.LoadScene(4);
    }

    //Level 2
    public void Level2()
    {
        SceneManager.LoadScene(5);
    }

    //Options
    public void Options()
    {
        SceneManager.LoadScene(6);
    }

    //Quit game/exit play mode if in Editor
    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
#endif
    }
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        //If status == true pause | if status == false unpause
        pauseScreen.SetActive(status);

        //When pause status is true change timescale to 0 (time stops)
        //when it's false change it back to 1 (time goes by normally)
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
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