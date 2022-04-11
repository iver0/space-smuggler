using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    bool _isPaused;

    void Update()
    {
        _pauseMenu.SetActive(false);
    }

    void OnEnable()
    {
        
        Player.Pause.performed += PauseInput;
    }

    void OnDisable()
    {
        Player.Pause.performed -= PauseInput;
    }

    void PauseInput(InputAction.CallbackContext context)
    {
        if (_isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
        Player.Move.Disable();
        Player.Look.Disable();
    }

    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
        Player.Move.Enable();
        Player.Look.Enable();
    }

    public void QuitGame()
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }
}
