using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private int currentSceneIndex;

    public bool isPaused = false;
    public GameObject pauseScreen;

    private void Start()
    {
        // Get the current scene index when the script starts
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void GoToPlayScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToHomeScene()
    {
        SceneManager.LoadScene(0);
        if(isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
        pauseScreen.SetActive(true);

    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
        pauseScreen.SetActive(false);
    }

    public void SaveGame()
    {
        // Save current scene index and pause state
        PlayerPrefs.SetInt("SavedSceneIndex", currentSceneIndex);
        PlayerPrefs.SetInt("IsGamePaused", isPaused ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadSavedGame()
    {
        // Load saved scene index and pause state
        int savedSceneIndex = PlayerPrefs.GetInt("SavedSceneIndex", 0);
        bool savedIsPaused = PlayerPrefs.GetInt("IsGamePaused", 0) == 1;

        // Load the saved scene
        SceneManager.LoadScene(savedSceneIndex);

        // If the game was saved while paused, pause it again
        if (savedIsPaused)
            PauseGame();
    }
}