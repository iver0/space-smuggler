using System;
using UnityEngine;

public class LightArmor : MonoBehaviour, ICollectible
{
    public static event Action<int, int> OnLightArmorCollected;
    
    public void Collect()
    {
        OnLightArmorCollected?.Invoke(25, 75);
        Destroy(gameObject);
    }
}
