using UnityEngine;

namespace SpaceSmuggler
{
	public class Enemy : MonoBehaviour, IBot
	{
		[SerializeField] Player _player;
		StateController _controller;

		void Start()
		{
			_controller = GetComponent<StateController>();
			_controller.SetupAI(true);
		}

		public void Attack(int damage)
		{
			_player.TakeDamage(damage);
		}
	}
}
