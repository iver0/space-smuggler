using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] InputReaderSO _inputReader = default;
	[SerializeField] PlayerDataSO _playerData = default;
	Rigidbody2D _rb;
	Vector2 _look;
	Vector2 _moveDirection;
	Vector2 _mousePosition;

	void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	void OnEnable()
	{
		_inputReader.MoveEvent += OnMove;
		_inputReader.LookEvent += OnLook;
	}

	void OnDisable()
	{
		_inputReader.MoveEvent -= OnMove;
		_inputReader.LookEvent -= OnLook;
	}

	void Update()
	{
		_mousePosition = Camera.main.ScreenToWorldPoint(_look);
	}

	void FixedUpdate()
	{
		_rb.velocity = new Vector2(
			_moveDirection.x * _playerData.MoveSpeed,
			_moveDirection.y * _playerData.MoveSpeed
		);

		Vector2 aimDirection = _mousePosition - _rb.position;
		float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
		_rb.rotation = aimAngle;
	}

	public void TakeDamage(int damage)
	{
		_playerData.Health -= damage;
		//if (_playerData.Health <= 0)

	}

	// Event listeners
	void OnMove(Vector2 move)
	{
		_moveDirection = move;
	}

	void OnLook(Vector2 look)
	{
		_look = look;
	}
}
