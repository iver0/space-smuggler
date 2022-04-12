using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameStateSO _gameState = default;
    [SerializeField] InputReaderSO _inputReader = default;

    void OnEnable()
    {
        _gameState.GameStateChangedEvent += OnStateChanged;
    }

    void OnDisable()
    {
        _gameState.GameStateChangedEvent -= OnStateChanged;
    }

    public void OnStateChanged()
    {
        switch (_gameState.CurrentGameState)
        {
            case GameState.Play:
                _inputReader.EnablePlayInput();
                Time.timeScale = 1f;
                break;
            case GameState.Pause:
                _inputReader.EnablePauseInput();
                Time.timeScale = 0f;
                break;
        }
    }
}
