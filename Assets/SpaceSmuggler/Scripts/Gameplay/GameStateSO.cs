using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Play,
    Pause,
}

[CreateAssetMenu(fileName = "GameState", menuName = "Gameplay/GameState")]
public class GameStateSO : ScriptableObject
{
    public event UnityAction GameStateChangedEvent;
    public GameState CurrentGameState => _currentGameState;
    [SerializeField] GameState _currentGameState = default;

    void OnEnable()
    {
        PauseMenu.ChangeGameStateEvent += OnChangeGameState;
    }

    void OnDisable()
    {
        PauseMenu.ChangeGameStateEvent -= OnChangeGameState;
    }

    public void OnChangeGameState(GameState newGameState)
    {
        if (newGameState == CurrentGameState)
            return;
        _currentGameState = newGameState;
        GameStateChangedEvent?.Invoke();
    }
}
