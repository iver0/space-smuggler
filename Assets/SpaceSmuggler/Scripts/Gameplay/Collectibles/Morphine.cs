using System;
using UnityEngine;

public class Morphine : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int, int, bool, int> MorphineCollected;
    [SerializeField] AudioClip pickupSound;

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
            AudioManager.Instance.Play(pickupSound);
            Destroy(gameObject);
        }
    }
}
