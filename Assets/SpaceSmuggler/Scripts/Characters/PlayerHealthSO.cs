using UnityEngine;

namespace SpaceSmuggler
{
	/// <summary>
	/// Class for player health manipulations.
	/// </summary>
	[CreateAssetMenu(menuName = "Gameplay/Player/Health")]
	public class PlayerHealthSO : ScriptableObject
	{
		[SerializeField] PlayerDataSO _playerData = default;

		/// <summary>
		/// When called, increments health and max health of the player if eligible to.
		/// </summary>
		public void OnCollect(ItemSO item)
		{
			if (item.NewMax != _playerData.MaxHealth)
			{
				_playerData.MaxHealth = item.NewMax;
				item.IsCollected = true;
			}

			// Even if player's health is above max health, it'll change it, so health stays legal.
			if (_playerData.Health != _playerData.MaxHealth)
			{
				if (_playerData.Health + item.Increment < _playerData.MaxHealth)
				{
					_playerData.Health += item.Increment;
				}
				else
				{
					_playerData.Health = _playerData.MaxHealth;
				}

				item.IsCollected = true;
			}
		}
	}
}
