using System.Collections;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] InputReaderSO _inputReader = default;
    [SerializeField] WeaponSO _weapon = default;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _bulletParent;
    [SerializeField] Transform _playerTransform;
    [SerializeField] Transform _firePoint;
    Vector2 _look;
    Vector2 _mousePosition;
    Coroutine _firingRoutine;
    bool _attackCanceled;

    void OnEnable()
    {
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
        // Play the firing sound
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        _weapon.FiringSound.Play(audioSource);

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

        // Check for hit
        RaycastHit2D hit = Physics2D.Raycast(_playerTransform.position, _mousePosition);
        if (hit)
        {
            Target target = hit.transform.GetComponent<Target>();
            target?.TakeDamage(_weapon.Damage);
        }
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
