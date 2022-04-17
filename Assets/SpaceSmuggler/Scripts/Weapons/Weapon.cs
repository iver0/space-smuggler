using System.Collections;
using UnityEngine;

namespace SpaceSmuggler
{
	/// <summary>
	/// Base class for all weapons.
	/// </summary>
	public class Weapon : MonoBehaviour
	{
		[SerializeField] InputReaderSO _inputReader = default;
		[SerializeField] WeaponSO _weapon = default;
		[SerializeField] GameObject _bulletPrefab;
		[SerializeField] Transform _bulletParent;
		[SerializeField] Transform _firePoint;
		Transform _player;
		Vector2 _look;
		Vector2 _mousePosition;
		Coroutine _firingRoutine;
		bool _attackCanceled;

		void OnEnable()
		{
			_player = transform.parent.transform.parent.transform;

			_inputReader.LookEvent += OnLook;
			_inputReader.AttackEvent += OnAttack;
			_inputReader.AttackCanceledEvent += OnAttackCanceled;
		}

		void OnDisable()
		{
			_inputReader.LookEvent -= OnLook;
			_inputReader.AttackEvent -= OnAttack;
			_inputReader.AttackCanceledEvent -= OnAttackCanceled;
		}

		void Update()
		{
			_mousePosition = Camera.main.ScreenToWorldPoint(_look);
		}

		void Fire()
		{
			_weapon.FiringSound.Play();

			// Create a bullet particle
			GameObject bullet = Instantiate(
				_bulletPrefab,
				_firePoint.position,
				_firePoint.rotation,
				_bulletParent
			);
			bullet
				.GetComponent<Rigidbody2D>()
				.AddForce(_firePoint.up * Random.Range(49f, 50f), ForceMode2D.Impulse);
			Destroy(bullet, 1f);

			// Check for hit
			RaycastHit2D hit = Physics2D.Raycast(_player.position, _mousePosition);
			if (hit && hit.transform.TryGetComponent<Target>(out var target))
				target.TakeDamage(_weapon.Damage);
		}

		void Stop()
		{
			if (_firingRoutine != null)
			{
				StopCoroutine(_firingRoutine);
				_firingRoutine = null;
				_attackCanceled = false;
			}
		}

		IEnumerator FiringRoutine()
		{
			do
			{
				Fire();
				yield return new WaitForSeconds(_weapon.FireRate);
			} while (!_attackCanceled);
			Stop();
		}

		// Event listeners
		void OnLook(Vector2 look)
		{
			_look = look;
		}

		void OnAttack()
		{
			if (_firingRoutine == null)
				_firingRoutine = StartCoroutine(FiringRoutine());
			if (!_weapon.IsAutomatic)
				_attackCanceled = true;
		}

		void OnAttackCanceled()
		{
			_attackCanceled = true;
		}
	}
}
