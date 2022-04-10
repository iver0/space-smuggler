using System;
using UnityEngine;

public class Armor : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int> OnArmorCollected;

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
        OnArmorCollected?.Invoke(gameObject, 25);
    }

    public void DestroyCollectible(GameObject collectible)
    {
        if (GameObject.ReferenceEquals(collectible, gameObject))
        {
            Destroy(gameObject);
        }
    }
}
