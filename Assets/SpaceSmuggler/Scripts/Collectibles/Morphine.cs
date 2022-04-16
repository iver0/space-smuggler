using System;
using UnityEngine;

public class Morphine : MonoBehaviour, ICollectible
{
	public static event Action<GameObject, int, int, int> MorphineCollected;
	[SerializeField] AudioEventSO _audioEvent;

	void OnEnable()
	{
		PlayerHealth.ItemCollected += OnItemCollected;
	}

	void OnDisable()
	{
		PlayerHealth.ItemCollected -= OnItemCollected;
	}

	public void Collect()
	{
		MorphineCollected?.Invoke(gameObject, 25, 125, 60);
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
