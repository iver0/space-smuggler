using System.Collections;
using UnityEngine;

namespace SpaceSmuggler
{
	/// <summary>
	/// Player base class.
	/// </summary>
	public class Player : MonoBehaviour
	{
		#region Fields
		[SerializeField] PlayerHealthSO Health = default;
		//[SerializeField] PlayerArmorSO Armor = default;
		[SerializeField] InputReaderSO _inputReader = default;
		[SerializeField] PlayerDataSO _playerData = default;
		[Header("Listening on")]
		[SerializeField] ItemEventChannelSO _healthItemEvent = default;
		Rigidbody2D _rb;
		Vector2 _look;
		Vector2 _moveDirection;
		Vector2 _mousePosition;
		#endregion

		#region LifeCycle
		void Awake()
		{
			_rb = GetComponent<Rigidbody2D>();
		}

		void OnEnable()
		{
			_healthItemEvent.OnEventRaised += OnCollect;
			_inputReader.MoveEvent += OnMove;
			_inputReader.LookEvent += OnLook;
		}

		void OnDisable()
		{
			_healthItemEvent.OnEventRaised -= OnCollect;
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
		#endregion

		#region PublicMethods
		/// <summary>
		/// Decrease player health by damage amount.
		/// </summary>
		public void TakeDamage(int damage)
		{
			_playerData.Health -= damage;
		}

		IEnumerator FadeEffect(ItemSO item, int maxHealth)
		{
			yield return new WaitForSeconds(item.Duration);
			int tmpIncrement = item.Increment;
			int tmpNewMax = item.NewMax;
			item.Increment = 0;
			item.NewMax = maxHealth;
			Health.OnCollect(item);
			item.Increment = tmpIncrement;
			item.NewMax = tmpNewMax;
		}
		#endregion

		#region EventListeners
		void OnCollect(ItemSO item)
		{
			int tmp = _playerData.MaxHealth;
			Health.OnCollect(item);
			if (item.Duration > 0)
				StartCoroutine(FadeEffect(item, tmp));
		}

		void OnMove(Vector2 move)
		{
			_moveDirection = move;
		}

		void OnLook(Vector2 look)
		{
			_look = look;
		}
		#endregion
	}
}
