using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // TODO: Add health and armor system
    // int health = 100;
    // int armor = 0;
    public float speed = 5f;
    Rigidbody2D rb;
    PlayerInput playerInput;
    PlayerInputActions playerInputActions;
    // TODO: Add animation system
    // public Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    void Update()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        // transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, mousePosition.y));
        Vector3 dir = mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Move(inputVector);
    }

    void Move(Vector2 movement)
    {
        if (movement.x == 0 && movement.y == 0)
        {
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
            return;
        }
        else
        {
            rb.isKinematic = false;
            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        }
    }
}
