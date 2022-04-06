using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    PlayerInput playerInput;
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
        playerInput = GetComponent<PlayerInput>();
        InputActions = new InputActions();
        InputActions.Player.Enable();
    }
}
