using System.Collections;
using System.Collections.Generic;
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
        // GameManager.Instance.InputActions.Player.Pause.performed += PauseResume;
        // GameManager.Instance.InputActions.Pause.Pause.performed += PauseResume;
        if (GameManager.Instance.InputActions.Player.Pause.triggered)
        {
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

    // Process pause key input
    /*
    void PauseResume(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // If paused, resume the game
            if (isPaused)
            {
                ResumeGame();
                GameManager.Instance.InputActions.Player.Enable();
                GameManager.Instance.InputActions.Pause.Disable();
            }
            // If unpaused, pause the game
            else
            {
                PauseGame();
                GameManager.Instance.InputActions.Player.Disable();
                GameManager.Instance.InputActions.Pause.Enable();
            }
        }
    }
    */

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        GameManager.Instance.InputActions.Player.Movement.Disable();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        GameManager.Instance.InputActions.Player.Movement.Enable();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
