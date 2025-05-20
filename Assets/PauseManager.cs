using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // Assign in Inspector

    private bool isPaused = false;

    private void Awake()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(false); // Hide pause menu on awake
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Ensure time is resumed
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Ensure time is resumed
        SceneManager.LoadScene("StartMenu");
    }

    public void ExitGame()
    {
        Time.timeScale = 1f; // Ensure time is resumed before quitting
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
#else
        Application.Quit(); // Quit the built game
#endif
    }
}
