using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    public PlayerData playerData;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ArmorText;
    float speed = 5f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HealthText.text = $"Health: {playerData.Health}";
        ArmorText.text = $"Armor: {playerData.Armor}";
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
