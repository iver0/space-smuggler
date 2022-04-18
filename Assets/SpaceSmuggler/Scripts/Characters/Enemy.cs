using UnityEngine;

namespace SpaceSmuggler
{
	public class Enemy : MonoBehaviour, IBot
	{
		[SerializeField] Player _player;
		StateController _controller;

		void OnEnable()
		{
			_controller = GetComponent<StateController>();
			_controller.SetupAI(true);
		}

		void OnDisable()
		{
			_controller.SetupAI(false);
		}

		public void Attack(int damage)
		{
			_player.TakeDamage(damage);
		}
	}
}
