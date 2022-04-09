using System;
using UnityEngine;

public class LightArmor : MonoBehaviour, ICollectible
{
    public static event Action<GameObject, int, int> OnLightArmorCollected;
    
    public void Collect()
    {
        OnLightArmorCollected?.Invoke(gameObject, 25, 75);
    }
}
