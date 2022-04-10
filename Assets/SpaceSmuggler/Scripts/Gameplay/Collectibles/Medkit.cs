using System;
using UnityEngine;

public class Medkit : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int> OnMedkitCollected;

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
        OnMedkitCollected?.Invoke(gameObject, 25);
    }

    public void DestroyCollectible(GameObject collectible)
    {
        if (GameObject.ReferenceEquals(collectible, gameObject))
        {
            Destroy(gameObject);
        }
    }
}
