using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] Player _player;

	public void Attack(int damage)
	{
		_player.TakeDamage(damage);
	}
}
