using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.Input.Player.Pause.triggered)
        {
            //If paused, resume the game
            if (isPaused)
            {
                ResumeGame();
            }
            // If unpaused, pause the game
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        GameManager.Instance.Input.Player.Movement.Disable();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        GameManager.Instance.Input.Player.Movement.Enable();
    }

    public void QuitGame()
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }
}
