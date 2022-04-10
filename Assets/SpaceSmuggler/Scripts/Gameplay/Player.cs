using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    InputActions Input;
    public static InputAction move;
    public static InputAction look;
    public static InputAction pause;
    Vector2 moveDirection;
    Vector2 mousePosition;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Input = new InputActions();
    }

    void OnEnable()
    {
        move = Input.Player.Move;
        move.Enable();
        look = Input.Player.Look;
        look.Enable();
        pause = Input.Player.Pause;
        pause.Enable();
    }

    void OnDisable()
    {
        move.Disable();
        look.Disable();
        pause.Disable();
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(look.ReadValue<Vector2>());
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * playerData.MoveSpeed, moveDirection.y * playerData.MoveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
