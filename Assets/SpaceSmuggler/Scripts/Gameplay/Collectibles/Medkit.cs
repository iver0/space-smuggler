using System;
using UnityEngine;

public class Medkit : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int> MedkitCollected;

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
            Destroy(gameObject);
        }
    }
}
