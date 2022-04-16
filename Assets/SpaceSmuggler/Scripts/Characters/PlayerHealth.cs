using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] PlayerDataSO _playerData = default;
	public static UnityAction<GameObject> ItemCollected;
	[Header("Broadcasting on")]
	[SerializeField] VoidEventChannelSO _playerDeathChannel = default;

	void OnEnable()
	{
		Medkit.MedkitCollected += CollectHealth;
		Morphine.MorphineCollected += CollectHealth;
	}

	void OnDisable()
	{
		Medkit.MedkitCollected -= CollectHealth;
		Morphine.MorphineCollected -= CollectHealth;
	}

	void CollectHealth(GameObject item, int value)
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

	void CollectHealth(GameObject item, int value, int maxValue)
	{
		_playerData.MaxHealth = maxValue;
		CollectHealth(item, value);
	}

	void CollectHealth(GameObject item, int value, int maxValue, int duration)
	{
		int tmp = _playerData.MaxHealth;
		StartCoroutine(FadeEffect(duration, tmp));
		CollectHealth(item, value, maxValue);
	}

	IEnumerator FadeEffect(int duration, int maxHealth)
	{
		yield return new WaitForSeconds(duration);
		CollectHealth(gameObject, 0, maxHealth);
	}
}
