using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] GameStateSO _state = default;
    [SerializeField] InputReaderSO _inputReader = default;

    void OnEnable()
    {
        _state.StateChangedEvent += OnStateChanged;
    }

    void OnDisable()
    {
        _state.StateChangedEvent -= OnStateChanged;
    }

    public void OnStateChanged()
    {
        switch (_state.CurrentGameState)
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
