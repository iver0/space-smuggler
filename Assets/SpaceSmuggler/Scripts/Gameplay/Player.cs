using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    InputActions _input;
    public static InputAction Move;
    public static InputAction Look;
    public static InputAction Pause;
    Vector2 _moveDirection;
    Vector2 _mousePosition;
    Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _input = new InputActions();
    }

    void OnEnable()
    {
        Move = _input.Player.Move;
        Move.Enable();
        Look = _input.Player.Look;
        Look.Enable();
        Pause = _input.Player.Pause;
        Pause.Enable();
    }

    void OnDisable()
    {
        Move.Disable();
        Look.Disable();
        Pause.Disable();
    }

    void Update()
    {
        _moveDirection = Move.ReadValue<Vector2>();
        _mousePosition = Camera.main.ScreenToWorldPoint(Look.ReadValue<Vector2>());
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveDirection.x * _playerData.MoveSpeed, _moveDirection.y * _playerData.MoveSpeed);

        Vector2 aimDirection = _mousePosition - _rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = aimAngle;
    }
}
