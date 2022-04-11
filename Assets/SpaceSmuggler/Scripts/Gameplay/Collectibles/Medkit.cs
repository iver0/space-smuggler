using System;
using UnityEngine;

public class Medkit : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int> MedkitCollected;
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
        MedkitCollected?.Invoke(gameObject, 25);
    }

    public void OnItemCollected(GameObject item)
    {
        if (GameObject.ReferenceEquals(item, gameObject))
        {
            // Creating a new empty GameObject so that pickup sound can play
            gameObject.SetActive(false);
            GameObject go = new GameObject("MedkitCollectedSFX");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            _audioEvent.Play(audioSource);
            Destroy(go, 1f);
            Destroy(gameObject);
        }
    }
}
