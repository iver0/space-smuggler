using UnityEngine;

namespace SpaceSmuggler
{
	public class Enemy : MonoBehaviour, IBot
	{
		[SerializeField] Player _player;

		public void Attack(int damage)
		{
			_player.TakeDamage(damage);
		}
	}
}
