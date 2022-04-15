using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] PlayerDataSO _playerData = default;
	public static UnityAction<GameObject> ItemCollected;
	[Header("Broadcasting on")]
	[SerializeField] VoidEventChannelSO _playerDeathChannel = default;
	int _tmpMaxHealth;

	void OnEnable()
	{
		Medkit.MedkitCollected += OnItemCollected;
		Morphine.MorphineCollected += OnItemCollected;
	}

	void OnDisable()
	{
		Medkit.MedkitCollected -= OnItemCollected;
		Morphine.MorphineCollected -= OnItemCollected;
	}

	void OnItemCollected(GameObject item, int value)
	{
		if (_playerData.Health != _playerData.MaxHealth)
		{
			if (_playerData.Health + value < _playerData.MaxHealth)
			{
				_playerData.Health += value;
			}
			else
			{
				_playerData.Health = _playerData.MaxHealth;
			}
			ItemCollected?.Invoke(item);
		}
	}

	void OnItemCollected(GameObject item, int value, int maxValue)
	{
		_playerData.MaxHealth = maxValue;
		OnItemCollected(item, value);
	}

	void OnItemCollected(GameObject item, int value, int maxValue, bool isTmp, int duration)
	{
		if (isTmp)
		{
			_tmpMaxHealth = _playerData.MaxHealth;
			StartCoroutine(FadeEffect(duration));
		}
		OnItemCollected(item, value, maxValue);
	}

	IEnumerator FadeEffect(int duration)
	{
		yield return new WaitForSeconds(duration);
		OnItemCollected(gameObject, 0, _tmpMaxHealth);
	}
}
