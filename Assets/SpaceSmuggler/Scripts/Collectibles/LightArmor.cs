using System;
using UnityEngine;

public class LightArmor : MonoBehaviour, ICollectible
{
	public static event Action<GameObject, int, int> LightArmorCollected;
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
		LightArmorCollected?.Invoke(gameObject, 25, 75);
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
