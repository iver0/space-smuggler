using System;
using UnityEngine;

public class Medkit : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int> MedkitCollected;
    [SerializeField] AudioEvent audioEvent;

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
            gameObject.SetActive(false);
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.enabled = true;
            audioEvent.Play(audioSource);
        }
    }
}
