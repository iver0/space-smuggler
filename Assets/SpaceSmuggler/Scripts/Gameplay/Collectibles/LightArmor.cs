using System;
using UnityEngine;

public class LightArmor : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int, int> OnLightArmorCollected;

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
        OnLightArmorCollected?.Invoke(gameObject, 25, 75);
    }

    public void DestroyCollectible(GameObject collectible)
    {
        if (GameObject.ReferenceEquals(collectible, gameObject))
        {
            Destroy(gameObject);
        }
    }
}
