using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private int currentSceneIndex;

    public void Start()
    {
        // Get the current scene index when the script starts
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToPlayScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToHomeScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
