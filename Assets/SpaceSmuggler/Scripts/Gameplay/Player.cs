using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    PlayerInput playerInput;
    PlayerInputActions playerInputActions;
    // public Animator animator; // TODO: Create animation system

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Move(inputVector);
    }

    public void Move(Vector2 Movement)
    {
        if (Movement.x == 0 && Movement.y == 0)
        {
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
            return;
        }
        else
        {
            rb.isKinematic = false;
            rb.MovePosition(rb.position + Movement * speed * Time.deltaTime);
        }
    }
}
