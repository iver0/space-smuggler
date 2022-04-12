using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static event UnityAction<GameState> ChangeGameStateEvent;

    [SerializeField] GameObject _pauseMenu;
    [SerializeField] InputReaderSO _inputReader;

    void Awake()
    {
        _pauseMenu.SetActive(false);
    }

    void OnEnable()
    {
        _inputReader.PauseEvent += OnPause;
        _inputReader.ResumeEvent += OnResume;
    }

    void OnDisable()
    {
        _inputReader.PauseEvent -= OnPause;
        _inputReader.ResumeEvent -= OnResume;
    }

    public void QuitGame()
    {
        OnResume();
        SceneManager.LoadScene("MainMenu");
    }

    // Event listeners
    void OnPause()
    {
        ChangeGameStateEvent?.Invoke(GameState.Pause);
        _pauseMenu.SetActive(true);
    }

    void OnResume()
    {
        ChangeGameStateEvent?.Invoke(GameState.Play);
        _pauseMenu.SetActive(false);
    }
}
