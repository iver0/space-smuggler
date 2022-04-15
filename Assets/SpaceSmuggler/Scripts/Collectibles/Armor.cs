using System;
using UnityEngine;

public class Armor : MonoBehaviour, ICollectible
{
	public static event Action<GameObject, int> ArmorCollected;
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
		ArmorCollected?.Invoke(gameObject, 25);
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
