using System;
using UnityEngine;

public class HeavyArmor : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int, int> OnHeavyArmorCollected;

    void OnEnable()
    {
        PlayerArmor.OnCollectibleCollected += DestroyCollectible;
    }

    void OnDisable()
    {
        PlayerArmor.OnCollectibleCollected -= DestroyCollectible;
    }

    public void Collect()
    {
        OnHeavyArmorCollected?.Invoke(gameObject, 25, 125);
    }

    public void DestroyCollectible(GameObject collectible)
    {
        if (GameObject.ReferenceEquals(collectible, gameObject))
        {
            Destroy(gameObject);
        }
    }
}
