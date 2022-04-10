using System;
using UnityEngine;

public class Morphine : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int, int, bool, int> OnMorphineCollected;

    void OnEnable()
    {
        PlayerHealth.OnCollectibleCollected += DestroyCollectible;
    }

    void OnDisable()
    {
        PlayerHealth.OnCollectibleCollected -= DestroyCollectible;
    }

    public void Collect()
    {
        OnMorphineCollected?.Invoke(gameObject, 25, 125, true, 60);
    }

    public void DestroyCollectible(GameObject collectible)
    {
        if (GameObject.ReferenceEquals(collectible, gameObject))
        {
            Destroy(gameObject);
        }
    }
}
