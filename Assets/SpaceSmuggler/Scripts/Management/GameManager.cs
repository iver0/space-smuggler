using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputActions InputActions;

    void Awake()
    {
        // Initialize singleton GameManager
        if (Instance != null && Instance != this)
        {
            Debug.Log("Destroying duplicate GameManager Instance");
            Destroy(this);
        }
        else
        {
            Debug.Log("Setting GameManager Instance");
            Instance = this;
        }

        // Initialize input system
        InputActions = new InputActions();
        InputActions.Player.Enable();
    }
}
