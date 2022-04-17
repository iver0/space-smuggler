using UnityEngine;
using UnityEngine.Events;

namespace SpaceSmuggler
{
	public class PlayerArmor : MonoBehaviour
	{
		public static UnityAction<GameObject> ItemCollected;
		[SerializeField] PlayerDataSO _playerData = default;

		void OnEnable()
		{
		}

		void OnDisable()
		{
		}

		void OnItemCollected(GameObject item, int value)
		{
			if (_playerData.Armor != _playerData.MaxArmor)
			{
				if (_playerData.Armor + value < _playerData.MaxArmor)
				{
					_playerData.Armor += value;
				}
				else
				{
					_playerData.Armor = _playerData.MaxArmor;
				}
				ItemCollected?.Invoke(item);
			}
		}

		void OnItemCollected(GameObject item, int value, int maxValue)
		{
			_playerData.MaxArmor = maxValue;
			OnItemCollected(item, value);
		}
	}
}
