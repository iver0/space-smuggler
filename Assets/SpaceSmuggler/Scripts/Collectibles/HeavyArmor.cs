using System;
using UnityEngine;

public class HeavyArmor : MonoBehaviour, ICollectible
{
	public static event Action<GameObject, int, int> HeavyArmorCollected;
	[SerializeField] AudioEventSO _audioEvent;

	void OnEnable()
	{
		PlayerArmor.ItemCollected += OnItemCollected;
	}

	void OnDisable()
	{
		PlayerArmor.ItemCollected -= OnItemCollected;
	}

	public void Collect()
	{
		HeavyArmorCollected?.Invoke(gameObject, 25, 125);
	}

	public void OnItemCollected(GameObject item)
	{
		if (ReferenceEquals(item, gameObject))
		{
			_audioEvent.Play();
			Destroy(gameObject);
		}
	}
}
