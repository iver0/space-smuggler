using System;
using UnityEngine;

public class Morphine : MonoBehaviour, ICollectible
{
	public static event Action<GameObject, int, int, bool, int> MorphineCollected;
	[SerializeField] AudioEvent _audioEvent;

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
		MorphineCollected?.Invoke(gameObject, 25, 125, true, 60);
	}

	public void OnItemCollected(GameObject item)
	{
		if (GameObject.ReferenceEquals(item, gameObject))
		{
			// Creating a new empty GameObject so that pickup sound can play
			gameObject.SetActive(false);
			GameObject go = new("MorphineCollectedSFX");
			AudioSource audioSource = go.AddComponent<AudioSource>();
			_audioEvent.Play(audioSource);
			Destroy(go, 1f);
			Destroy(gameObject);
		}
	}
}
