using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int Health = 100;
    public int Armor = 0;
    float speed = 5f;
    Rigidbody2D rb;

    void Awake()
    {
        // Initialize singleton Player
        if (Instance != null && Instance != this)
        {
            Debug.Log("Destroying duplicate Player Instance");
            Destroy(this);
        }
        else
        {
            Debug.Log("Setting Player Instance");
            Instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Aim();
        Move();
    }

    // Aiming
    void Aim()
    {
        // Read mouse position
        Vector3 mousePosition = Mouse.current.position.ReadValue();

        // Calculate direction to mouse position
        Vector3 dir = mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        // Calculate rotation in the direction of mouse position
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // Apply the rotation
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Movement
    void Move()
    {
        // Read movement input
        Vector2 inputVector = GameManager.Instance.InputActions.Player.Movement.ReadValue<Vector2>();

        // Stop moving if not receiving movement input
        if (inputVector.x == 0 && inputVector.y == 0)
        {
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
            return;
        }
        // Else move in the direction of movement input
        else
        {
            rb.isKinematic = false;
            rb.MovePosition(rb.position + inputVector * speed * Time.deltaTime);
        }
    }
}
